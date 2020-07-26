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
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        ItemManager itemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LogInUI.aspx"); 
            }
            if (!IsPostBack)
            {
                
                PopulateDropDown();

            }
            else
            {
                
            }
        }

        public void PopulateDropDown()
        {

            List<Company> companies = itemManager.GetAllCompanies(); 

            companyDropDownList.DataSource = companies;
            companyDropDownList.DataTextField = "Name";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();

            List<Category> categories = itemManager.GetAllCategories();

            categoryDropDownList.DataSource = categories;
            categoryDropDownList.DataTextField = "Name";
            categoryDropDownList.DataValueField = "Id";
            categoryDropDownList.DataBind();

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string name = itemNameTextBox.Text;
           
            if (name == String.Empty || reOrderLevelTextBox.Text==String.Empty)
            {
                messageLabel.Text = "field cannot be empty";
            }

            else
            {

                Item item = new Item();
                int reOrderLevel = Convert.ToInt32(reOrderLevelTextBox.Text);


                item.CategoryId = Convert.ToInt32( categoryDropDownList.SelectedValue) ;
                item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                item.Name = name;
                item.ReorderLevel = reOrderLevel;
                messageLabel.Text = itemManager.Save(item) ;




                
               


                itemNameTextBox.Text = "";
                reOrderLevelTextBox.Text = Convert.ToString(0);
                PopulateDropDown();
            }
        }

        protected void logOutButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("LogInUI.aspx");
        }
    }
}