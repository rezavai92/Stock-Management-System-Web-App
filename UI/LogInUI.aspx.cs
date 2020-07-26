using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;

namespace StockManagementSystem.UI
{
    public partial class LogInUI : System.Web.UI.Page
    {
        LogInManager aLogInManager = new LogInManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void logInButton_Click(object sender, EventArgs e)
        //{
        //    string userName = userNameTextBox.Text;
        //    string password = passwordTextBox.Text;

        //    if (aLogInManager.ValidateUser(userName, password))
        //    {
        //        Session["User"] = userName;

        //        Response.Redirect("IndexUI.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("LogInUI.aspx");
        //        messageLabel.Text = "Incorrect Username  or password  ,sorry !";
        //    }




        //}

        protected void logInButton_Click1(object sender, EventArgs e)
        {

            string userName = txtuserName.Text;
            string password = txtpassword.Text;

            if (aLogInManager.ValidateUser(userName, password))
            {
                Session["User"] = userName;

                Response.Redirect("IndexUI.aspx");
            }
            else
            {
                Response.Redirect("LogInUI.aspx");
                messageLabel.Text = "Incorrect Username  or password  ,sorry !";
            }
        }
    }
}