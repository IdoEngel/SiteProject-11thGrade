using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_PROJECT_IdoEngel
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            endSession();
        }

        private void endSession()
        {
            // מחיקת כל הערכים ב-Session
            Session.Clear();  // מנקה את כל המידע מהסשן
            Session.Abandon();  // מפסיק את הסשן הנוכחי
            Response.Redirect("UserNav.aspx");  // הפניה לדף הבית או דף אחר
            Response.End();

        }
    }
}