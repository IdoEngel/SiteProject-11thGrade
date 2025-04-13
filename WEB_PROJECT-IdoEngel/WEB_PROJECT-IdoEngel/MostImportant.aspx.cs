using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_PROJECT_IdoEngel
{
    public partial class MostImportant : System.Web.UI.Page
    {
        public string fromDal;
        protected void Page_Load(object sender, EventArgs e)
        {
            fromDal = Dal.UsersDataTableToHTMLFilter((string)Session["Email"]);
        }
    }
}