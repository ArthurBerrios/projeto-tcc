using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class AlterarEmail : System.Web.UI.Page
    {
        DataTable dt;
        ConexaoSQL conexao;
        protected void Page_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            conexao = new ConexaoSQL(Environment.MachineName, "hot_rolls_club", "sa", "etesp");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AreadoCliente.aspx");
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
           
            string novoemail = txtEmail.Text;
            string cpfUsuario = Session["CPFUsuario"] as string;
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("exec AtualizarEmailCliente '" + cpfUsuario + "', '" + novoemail + "'");
            if (dt.Rows[0][0].ToString().Equals("Email atualizado com sucesso."))
            {
                Response.Redirect("AreadoCliente.aspx");
            }
            else
            {
                lblResultado.Text = dt.Rows[0][0].ToString();
            }
        }
    }
}