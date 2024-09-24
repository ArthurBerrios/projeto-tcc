using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class Avaliar : System.Web.UI.Page
    {
        DataTable dt;
        ConexaoSQL conexao;
        protected void Page_Load(object sender, EventArgs e)
        {

            conexao = new ConexaoSQL(Environment.MachineName, "hot_rolls_club", "sa", "etesp");
        }

        protected void btnEstrela1_Click(object sender, EventArgs e)
        {
            btnEstrela1.BackColor = System.Drawing.Color.Yellow;
            btnEstrela2.BackColor = System.Drawing.Color.White;
            btnEstrela3.BackColor = System.Drawing.Color.White;
            btnEstrela4.BackColor = System.Drawing.Color.White;
            btnEstrela5.BackColor = System.Drawing.Color.White;

            Session["estrelas"] = 1;
        }

        protected void btnEstrela2_Click(object sender, EventArgs e)
        {
            btnEstrela1.BackColor = System.Drawing.Color.Yellow;
            btnEstrela2.BackColor = System.Drawing.Color.Yellow;
            btnEstrela3.BackColor = System.Drawing.Color.White;
            btnEstrela4.BackColor = System.Drawing.Color.White;
            btnEstrela5.BackColor = System.Drawing.Color.White;
            Session["estrelas"] = 2;
        }

        protected void btnEstrela3_Click(object sender, EventArgs e)
        {
            btnEstrela1.BackColor = System.Drawing.Color.Yellow;
            btnEstrela2.BackColor = System.Drawing.Color.Yellow;
            btnEstrela3.BackColor = System.Drawing.Color.Yellow;
            btnEstrela4.BackColor = System.Drawing.Color.White;
            btnEstrela5.BackColor = System.Drawing.Color.White;
            Session["estrelas"] = 3;
        }

        protected void btnEstrela4_Click(object sender, EventArgs e)
        {
            btnEstrela1.BackColor = System.Drawing.Color.Yellow;
            btnEstrela2.BackColor = System.Drawing.Color.Yellow;
            btnEstrela3.BackColor = System.Drawing.Color.Yellow;
            btnEstrela4.BackColor = System.Drawing.Color.Yellow;
            btnEstrela5.BackColor = System.Drawing.Color.White;
            Session["estrelas"] = 4;
        }

        protected void btnEstrela5_Click(object sender, EventArgs e)
        {
            btnEstrela1.BackColor = System.Drawing.Color.Yellow;
            btnEstrela2.BackColor = System.Drawing.Color.Yellow;
            btnEstrela3.BackColor = System.Drawing.Color.Yellow;
            btnEstrela4.BackColor = System.Drawing.Color.Yellow;
            btnEstrela5.BackColor = System.Drawing.Color.Yellow;
            Session["estrelas"] = 5;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            int estrelas = (int)Session["estrelas"];
            string comentario = txtComentario.Text;
            if(Session["estrelas"] != null & txtComentario.Text !="")
            {
                dt = conexao.ExecutarConsulta("INSERT INTO AvaliacaoWeb (estrelas, comentario_avaliacao) VALUES ('" + estrelas + "','" + comentario + "')");
                lblresultado.Text = "Obrigado por avaliar!";
            }
            else
            {
                lblresultado.Text = "Nos dê uma nota e deixe um comentário!";
            }
           
        }
    }
}