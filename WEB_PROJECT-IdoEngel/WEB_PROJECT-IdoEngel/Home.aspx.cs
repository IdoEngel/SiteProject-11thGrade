using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WEB_PROJECT_IdoEngel
{
    public partial class Home : System.Web.UI.Page
    {
        public string fromDal = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request.Form["delBtn"] != null)
                {
                    string filter = Request.Form["inputField"] ?? "";
                    Dal.DeleteTask(filter);
                }
                fromDal = Dal.UsersDataTableToHTML((string)Session["Email"]);
            }
            else
            {
                fromDal = Dal.UsersDataTableToHTML((string)Session["Email"]);
            }
        }
    }
}