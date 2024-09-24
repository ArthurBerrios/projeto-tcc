using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class AlterarNome : System.Web.UI.Page
    {
        ConexaoSQL conexao;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            conexao = new ConexaoSQL(Environment.MachineName, "hot_rolls_club", "sa", "etesp");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AreadoCliente.aspx");
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            string cpfUsuario = Session["CPFUsuario"] as string;
            string nomenovo = txtNome.Text;
            dt = new DataTable();
            dt = conexao.ExecutarConsulta("update Cliente set nome = '" + nomenovo + "' where cpf = '" + cpfUsuario + "'");
            Response.Redirect("AreadoCliente.aspx");

        }
    }
}