using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_PROJECT_IdoEngel
{
    public partial class Consts : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkAccess();
        }

        private void checkAccess()
        {
            // בודק אם יש קוקית שהמשתמש עבר את הבדיקה
            HttpCookie accessCookie = Request.Cookies["UserLoggedIn"];

            if (accessCookie != null && accessCookie.Value == "true" && Session["name"] != null)
            {
                // המשתמש כבר עבר את הבדיקה
                return;
            }

            string referer = Request.UrlReferrer?.ToString();
            if (referer == null || !referer.Contains("UserNav.aspx"))
            {
                Response.Redirect("403Error.aspx");
                Response.End();
            }
            else //the user logged in
            {
                // אם המשתמש עבר את הבדיקה, הגדר קוקית
                HttpCookie cookie = new HttpCookie("UserLoggedIn");
                cookie.Value = "true";  // ערך הקוקית שמורה על כך שהמשתמש עבר את הבדיקה
                cookie.Expires = DateTime.Now.AddHours(0.5); // תקופת זמן שהקוקית תהיה בתוקף
                Response.Cookies.Add(cookie);
            }

        }
    }
}