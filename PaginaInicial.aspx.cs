using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class PaginaInicial : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string Login = Session["LoginFeito"] as string;
        }

      

        protected void btnLogin_Click1(object sender, EventArgs e)
        {

            if (Session["LoginFeito"] != null)
            {
                Response.Redirect("Reservaa.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}