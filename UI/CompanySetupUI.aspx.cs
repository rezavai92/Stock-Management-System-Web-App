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
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        CompanyManager acompanyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LogInUI.aspx");
            }
            PopulateGridView();
        }
        protected void PopulateGridView()
        {
            List<Company> allCompanies = acompanyManager.GetAllCompanies();
            companyGridView.DataSource = allCompanies;
            companyGridView.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            
            string comapnyName = nameTextBox.Text;

            if (comapnyName == "")
            {
                messageLabel.Text = "Name Field is empty,you cannot save an empty company Name";
            }

            else
            {
                Company acompany = new Company();

                acompany.Name = comapnyName;

                messageLabel.Text = acompanyManager.Save(acompany);

                PopulateGridView();

            }
          }

        protected void logOutButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("LogInUI.aspx");
        }

        

    }
}