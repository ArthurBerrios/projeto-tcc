using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Login
{
    
    public partial class cadastro : System.Web.UI.Page
    {
        ConexaoSQL conexao;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            conexao = new ConexaoSQL(Environment.MachineName, "hot_rolls_club", "sa", "etesp");
        }

        protected void entrar_Click(object sender, EventArgs e)
        {
            string cpf =txtCPF.Text;
            string email = txtEmail.Text;
            string nome = txtNome.Text;
            string senha = txtSenha.Text;
            string telefone = txtTelefone.Text;

            
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("exec usp_cadastrarCliente '"+cpf+ "', '" + nome + "', '" + telefone + "', '" + email + "', '" + senha+"'");
       
            if (dt.Rows[0][0].Equals("Cadastro realizado com sucesso"))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Label1.Text = dt.Rows[0][0].ToString();
            }
        }
    }
}