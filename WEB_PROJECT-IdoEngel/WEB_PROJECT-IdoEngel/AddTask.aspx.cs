using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_PROJECT_IdoEngel
{
    public partial class AddTask : System.Web.UI.Page
    {
        public string title = "";
        public string content = "";
        public string date = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["title"] != null)
            {
                title = Request["title"];
                content = Request["content"];
                date = Request["date"];
                bool isImportant = Request["isImportant"] != null;

                Dal.InsertTask(title, content, date, (string)Session["email"], isImportant);
                Response.Redirect("Home.aspx");
            }
        }
    }
}