using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using StockManagementSystem.BLL;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.UI
{
    public partial class ViewSaleUI : System.Web.UI.Page
    {
        ViewSaleManager aViewSaleManager = new ViewSaleManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LogInUI.aspx");
            }
            
        }
        protected void PopulateGridView(string fromDate,string toDate )
        {
            List<ViewSale> sales = aViewSaleManager.GetAllSoldItems(fromDate,toDate);
            viewSaleGridView.DataSource = sales;
            viewSaleGridView.DataBind();
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;

            PopulateGridView(fromDate, toDate);


        }
        protected void logOutButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("LogInUI.aspx");
        }
    }
}