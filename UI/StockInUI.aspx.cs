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
    public partial class StockInUI : System.Web.UI.Page
    {

        StockInManager aStockInManager = new StockInManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LogInUI.aspx");
            }

            if (!IsPostBack)
            {
                
                companyDropDownList.AppendDataBoundItems = true;
                
                PopulateCompanyDropDownList();
                companyDropDownList.Items.Insert(0, new ListItem("Select Company","0" )  );
               
                

               
            
            }
            itemDropDownList.AppendDataBoundItems = true;
            itemDropDownList.Items.Insert(0, new ListItem("Select Item", "0"));
           
            
        }

        protected void PopulateCompanyDropDownList()
        {

            
            List<Company> companies = aStockInManager.GetAllCompanies();

            

            companyDropDownList.DataSource = companies; 

            

            companyDropDownList.DataTextField = "Name";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();




        }


        public int GetReorderLevel(int id)
        {
            return aStockInManager.GetReorderLevel(id);
            
        }

        public int GetAvailableQuantity(int id )
        {
           return  aStockInManager.GetAvailableQuantity(id);
           
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(companyDropDownList.SelectedValue) == 0 || Convert.ToInt32(itemDropDownList.SelectedValue) == 0)
            //{
            //    messageLabel.Text = "select a valid company and item ";
            //}
            //else if (stockInQuantityTextBox.Text=="")
            //{

            //} 


           
            
            

                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);

                int quantity = Convert.ToInt32(stockInQuantityTextBox.Text); 


                messageLabel.Text = aStockInManager.UpdateQuantity(itemId, quantity);




                companyDropDownList.AppendDataBoundItems = false;

                PopulateCompanyDropDownList();

                companyDropDownList.Items.Insert(0, new ListItem("Select Company", "0"));

                itemDropDownList.AppendDataBoundItems = false;

                itemDropDownList.Items.Clear();

                itemDropDownList.Items.Insert(0, new ListItem("Select Item", "0"));

                Clear();
            
        }

       

        protected void PopulateItemDropDownList(int value )
        {

            
            
            List<Item> items= aStockInManager.getAllItemsDependentOnSelectedCompany(value);

            itemDropDownList.DataSource = items;
            itemDropDownList.DataTextField = "Name";
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataBind(); 

        }

       
        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {


            Clear();
           
                string value = companyDropDownList.SelectedValue ;
                int selectedValue = Convert.ToInt32(value);

                itemDropDownList.AppendDataBoundItems = false;
                PopulateItemDropDownList(selectedValue);


               

            if (itemDropDownList.SelectedItem==null)
            {

            }
            else
            {
                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);



                availableQuantityTextBox.Text = GetAvailableQuantity(itemId).ToString();


                reorderLabelTextBox.Text = GetReorderLevel(itemId).ToString();


            }

            


        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            Clear();
            int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);



            availableQuantityTextBox.Text = GetAvailableQuantity(itemId).ToString();


            reorderLabelTextBox.Text = GetReorderLevel(itemId).ToString();

        }




        public void Clear()
        {
            reorderLabelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            stockInQuantityTextBox.Text = "";
            messageLabel.Text = "";
        }
        protected void logOutButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("LogInUI.aspx");
        }
    }


}