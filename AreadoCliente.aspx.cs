using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class AreadoCliente : System.Web.UI.Page
    {

        DataTable dt;
        ConexaoSQL conexao;
        protected void Page_Load(object sender, EventArgs e)
        {
            conexao = new ConexaoSQL(Environment.MachineName, "hot_rolls_club", "sa", "tutubalao");
            if (!IsPostBack)
            {
                //consultas
                dt = new DataTable();
                string cpfUsuario = Session["CPFUsuario"] as string;






                dt = conexao.ExecutarConsulta("select * from Cliente where cpf = '" + cpfUsuario + "'");
                lblBemvindo.Text = "Olá, " + dt.Rows[0][1].ToString() + "!";
                lblNome.Text = dt.Rows[0][1].ToString();
                lblEmail.Text = dt.Rows[0][3].ToString();
                lblcpf.Text = dt.Rows[0][0].ToString();
                lblSenha.Text = dt.Rows[0][6].ToString();

                //aparecer imagem 
                dt = conexao.ExecutarConsulta("select img_cliente from Cliente where cpf ='" + cpfUsuario + "'");
                byte[] imagemBytes = dt.Rows[0]["img_cliente"] as byte[];
                if (imagemBytes != null && imagemBytes.Length > 0)
                {
                    imgCliente.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imagemBytes);
                }
                else
                {
                    imgCliente.ImageUrl = "img/imgcliente.png";
                }

                //aparecer no grid view
                dt = conexao.ExecutarConsulta("SELECT data_reserva AS Data, [numero_mesa] AS[Número da Mesa], quantidade_pessoas AS[Quantidade de Pessoas] FROM Reserva where cpf = '" + cpfUsuario + "'");
                grvReservas.DataSource = dt.DefaultView;
                grvReservas.DataBind();

            }

        }

        protected void btnAlterarN_Click(object sender, EventArgs e)
        {

            Response.Redirect("AlterarNome.aspx");
        }

        protected void btnAlterarEmail_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlterarEmail.aspx");
        }

        protected void AlterarSenha_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlterarSenha.aspx");
        }



        protected void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            foreach (GridViewRow row in grvReservas.Rows)
            {
                // Encontre o controle CheckBox na coluna do GridView
                CheckBox chkCancelar = (CheckBox)row.FindControl("chkCancelar");

                if (chkCancelar.Checked)
                {
                    string cpfUsuario = Session["CPFUsuario"] as string;
                    int numeroMesa = int.Parse(row.Cells[2].Text);
                    DateTime dataReserva = DateTime.Parse(row.Cells[1].Text);

                    // Acumule os resultados das consultas em dt
                    DataTable result = conexao.ExecutarConsulta("exec usp_cancelar_reserva '" + cpfUsuario + "', '" + numeroMesa + "', '" + dataReserva + "'");
                    dt.Merge(result); // Merge os resultados na tabela dt
                    dt = conexao.ExecutarConsulta("SELECT data_reserva AS Data, [numero_mesa] AS[Número da Mesa], quantidade_pessoas AS[Quantidade de Pessoas] FROM Reserva where cpf = '" + cpfUsuario + "'");
                    grvReservas.DataSource = dt.DefaultView;
                    grvReservas.DataBind();
                }

            }
        }

        protected void btnMaisReservas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservaa.aspx");
        }

        protected void btnFazerAvaliacao_Click(object sender, EventArgs e)
        {
            Response.Redirect("Avaliar.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string cpfUsuario = Session["CPFUsuario"] as string;
            if (flpAlterarimg.HasFile)
            {
                // Certifique-se de que um arquivo foi selecionado no controle FileUpload

                byte[] imageBytes = flpAlterarimg.FileBytes; // Obtém os bytes da imagem diretamente do controle FileUpload

                //byte[] imagemBytes = File.ReadAllBytes(imageBytes);

                try
                {
                    string query = "UPDATE cliente SET img_cliente = @imagem WHERE cpf = @cpf";
                    SqlParameter[] parametros = new SqlParameter[]
                    {
                         new SqlParameter("@imagem", SqlDbType.VarBinary, -1) { Value = imageBytes },
                         new SqlParameter("@cpf", SqlDbType.VarChar) { Value = cpfUsuario } // Substitua pelo CPF real
                    };

                    int linhasAfetadas = conexao.ExecutarAtualizacao(query, parametros);

                    if (linhasAfetadas > 0)
                    {
                        Response.Write("foi");
                    }
                }
                catch (Exception ex)
                {
                    // Lide com erros, por exemplo, exiba uma mensagem de erro
                    Response.Write("Erro: " + ex.Message);
                }
          

            }
            dt = conexao.ExecutarConsulta("select img_cliente from Cliente where cpf ='" + cpfUsuario + "'");
            byte[] imagemBytes = dt.Rows[0]["img_cliente"] as byte[]; 
            if(imagemBytes != null && imagemBytes.Length > 0)
            {
                imgCliente.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imagemBytes);
            }
            else
            { Response.Write("Não foi possível recuperar a imagem após a atualização.");
}
            }

        }
    }


        
    


