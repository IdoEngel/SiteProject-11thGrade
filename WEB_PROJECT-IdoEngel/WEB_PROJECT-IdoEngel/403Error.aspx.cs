using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_PROJECT_IdoEngel
{
    public partial class _403Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Write("<head><title>Forbidden Page!</title></head>");
            Response.Write("<img src=\"imgs/error403.png\" alt=\"403 Error!!\" style=\"position: absolute; bottom: 0; left: 50%; transform: translateX(-50%); max-width: 100%; max-height: 100vh;\"/>");
            Response.Write("<script>");
            Response.Write("setTimeout(function() {");
            Response.Write("    var userConfirmed = confirm('This page is not allowed for un-logged users. Would you like to log in?');");
            Response.Write("    if (userConfirmed) {");
            Response.Write("        window.location.href = 'UserNav.aspx';");
            Response.Write("    }");
            Response.Write("}, 1200);"); // wait for 1.2 second(s)
            Response.Write("</script>");
            Response.End();
        }
    }
}