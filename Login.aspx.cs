using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        ConexaoSQL conexao;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
             conexao = new ConexaoSQL(Environment.MachineName, "hot_rolls_club", "sa", "tutubalao");
        }


        protected void entrar_Click(object sender, EventArgs e)
        {
           string email = txtEmail.Text;
            string senha = txtSenha.Text;

            
             dt = new DataTable();

            dt = conexao.ExecutarConsulta("exec usp_loginCliente '"+email+"', '"+senha+"'");

            if (dt.Rows[0][0].Equals("Login aceito")) 
            {
                dt = conexao.ExecutarConsulta("select cpf from Cliente where email = '" + email + "'");
                string cpf = dt.Rows[0][0].ToString();
                Session["CPFUsuario"] = cpf;
                Session["LoginFeito"] = "Login realizado";
                Response.Redirect("Reservaa.aspx");
               
             
            }


            else
            {
                Label1.Text = dt.Rows[0][0].ToString();
            }

        }

        protected void cadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastro.aspx");
        }
    }
}