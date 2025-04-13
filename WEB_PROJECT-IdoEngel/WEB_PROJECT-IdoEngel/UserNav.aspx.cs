using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace WEB_PROJECT_IdoEngel
{
    public partial class UserNav1 : System.Web.UI.Page
    {
        public string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bool canRedirect = false;
            if (Request["signUp_name"] != null) //the signup form called
            {
                canRedirect = Dal.InsertUser(Request["signUp_email"], Request["signUp_password"], Request["signUp_name"]);
            }
            else //the login form called
            {
                canRedirect = Dal.IsValidUserPassword(Request["logIn_email"], Request["logIn_password"]);
            }

            if (canRedirect)
            {
                if (Request["signUp_name"] != null) //the signup form called
                {
                    Session["name"] = Request["signUp_name"];
                    Session["email"] = Request["signUp_email"];
                }
                else
                {
                    Session["name"] = Dal.GetUserName(Request["logIn_email"]);
                    Session["email"] = Request["logIn_email"];
                }
                
                Response.Redirect("Home.aspx");
            }
            else //if query is not correct
            {
                if (!(Request["signUp_name"] == null && Request["logIn_email"] == null)) //check if not two forms are empty
                {
                    if (Request["signUp_name"] != null) //the signup form called 
                    {
                        msg = "User with the same email is already signed up!";

                    }
                    else //the login form called
                    {
                        msg = "Password not matching the user name<br/> (Did you create an account?)";
                    }
                }
 
            }
        }
    }
}