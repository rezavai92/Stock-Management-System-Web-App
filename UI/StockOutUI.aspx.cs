using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using StockManagementSystem.BLL;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        StockOutManager aStockOutManager = new StockOutManager();

        DataTable dt = new DataTable();
        List<string> items = new List<string>();
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
                companyDropDownList.Items.Insert(0, new ListItem("Select Company", "0"));
                DisableButtons();






            }


            itemDropDownList.AppendDataBoundItems = true;
            itemDropDownList.Items.Insert(0, new ListItem("Select Item", "0"));


        }
        protected bool isItemExists(string itemName)
        {
            bool availableRow = false;
            foreach (GridViewRow row in stockOutGridView.Rows)
            {
                if (row.Cells[1].Text == itemName)
                {
                    availableRow = true;
                }
            }
            return availableRow;
        }

        protected void PopulateGridView()
        {


            if (ViewState["datatable"] != null)
            {

                DataTable dt1 = (DataTable)ViewState["datatable"];


                string item = "";
                string company = "";
                string quantity = "";

                //if (itemDropDownList.SelectedValue == "0" || companyDropDownList.SelectedValue == "0" || stockOutQuantityTextBox.Text == "")
                //{

                //}
               
                
                    item = itemDropDownList.SelectedItem.Text;
                    company = companyDropDownList.SelectedItem.Text;
                    quantity = stockOutQuantityTextBox.Text;


                
                dt1.Rows.Add(item, company, quantity);

                ViewState["datatable"] = dt1;

                
            }

            else
            {
               

                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Item", typeof(string)),
                            new DataColumn("Company", typeof(string)),
                            new DataColumn("Quantity",typeof(string)) });



                string item = "";
                string company = "";
                string quantity = "";

                //if (itemDropDownList.SelectedValue == "0" || companyDropDownList.SelectedValue == "0" || stockOutQuantityTextBox.Text == "")
                //{

                //}
                
                    item = itemDropDownList.SelectedItem.Text;
                    company = companyDropDownList.SelectedItem.Text;
                    quantity = stockOutQuantityTextBox.Text;


                




                dt.Rows.Add(item, company, quantity);

                ViewState["datatable"] = dt;




            }
            stockOutGridView.DataSource = ViewState["datatable"];
            stockOutGridView.DataBind();

        }


        protected void PopulateCompanyDropDownList()
        {


            List<Company> companies = aStockOutManager.GetAllCompanies();



            companyDropDownList.DataSource = companies;



            companyDropDownList.DataTextField = "Name";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();




        }


        public int GetReorderLevel(int id)
        {
            return aStockOutManager.GetReorderLevel(id);

        }

        public int GetAvailableQuantity(int id)
        {
            return aStockOutManager.GetAvailableQuantity(id);

        }

        



        protected void PopulateItemDropDownList(int value)
        {



            List<Item> items = aStockOutManager.getAllItemsDependentOnSelectedCompany(value);

            itemDropDownList.DataSource = items;
            itemDropDownList.DataTextField = "Name";
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataBind();

        }


        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {


            Clear();

            string value = companyDropDownList.SelectedValue;
            int selectedValue = Convert.ToInt32(value);

            itemDropDownList.AppendDataBoundItems = false;
            PopulateItemDropDownList(selectedValue);




            if (itemDropDownList.SelectedItem == null)
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
            stockOutQuantityTextBox.Text = "";
            messageLabel.Text = "";
        }

        protected void addButton_Click1(object sender, EventArgs e)
        {
            
            string itemName = itemDropDownList.SelectedItem.Text;
            int quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
            int availableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);

            if (quantity > availableQuantity)
            {
                messageLabel.Text = "stock out quantity can not be greater than available quantity ";
            }
            else
            {
                if (isItemExists(itemName))
                {
                    foreach (GridViewRow row in stockOutGridView.Rows)
                    {

                        if (row.Cells[1].Text == itemName)
                        {
                            row.Cells[3].Text = (Convert.ToInt32(row.Cells[3].Text) + quantity ).ToString();


                        }
                    }


                }
                else
                {
                    PopulateGridView();

                }
                messageLabel.Text = aStockOutManager.UpdateQuantity(Convert.ToInt32(itemDropDownList.SelectedValue), quantity);
                messageLabel.Enabled = false;
                availableQuantityTextBox.Text =GetAvailableQuantity( Convert.ToInt32 (itemDropDownList.SelectedValue )).ToString()  ;
                EnableButtons();
            }

           
        }
        protected void DisableButtons()
        {
            sellButton.Enabled = false;
            damageButton.Enabled = false;
            lostButton.Enabled = false;


        }
        protected void EnableButtons()
        {
            sellButton.Enabled = true ;
            damageButton.Enabled = true ;
            lostButton.Enabled = true;

        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<StockOut> outs = new List<StockOut>();

            

            foreach (GridViewRow row in stockOutGridView.Rows)
            {
                StockOut soldStockOut = new StockOut();
                soldStockOut.Item = row.Cells[1].Text;
                soldStockOut.Company = row.Cells[2].Text;
                soldStockOut.Quantity = Convert.ToInt32(row.Cells[3].Text);
                soldStockOut.Type = "Sale";

                outs.Add(soldStockOut);

            }
            messageLabel.Text = aStockOutManager.SaveStockOut(outs);
            EvacuateGridView();
            DisableButtons();
            
        }

        public void EvacuateGridView()
        {
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            ViewState["datatable"] = null; 

        }
        protected void damageButton_Click(object sender, EventArgs e)
        {
              List<StockOut> outs = new List<StockOut>();
              foreach (GridViewRow row in stockOutGridView.Rows)
              {
                  StockOut soldStockOut = new StockOut();
                  soldStockOut.Item = row.Cells[1].Text;
                  soldStockOut.Company = row.Cells[2].Text;
                  soldStockOut.Quantity = Convert.ToInt32(row.Cells[3].Text);
                  soldStockOut.Type = "Damage";

                  outs.Add(soldStockOut);

              }
              messageLabel.Text = aStockOutManager.SaveStockOut(outs);
              EvacuateGridView();
              DisableButtons();

            

           
              
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            List<StockOut> outs = new List<StockOut>();
            foreach (GridViewRow row in stockOutGridView.Rows)
            {
                StockOut soldStockOut = new StockOut();
                soldStockOut.Item = row.Cells[1].Text;
                soldStockOut.Company = row.Cells[2].Text;
                soldStockOut.Quantity = Convert.ToInt32(row.Cells[3].Text);
                soldStockOut.Type = "Lost";

                outs.Add(soldStockOut);

            }
            messageLabel.Text = aStockOutManager.SaveStockOut(outs);
            EvacuateGridView();
            DisableButtons();

        }
        protected void logOutButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("LogInUI.aspx");
        }
    }

}