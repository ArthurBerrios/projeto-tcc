using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class AlterarSenha : System.Web.UI.Page
    {
        DataTable dt;
        ConexaoSQL conexao;
        protected void Page_Load(object sender, EventArgs e)
        {
            conexao = new ConexaoSQL(Environment.MachineName, "hot_rolls_club", "sa", "etesp");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AreadoCliente.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text == txtConf.Text)
            {
                string cpfUsuario = Session["CPFUsuario"] as string;
                string senha = txtSenha.Text;
                dt = new DataTable();
                dt = conexao.ExecutarConsulta("EXEC AlterarSenhaCliente '"+cpfUsuario+"', '"+senha+"'");
                if (dt.Rows[0][0].ToString().Equals("Senha atualizada com sucesso."))
                {
                    Response.Redirect("AreadoCliente.aspx");
                }
                else
                {
                    lblResultado.Text = dt.Rows[0][0].ToString();
                }
            }
            else
            {
                lblResultado.Text = "Confirme sua senha novamente.";
            }
        }
    }
}