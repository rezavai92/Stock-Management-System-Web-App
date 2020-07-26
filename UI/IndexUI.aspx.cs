using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.DAL.Model;
using StockManagementSystem.BLL;

namespace StockManagementSystem.UI
{
    public partial class IndexUI : System.Web.UI.Page
    {
        CategoryManager aCategoryManager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LogInUI.aspx");
            }
        }
        protected void logOutButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("LogInUI.aspx");
        }
       
        
    }
}