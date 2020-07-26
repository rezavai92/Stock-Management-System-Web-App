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
    public partial class CategorySetupUI : System.Web.UI.Page
    {
        
        CategoryManager aCategoryManager = new CategoryManager();
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
            List<Category> allCategories = aCategoryManager.GetAllCategories();


            categoryGridView.DataSource = allCategories;
            categoryGridView.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {



            if (nameTextBox.Text == "")
            {

                messageLabel.Text = "you cannot save an empty category";
            }

            else
            {
                Category acategory = new Category();

                acategory.Name = nameTextBox.Text;

                if (saveButton.Text == "Save")
                {
                    messageLabel.Text = aCategoryManager.Save(acategory);

                }

                else if (saveButton.Text == "Update")
                {


                    acategory.Id = Convert.ToInt32(idHiddenField.Value);

                    messageLabel.Text = aCategoryManager.Update(acategory);

                }


                PopulateGridView();
            }

        }
        protected void categoryGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            string name = categoryGridView.SelectedRow.Cells[1].Text; 
           nameTextBox.Text = name;
           saveButton.Text = "Update";

           string id = categoryGridView.SelectedDataKey.Value.ToString();

          
           idHiddenField.Value = id;



        }

        protected void categoryGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                e.Row.Attributes.Add("ondblclick", "__doPostBack('categoryGridView','Select$" + e.Row.RowIndex + "');");
            }
        }

        protected void categoryGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }



        protected void logOutButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("LogInUI.aspx");
        }
      

        
    }
}