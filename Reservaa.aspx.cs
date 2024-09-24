using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{

    public partial class Reservaa : System.Web.UI.Page
    {
       
        ConexaoSQL conexao;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {


            dt = new DataTable();
            conexao = new ConexaoSQL(Environment.MachineName, "hot_rolls_club", "sa", "tutubalao");

            txtData.AutoPostBack = true;
            txtData.TextChanged += txtData_TextChanged;

            if (!IsPostBack) {

                dt = conexao.ExecutarConsulta("select * from Mesa");
                string mesa1 = dt.Rows[0][1].ToString();
                string mesa2 = dt.Rows[1][1].ToString();
                string mesa3 = dt.Rows[2][1].ToString();
                string mesa4 = dt.Rows[3][1].ToString();
                string mesa5 = dt.Rows[4][1].ToString();
                string mesa6 = dt.Rows[5][1].ToString();
                string mesa7 = dt.Rows[6][1].ToString();
                string mesa8 = dt.Rows[7][1].ToString();
                string mesa9 = dt.Rows[8][1].ToString();



                if (mesa1.Equals("Disponível"))
                {
                    mesa1Button.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    mesa1Button.BackColor = System.Drawing.Color.Red;
                }
                if (mesa2.Equals("Disponível"))
                {
                    mesa2Button.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    mesa2Button.BackColor = System.Drawing.Color.Red;
                }
                if (mesa3.Equals("Disponível"))
                {
                    mesa3Button.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    mesa3Button.BackColor = System.Drawing.Color.Red;
                }
                if (mesa4.Equals("Disponível"))
                {
                    mesa4Button.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    mesa4Button.BackColor = System.Drawing.Color.Red;
                }
                if (mesa5.Equals("Disponível"))
                {
                    mesa5Button.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    mesa5Button.BackColor = System.Drawing.Color.Red;
                }
                if (mesa6.Equals("Disponível"))
                {
                    mesa6Button.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    mesa6Button.BackColor = System.Drawing.Color.Red;
                }
                if (mesa7.Equals("Disponível"))
                {
                    mesa7Button.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    mesa7Button.BackColor = System.Drawing.Color.Red;
                }
                if (mesa8.Equals("Disponível"))
                {
                    mesa8Button.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    mesa8Button.BackColor = System.Drawing.Color.Red;
                }
                if (mesa9.Equals("Disponível"))
                {
                    mesa9Button.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    mesa9Button.BackColor = System.Drawing.Color.Red;
                }
            }
           
        }





    protected void mesa1Button_Click(object sender, EventArgs e)
        {
            AparecerCampos();

            Session["nmesa"] = 1;

            if (txtData.Text == "" & txtNome.Text == "")
            {
                lblhorarios.Text = "Selecione seu nome e a data";
            }

            dt = new DataTable();
            dt = conexao.ExecutarConsulta("select * from Mesa");
            string mesa = dt.Rows[0][1].ToString();
            if (mesa.Equals("Disponível"))
            {
                dpcadeiras.Items.Clear();
                for (int i = 1; i <= 4; i++)
                {
                    dpcadeiras.Items.Add(new ListItem("" + i, i.ToString()));
                }
            }


            if (DateTime.TryParse(txtData.Text, out DateTime dataSelecionada))
            {
                // Consulte o banco de dados para verificar se existem reservas na data selecionada
                string query = "SELECT data_reserva FROM Reserva WHERE CAST(data_reserva AS DATE) = '" + dataSelecionada + "' AND numero_mesa = 1";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter(dataSelecionada.ToString(), SqlDbType.Date)
            {
                Value = dataSelecionada.Date
            }
                };

                DataTable dtReservas = null;

                try
                {

                    {
                        dtReservas = conexao.ExecutarConsulta(query);

                    }
                }
                catch (Exception ex)
                {
                    // Lidar com erros de conexão ou consulta aqui, se necessário
                    lblhorarios.Text = "Erro ao acessar o banco de dados: " + ex.Message;
                    return;
                }

                // Limpe o DropDownList antes de preenchê-lo
                dpHorario.Items.Clear();

             
                    // Lista de todos os horários disponíveis, com intervalos de 1 hora, das 10:00 AM às 10:00 PM
                    List<string> horarios = new List<string>();
                    for (int hora = 10; hora <= 22; hora++)
                    {
                        horarios.Add($"{hora}:00");
                    }

                    // Lista de horários reservados (apenas 12:00, mas você pode adicionar mais horários, se necessário)
                    List<string> horariosReservados = new List<string>();

                    if (dtReservas != null && dtReservas.Rows.Count > 0)
                    {
                        // Preencha a lista de horários reservados com os valores do DataTable
                        foreach (DataRow row in dtReservas.Rows)
                        {
                            string horarioReserva = ((DateTime)row["data_reserva"]).ToString("HH:mm");
                            horariosReservados.Add(horarioReserva);
                        }

                        // Intervalo de tempo (horas antes e depois) para remoção automática

                    }
                    int intervaloHoras = 1;
                    // Horários a serem removidos da lista de horários
                    List<string> horariosARemover = new List<string>(horariosReservados);
                    foreach (string horarioReservado in horariosReservados)
                    {
                        // Converta o horário reservado em um objeto DateTime
                        DateTime horarioReservadoDT = DateTime.Parse(horarioReservado);

                        // Adicione os horários dentro do intervalo de horas ao horários a serem removidos
                        for (int i = 1; i <= intervaloHoras; i++)
                        {
                            string horarioAntes = horarioReservadoDT.AddHours(-i).ToString("HH:mm");
                            string horarioDepois = horarioReservadoDT.AddHours(i).ToString("HH:mm");

                            horariosARemover.Add(horarioAntes);
                            horariosARemover.Add(horarioDepois);
                        }
                    }

                    // Atualize a lista de horários removendo os horários reservados e horários próximos
                    List<string> horariosDisponiveis = horarios.Except(horariosARemover).ToList();

                    // Preencha dpHorario com a lista de horários disponíveis
                    dpHorario.Items.Clear();
                    dpHorario.Items.AddRange(horariosDisponiveis.Select(h => new ListItem(h, h)).ToArray());

                

            }
            else
            {
                lblhorarios.Text = "Data inválida.";
            }
            }





            protected void mesa2Button_Click(object sender, EventArgs e)
        {
            Session["nmesa"] = 2;

            if (txtData.Text == "" & txtNome.Text == "")
            {
                lblhorarios.Text = "Selecione seu nome e a data";
            }
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("select * from Mesa");
            string mesa = dt.Rows[1][1].ToString();
            if (mesa.Equals("Disponível"))
            {
                dpcadeiras.Items.Clear();
                for (int i = 1; i <= 6; i++)
                {
                    dpcadeiras.Items.Add(new ListItem("" + i, i.ToString()));
                }
            }

            if (DateTime.TryParse(txtData.Text, out DateTime dataSelecionada))
            {
                // Consulte o banco de dados para verificar se existem reservas na data selecionada
                string query = "SELECT data_reserva FROM Reserva WHERE CAST(data_reserva AS DATE) = '" + dataSelecionada + "' AND numero_mesa = 2";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter(dataSelecionada.ToString(), SqlDbType.Date)
            {
                Value = dataSelecionada.Date
            }
                };

                DataTable dtReservas = null;

                try
                {

                    {
                        dtReservas = conexao.ExecutarConsulta(query);

                    }
                }
                catch (Exception ex)
                {
                    // Lidar com erros de conexão ou consulta aqui, se necessário
                    lblhorarios.Text = "Erro ao acessar o banco de dados: " + ex.Message;
                    return;
                }

                // Limpe o DropDownList antes de preenchê-lo
                dpHorario.Items.Clear();


                // Lista de todos os horários disponíveis, com intervalos de 1 hora, das 10:00 AM às 10:00 PM
                List<string> horarios = new List<string>();
                for (int hora = 10; hora <= 22; hora++)
                {
                    horarios.Add($"{hora}:00");
                }

                // Lista de horários reservados (apenas 12:00, mas você pode adicionar mais horários, se necessário)
                List<string> horariosReservados = new List<string>();

                if (dtReservas != null && dtReservas.Rows.Count > 0)
                {
                    // Preencha a lista de horários reservados com os valores do DataTable
                    foreach (DataRow row in dtReservas.Rows)
                    {
                        string horarioReserva = ((DateTime)row["data_reserva"]).ToString("HH:mm");
                        horariosReservados.Add(horarioReserva);
                    }

                    // Intervalo de tempo (horas antes e depois) para remoção automática

                }
                int intervaloHoras = 1;
                // Horários a serem removidos da lista de horários
                List<string> horariosARemover = new List<string>(horariosReservados);
                foreach (string horarioReservado in horariosReservados)
                {
                    // Converta o horário reservado em um objeto DateTime
                    DateTime horarioReservadoDT = DateTime.Parse(horarioReservado);

                    // Adicione os horários dentro do intervalo de horas ao horários a serem removidos
                    for (int i = 1; i <= intervaloHoras; i++)
                    {
                        string horarioAntes = horarioReservadoDT.AddHours(-i).ToString("HH:mm");
                        string horarioDepois = horarioReservadoDT.AddHours(i).ToString("HH:mm");

                        horariosARemover.Add(horarioAntes);
                        horariosARemover.Add(horarioDepois);
                    }
                }

                // Atualize a lista de horários removendo os horários reservados e horários próximos
                List<string> horariosDisponiveis = horarios.Except(horariosARemover).ToList();

                // Preencha dpHorario com a lista de horários disponíveis
                dpHorario.Items.Clear();
                dpHorario.Items.AddRange(horariosDisponiveis.Select(h => new ListItem(h, h)).ToArray());



            }
            else
            {
                lblhorarios.Text = "Data inválida.";
            }
        }








    

    protected void mesa3Button_Click(object sender, EventArgs e)
        {
            Session["nmesa"] = 3;

            if (txtData.Text == "" & txtNome.Text == "")
            {
                lblhorarios.Text = "Selecione seu nome e a data";
            }
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("select * from Mesa");
            string mesa = dt.Rows[2][1].ToString();
            if (mesa.Equals("Disponível"))
            {
                dpcadeiras.Items.Clear();
                for (int i = 1; i <= 2; i++)
                {
                    dpcadeiras.Items.Add(new ListItem("" + i, i.ToString()));
                }
            }


            if (DateTime.TryParse(txtData.Text, out DateTime dataSelecionada))
            {
                // Consulte o banco de dados para verificar se existem reservas na data selecionada
                string query = "SELECT data_reserva FROM Reserva WHERE CAST(data_reserva AS DATE) = '" + dataSelecionada + "' AND numero_mesa = 3";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter(dataSelecionada.ToString(), SqlDbType.Date)
            {
                Value = dataSelecionada.Date
            }
                };

                DataTable dtReservas = null;

                try
                {

                    {
                        dtReservas = conexao.ExecutarConsulta(query);

                    }
                }
                catch (Exception ex)
                {
                    // Lidar com erros de conexão ou consulta aqui, se necessário
                    lblhorarios.Text = "Erro ao acessar o banco de dados: " + ex.Message;
                    return;
                }

                // Limpe o DropDownList antes de preenchê-lo
                dpHorario.Items.Clear();


                // Lista de todos os horários disponíveis, com intervalos de 1 hora, das 10:00 AM às 10:00 PM
                List<string> horarios = new List<string>();
                for (int hora = 10; hora <= 22; hora++)
                {
                    horarios.Add($"{hora}:00");
                }

                // Lista de horários reservados (apenas 12:00, mas você pode adicionar mais horários, se necessário)
                List<string> horariosReservados = new List<string>();

                if (dtReservas != null && dtReservas.Rows.Count > 0)
                {
                    // Preencha a lista de horários reservados com os valores do DataTable
                    foreach (DataRow row in dtReservas.Rows)
                    {
                        string horarioReserva = ((DateTime)row["data_reserva"]).ToString("HH:mm");
                        horariosReservados.Add(horarioReserva);
                    }

                    // Intervalo de tempo (horas antes e depois) para remoção automática

                }
                int intervaloHoras = 1;
                // Horários a serem removidos da lista de horários
                List<string> horariosARemover = new List<string>(horariosReservados);
                foreach (string horarioReservado in horariosReservados)
                {
                    // Converta o horário reservado em um objeto DateTime
                    DateTime horarioReservadoDT = DateTime.Parse(horarioReservado);

                    // Adicione os horários dentro do intervalo de horas ao horários a serem removidos
                    for (int i = 1; i <= intervaloHoras; i++)
                    {
                        string horarioAntes = horarioReservadoDT.AddHours(-i).ToString("HH:mm");
                        string horarioDepois = horarioReservadoDT.AddHours(i).ToString("HH:mm");

                        horariosARemover.Add(horarioAntes);
                        horariosARemover.Add(horarioDepois);
                    }
                }

                // Atualize a lista de horários removendo os horários reservados e horários próximos
                List<string> horariosDisponiveis = horarios.Except(horariosARemover).ToList();

                // Preencha dpHorario com a lista de horários disponíveis
                dpHorario.Items.Clear();
                dpHorario.Items.AddRange(horariosDisponiveis.Select(h => new ListItem(h, h)).ToArray());



            }
            else
            {
                lblhorarios.Text = "Data inválida.";
            }
        }


        protected void mesa4Button_Click(object sender, EventArgs e)
        {
            Session["nmesa"] = 4;

            if (txtData.Text == "" & txtNome.Text == "")
            {
                lblhorarios.Text = "Selecione seu nome e a data";
            }
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("select * from Mesa");
            string mesa = dt.Rows[3][1].ToString();
            if (mesa.Equals("Disponível"))
            {
                dpcadeiras.Items.Clear();
                for (int i = 1; i <= 8; i++)
                {
                    dpcadeiras.Items.Add(new ListItem("" + i, i.ToString()));
                }
            }

            if (DateTime.TryParse(txtData.Text, out DateTime dataSelecionada))
            {
                // Consulte o banco de dados para verificar se existem reservas na data selecionada
                string query = "SELECT data_reserva FROM Reserva WHERE CAST(data_reserva AS DATE) = '" + dataSelecionada + "' AND numero_mesa = 4";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter(dataSelecionada.ToString(), SqlDbType.Date)
            {
                Value = dataSelecionada.Date
            }
                };

                DataTable dtReservas = null;

                try
                {

                    {
                        dtReservas = conexao.ExecutarConsulta(query);

                    }
                }
                catch (Exception ex)
                {
                    // Lidar com erros de conexão ou consulta aqui, se necessário
                    lblhorarios.Text = "Erro ao acessar o banco de dados: " + ex.Message;
                    return;
                }

                // Limpe o DropDownList antes de preenchê-lo
                dpHorario.Items.Clear();


                // Lista de todos os horários disponíveis, com intervalos de 1 hora, das 10:00 AM às 10:00 PM
                List<string> horarios = new List<string>();
                for (int hora = 10; hora <= 22; hora++)
                {
                    horarios.Add($"{hora}:00");
                }

                // Lista de horários reservados (apenas 12:00, mas você pode adicionar mais horários, se necessário)
                List<string> horariosReservados = new List<string>();

                if (dtReservas != null && dtReservas.Rows.Count > 0)
                {
                    // Preencha a lista de horários reservados com os valores do DataTable
                    foreach (DataRow row in dtReservas.Rows)
                    {
                        string horarioReserva = ((DateTime)row["data_reserva"]).ToString("HH:mm");
                        horariosReservados.Add(horarioReserva);
                    }

                    // Intervalo de tempo (horas antes e depois) para remoção automática

                }
                int intervaloHoras = 1;
                // Horários a serem removidos da lista de horários
                List<string> horariosARemover = new List<string>(horariosReservados);
                foreach (string horarioReservado in horariosReservados)
                {
                    // Converta o horário reservado em um objeto DateTime
                    DateTime horarioReservadoDT = DateTime.Parse(horarioReservado);

                    // Adicione os horários dentro do intervalo de horas ao horários a serem removidos
                    for (int i = 1; i <= intervaloHoras; i++)
                    {
                        string horarioAntes = horarioReservadoDT.AddHours(-i).ToString("HH:mm");
                        string horarioDepois = horarioReservadoDT.AddHours(i).ToString("HH:mm");

                        horariosARemover.Add(horarioAntes);
                        horariosARemover.Add(horarioDepois);
                    }
                }

                // Atualize a lista de horários removendo os horários reservados e horários próximos
                List<string> horariosDisponiveis = horarios.Except(horariosARemover).ToList();

                // Preencha dpHorario com a lista de horários disponíveis
                dpHorario.Items.Clear();
                dpHorario.Items.AddRange(horariosDisponiveis.Select(h => new ListItem(h, h)).ToArray());



            }
            else
            {
                lblhorarios.Text = "Data inválida.";
            }
        }


        protected void mesa5Button_Click(object sender, EventArgs e)
        {
            Session["nmesa"] = 5;

            if (txtData.Text == "" & txtNome.Text == "")
            {
                lblhorarios.Text = "Selecione seu nome e a data";
            }
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("select * from Mesa");
            string mesa2 = dt.Rows[1][1].ToString();
            if (mesa2.Equals("Disponível"))
            {
                dpcadeiras.Items.Clear();
                for (int i = 1; i <= 4; i++)
                {
                    dpcadeiras.Items.Add(new ListItem("" + i, i.ToString()));
                }
            }

            if (DateTime.TryParse(txtData.Text, out DateTime dataSelecionada))
            {
                // Consulte o banco de dados para verificar se existem reservas na data selecionada
                string query = "SELECT data_reserva FROM Reserva WHERE CAST(data_reserva AS DATE) = '" + dataSelecionada + "' AND numero_mesa = 5";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter(dataSelecionada.ToString(), SqlDbType.Date)
            {
                Value = dataSelecionada.Date
            }
                };

                DataTable dtReservas = null;

                try
                {

                    {
                        dtReservas = conexao.ExecutarConsulta(query);

                    }
                }
                catch (Exception ex)
                {
                    // Lidar com erros de conexão ou consulta aqui, se necessário
                    lblhorarios.Text = "Erro ao acessar o banco de dados: " + ex.Message;
                    return;
                }

                // Limpe o DropDownList antes de preenchê-lo
                dpHorario.Items.Clear();


                // Lista de todos os horários disponíveis, com intervalos de 1 hora, das 10:00 AM às 10:00 PM
                List<string> horarios = new List<string>();
                for (int hora = 10; hora <= 22; hora++)
                {
                    horarios.Add($"{hora}:00");
                }

                // Lista de horários reservados (apenas 12:00, mas você pode adicionar mais horários, se necessário)
                List<string> horariosReservados = new List<string>();

                if (dtReservas != null && dtReservas.Rows.Count > 0)
                {
                    // Preencha a lista de horários reservados com os valores do DataTable
                    foreach (DataRow row in dtReservas.Rows)
                    {
                        string horarioReserva = ((DateTime)row["data_reserva"]).ToString("HH:mm");
                        horariosReservados.Add(horarioReserva);
                    }

                    // Intervalo de tempo (horas antes e depois) para remoção automática

                }
                int intervaloHoras = 1;
                // Horários a serem removidos da lista de horários
                List<string> horariosARemover = new List<string>(horariosReservados);
                foreach (string horarioReservado in horariosReservados)
                {
                    // Converta o horário reservado em um objeto DateTime
                    DateTime horarioReservadoDT = DateTime.Parse(horarioReservado);

                    // Adicione os horários dentro do intervalo de horas ao horários a serem removidos
                    for (int i = 1; i <= intervaloHoras; i++)
                    {
                        string horarioAntes = horarioReservadoDT.AddHours(-i).ToString("HH:mm");
                        string horarioDepois = horarioReservadoDT.AddHours(i).ToString("HH:mm");

                        horariosARemover.Add(horarioAntes);
                        horariosARemover.Add(horarioDepois);
                    }
                }

                // Atualize a lista de horários removendo os horários reservados e horários próximos
                List<string> horariosDisponiveis = horarios.Except(horariosARemover).ToList();

                // Preencha dpHorario com a lista de horários disponíveis
                dpHorario.Items.Clear();
                dpHorario.Items.AddRange(horariosDisponiveis.Select(h => new ListItem(h, h)).ToArray());



            }
            else
            {
                lblhorarios.Text = "Data inválida.";
            }
        }

        protected void mesa6Button_Click(object sender, EventArgs e)
        {
            Session["nmesa"] = 6;

            if (txtData.Text == "" & txtNome.Text == "")
            {
                lblhorarios.Text = "Selecione seu nome e a data";
            }
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("select * from Mesa");
            string mesa2 = dt.Rows[1][1].ToString();
            if (mesa2.Equals("Disponível"))
            {
                dpcadeiras.Items.Clear();
                for (int i = 1; i <= 2; i++)
                {
                    dpcadeiras.Items.Add(new ListItem("" + i, i.ToString()));
                }
            }

            if (DateTime.TryParse(txtData.Text, out DateTime dataSelecionada))
            {
                // Consulte o banco de dados para verificar se existem reservas na data selecionada
                string query = "SELECT data_reserva FROM Reserva WHERE CAST(data_reserva AS DATE) = '" + dataSelecionada + "' AND numero_mesa = 6";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter(dataSelecionada.ToString(), SqlDbType.Date)
            {
                Value = dataSelecionada.Date
            }
                };

                DataTable dtReservas = null;

                try
                {

                    {
                        dtReservas = conexao.ExecutarConsulta(query);

                    }
                }
                catch (Exception ex)
                {
                    // Lidar com erros de conexão ou consulta aqui, se necessário
                    lblhorarios.Text = "Erro ao acessar o banco de dados: " + ex.Message;
                    return;
                }

                // Limpe o DropDownList antes de preenchê-lo
                dpHorario.Items.Clear();


                // Lista de todos os horários disponíveis, com intervalos de 1 hora, das 10:00 AM às 10:00 PM
                List<string> horarios = new List<string>();
                for (int hora = 10; hora <= 22; hora++)
                {
                    horarios.Add($"{hora}:00");
                }

                // Lista de horários reservados (apenas 12:00, mas você pode adicionar mais horários, se necessário)
                List<string> horariosReservados = new List<string>();

                if (dtReservas != null && dtReservas.Rows.Count > 0)
                {
                    // Preencha a lista de horários reservados com os valores do DataTable
                    foreach (DataRow row in dtReservas.Rows)
                    {
                        string horarioReserva = ((DateTime)row["data_reserva"]).ToString("HH:mm");
                        horariosReservados.Add(horarioReserva);
                    }

                    // Intervalo de tempo (horas antes e depois) para remoção automática

                }
                int intervaloHoras = 1;
                // Horários a serem removidos da lista de horários
                List<string> horariosARemover = new List<string>(horariosReservados);
                foreach (string horarioReservado in horariosReservados)
                {
                    // Converta o horário reservado em um objeto DateTime
                    DateTime horarioReservadoDT = DateTime.Parse(horarioReservado);

                    // Adicione os horários dentro do intervalo de horas ao horários a serem removidos
                    for (int i = 1; i <= intervaloHoras; i++)
                    {
                        string horarioAntes = horarioReservadoDT.AddHours(-i).ToString("HH:mm");
                        string horarioDepois = horarioReservadoDT.AddHours(i).ToString("HH:mm");

                        horariosARemover.Add(horarioAntes);
                        horariosARemover.Add(horarioDepois);
                    }
                }

                // Atualize a lista de horários removendo os horários reservados e horários próximos
                List<string> horariosDisponiveis = horarios.Except(horariosARemover).ToList();

                // Preencha dpHorario com a lista de horários disponíveis
                dpHorario.Items.Clear();
                dpHorario.Items.AddRange(horariosDisponiveis.Select(h => new ListItem(h, h)).ToArray());



            }
            else
            {
                lblhorarios.Text = "Data inválida.";
            }
        }


        protected void mesa7Button_Click(object sender, EventArgs e)
        {
            Session["nmesa"] = 7;

            if (txtData.Text == "" & txtNome.Text == "")
            {
                lblhorarios.Text = "Selecione seu nome e a data";
            }
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("select * from Mesa");
            string mesa2 = dt.Rows[1][1].ToString();
            if (mesa2.Equals("Disponível"))
            {
                dpcadeiras.Items.Clear();
                for (int i = 1; i <= 6; i++)
                {
                    dpcadeiras.Items.Add(new ListItem("" + i, i.ToString()));
                }
            }

            if (DateTime.TryParse(txtData.Text, out DateTime dataSelecionada))
            {
                // Consulte o banco de dados para verificar se existem reservas na data selecionada
                string query = "SELECT data_reserva FROM Reserva WHERE CAST(data_reserva AS DATE) = '" + dataSelecionada + "' AND numero_mesa = 7";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter(dataSelecionada.ToString(), SqlDbType.Date)
            {
                Value = dataSelecionada.Date
            }
                };

                DataTable dtReservas = null;

                try
                {

                    {
                        dtReservas = conexao.ExecutarConsulta(query);

                    }
                }
                catch (Exception ex)
                {
                    // Lidar com erros de conexão ou consulta aqui, se necessário
                    lblhorarios.Text = "Erro ao acessar o banco de dados: " + ex.Message;
                    return;
                }

                // Limpe o DropDownList antes de preenchê-lo
                dpHorario.Items.Clear();


                // Lista de todos os horários disponíveis, com intervalos de 1 hora, das 10:00 AM às 10:00 PM
                List<string> horarios = new List<string>();
                for (int hora = 10; hora <= 22; hora++)
                {
                    horarios.Add($"{hora}:00");
                }

                // Lista de horários reservados (apenas 12:00, mas você pode adicionar mais horários, se necessário)
                List<string> horariosReservados = new List<string>();

                if (dtReservas != null && dtReservas.Rows.Count > 0)
                {
                    // Preencha a lista de horários reservados com os valores do DataTable
                    foreach (DataRow row in dtReservas.Rows)
                    {
                        string horarioReserva = ((DateTime)row["data_reserva"]).ToString("HH:mm");
                        horariosReservados.Add(horarioReserva);
                    }

                    // Intervalo de tempo (horas antes e depois) para remoção automática

                }
                int intervaloHoras = 1;
                // Horários a serem removidos da lista de horários
                List<string> horariosARemover = new List<string>(horariosReservados);
                foreach (string horarioReservado in horariosReservados)
                {
                    // Converta o horário reservado em um objeto DateTime
                    DateTime horarioReservadoDT = DateTime.Parse(horarioReservado);

                    // Adicione os horários dentro do intervalo de horas ao horários a serem removidos
                    for (int i = 1; i <= intervaloHoras; i++)
                    {
                        string horarioAntes = horarioReservadoDT.AddHours(-i).ToString("HH:mm");
                        string horarioDepois = horarioReservadoDT.AddHours(i).ToString("HH:mm");

                        horariosARemover.Add(horarioAntes);
                        horariosARemover.Add(horarioDepois);
                    }
                }

                // Atualize a lista de horários removendo os horários reservados e horários próximos
                List<string> horariosDisponiveis = horarios.Except(horariosARemover).ToList();

                // Preencha dpHorario com a lista de horários disponíveis
                dpHorario.Items.Clear();
                dpHorario.Items.AddRange(horariosDisponiveis.Select(h => new ListItem(h, h)).ToArray());



            }
            else
            {
                lblhorarios.Text = "Data inválida.";
            }
        }


        protected void mesa8Button_Click(object sender, EventArgs e)
        {
            Session["nmesa"] = 8;

            if (txtData.Text == "" & txtNome.Text == "")
            {
                lblhorarios.Text = "Selecione seu nome e a data";
            }
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("select * from Mesa");
            string mesa2 = dt.Rows[1][1].ToString();
            if (mesa2.Equals("Disponível"))
            {
                dpcadeiras.Items.Clear();
                for (int i = 1; i <= 4; i++)
                {
                    dpcadeiras.Items.Add(new ListItem("" + i, i.ToString()));
                }
            }

            if (DateTime.TryParse(txtData.Text, out DateTime dataSelecionada))
            {
                // Consulte o banco de dados para verificar se existem reservas na data selecionada
                string query = "SELECT data_reserva FROM Reserva WHERE CAST(data_reserva AS DATE) = '" + dataSelecionada + "' AND numero_mesa = 8";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter(dataSelecionada.ToString(), SqlDbType.Date)
            {
                Value = dataSelecionada.Date
            }
                };

                DataTable dtReservas = null;

                try
                {

                    {
                        dtReservas = conexao.ExecutarConsulta(query);

                    }
                }
                catch (Exception ex)
                {
                    // Lidar com erros de conexão ou consulta aqui, se necessário
                    lblhorarios.Text = "Erro ao acessar o banco de dados: " + ex.Message;
                    return;
                }

                // Limpe o DropDownList antes de preenchê-lo
                dpHorario.Items.Clear();


                // Lista de todos os horários disponíveis, com intervalos de 1 hora, das 10:00 AM às 10:00 PM
                List<string> horarios = new List<string>();
                for (int hora = 10; hora <= 22; hora++)
                {
                    horarios.Add($"{hora}:00");
                }

                // Lista de horários reservados (apenas 12:00, mas você pode adicionar mais horários, se necessário)
                List<string> horariosReservados = new List<string>();

                if (dtReservas != null && dtReservas.Rows.Count > 0)
                {
                    // Preencha a lista de horários reservados com os valores do DataTable
                    foreach (DataRow row in dtReservas.Rows)
                    {
                        string horarioReserva = ((DateTime)row["data_reserva"]).ToString("HH:mm");
                        horariosReservados.Add(horarioReserva);
                    }

                    // Intervalo de tempo (horas antes e depois) para remoção automática

                }
                int intervaloHoras = 1;
                // Horários a serem removidos da lista de horários
                List<string> horariosARemover = new List<string>(horariosReservados);
                foreach (string horarioReservado in horariosReservados)
                {
                    // Converta o horário reservado em um objeto DateTime
                    DateTime horarioReservadoDT = DateTime.Parse(horarioReservado);

                    // Adicione os horários dentro do intervalo de horas ao horários a serem removidos
                    for (int i = 1; i <= intervaloHoras; i++)
                    {
                        string horarioAntes = horarioReservadoDT.AddHours(-i).ToString("HH:mm");
                        string horarioDepois = horarioReservadoDT.AddHours(i).ToString("HH:mm");

                        horariosARemover.Add(horarioAntes);
                        horariosARemover.Add(horarioDepois);
                    }
                }

                // Atualize a lista de horários removendo os horários reservados e horários próximos
                List<string> horariosDisponiveis = horarios.Except(horariosARemover).ToList();

                // Preencha dpHorario com a lista de horários disponíveis
                dpHorario.Items.Clear();
                dpHorario.Items.AddRange(horariosDisponiveis.Select(h => new ListItem(h, h)).ToArray());



            }
            else
            {
                lblhorarios.Text = "Data inválida.";
            }
        }


        protected void mesa9Button_Click(object sender, EventArgs e)
        {
            Session["nmesa"] = 9;

            if (txtData.Text == "" & txtNome.Text == "")
            {
                lblhorarios.Text = "Selecione seu nome e a data";
            }
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("select * from Mesa");
            string mesa2 = dt.Rows[1][1].ToString();
            if (mesa2.Equals("Disponível"))
            {
                dpcadeiras.Items.Clear();
                for (int i = 1; i <= 2; i++)
                {
                    dpcadeiras.Items.Add(new ListItem("" + i, i.ToString()));
                }
            }

            if (DateTime.TryParse(txtData.Text, out DateTime dataSelecionada))
            {
                // Consulte o banco de dados para verificar se existem reservas na data selecionada
                string query = "SELECT data_reserva FROM Reserva WHERE CAST(data_reserva AS DATE) = '" + dataSelecionada + "' AND numero_mesa = 9";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter(dataSelecionada.ToString(), SqlDbType.Date)
            {
                Value = dataSelecionada.Date
            }
                };

                DataTable dtReservas = null;

                try
                {

                    {
                        dtReservas = conexao.ExecutarConsulta(query);

                    }
                }
                catch (Exception ex)
                {
                    // Lidar com erros de conexão ou consulta aqui, se necessário
                    lblhorarios.Text = "Erro ao acessar o banco de dados: " + ex.Message;
                    return;
                }

                // Limpe o DropDownList antes de preenchê-lo
                dpHorario.Items.Clear();


                // Lista de todos os horários disponíveis, com intervalos de 1 hora, das 10:00 AM às 10:00 PM
                List<string> horarios = new List<string>();
                for (int hora = 10; hora <= 22; hora++)
                {
                    horarios.Add($"{hora}:00");
                }

                // Lista de horários reservados (apenas 12:00, mas você pode adicionar mais horários, se necessário)
                List<string> horariosReservados = new List<string>();

                if (dtReservas != null && dtReservas.Rows.Count > 0)
                {
                    // Preencha a lista de horários reservados com os valores do DataTable
                    foreach (DataRow row in dtReservas.Rows)
                    {
                        string horarioReserva = ((DateTime)row["data_reserva"]).ToString("HH:mm");
                        horariosReservados.Add(horarioReserva);
                    }

                    // Intervalo de tempo (horas antes e depois) para remoção automática

                }
                int intervaloHoras = 1;
                // Horários a serem removidos da lista de horários
                List<string> horariosARemover = new List<string>(horariosReservados);
                foreach (string horarioReservado in horariosReservados)
                {
                    // Converta o horário reservado em um objeto DateTime
                    DateTime horarioReservadoDT = DateTime.Parse(horarioReservado);

                    // Adicione os horários dentro do intervalo de horas ao horários a serem removidos
                    for (int i = 1; i <= intervaloHoras; i++)
                    {
                        string horarioAntes = horarioReservadoDT.AddHours(-i).ToString("HH:mm");
                        string horarioDepois = horarioReservadoDT.AddHours(i).ToString("HH:mm");

                        horariosARemover.Add(horarioAntes);
                        horariosARemover.Add(horarioDepois);
                    }
                }

                // Atualize a lista de horários removendo os horários reservados e horários próximos
                List<string> horariosDisponiveis = horarios.Except(horariosARemover).ToList();

                // Preencha dpHorario com a lista de horários disponíveis
                dpHorario.Items.Clear();
                dpHorario.Items.AddRange(horariosDisponiveis.Select(h => new ListItem(h, h)).ToArray());



            }
            else
            {
                lblhorarios.Text = "Data inválida.";
            }
        }







        protected void reservarButton_Click(object sender, EventArgs e)
        {
          int nmesa = (int)Session["nmesa"] ;
            string cpfUsuario = Session["CPFUsuario"] as string;

            string dataTexto = txtData.Text + " "+ dpHorario.Text; // Exemplo de data no formato "ano-mês-dia"
            DateTime dataConvertida = DateTime.Parse(dataTexto);

            string qtdcadeiras = dpcadeiras.Text;
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("exec usp_fazer_reserva '" + cpfUsuario + "', '" + nmesa + "', '" + dataConvertida + "', '" + qtdcadeiras + "'");
            if (dt.Rows[0][0].Equals("Reserva realizada com sucesso!"))
            {
                Response.Redirect("AreadoCliente.aspx");
                 
            }
            else
            {
             lblhorarios.Text = dt.Rows[0][0].ToString(); 
            }
        }

        protected void txtData_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtData.Text))
            {
                mesa1Button.Enabled = true;
                lblhorarios.Text = "Clique na mesa que deseja reservar";
                
            }
        }
        protected void AparecerCampos()
        {
            lblhorarios.Text = "Escolha o horário e a quantidade de cadeiras";
            dpcadeiras.Visible = true;
            dpHorario.Visible = true;
            txtNome.Visible = true;
            reservarButton.Visible = true;
            Lbllugar.Visible = true;
            lblNome.Style["display"] = "block";

        }
    }
}


    