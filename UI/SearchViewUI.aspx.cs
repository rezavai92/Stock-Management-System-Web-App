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
    public partial class SearchViewUI : System.Web.UI.Page
    {
        SearchViewManager aSearchViewManager = new SearchViewManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LogInUI.aspx");
            }

            if (!IsPostBack)
            {
                PopulateCompanyDropDownList();
                
                companyDropDownList.Items.Insert(0, new ListItem("Select Company", "0"));
                PopulateCategoryDropDownList();
               
                categoryDropDownList.Items.Insert(0, new ListItem("Select Category", "0"));

            } 


        }

        protected void PopulateCompanyDropDownList()
        {
            List<Company> companies = aSearchViewManager.GetAllCompanies();
            companyDropDownList.DataSource = companies;

            companyDropDownList.DataTextField = "Name";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();
        }

        protected void PopulateCategoryDropDownList()
        {
            List<Category> categories = aSearchViewManager.GetAllCategories();
            categoryDropDownList.DataSource = categories;
            categoryDropDownList.DataTextField = "Name";
            categoryDropDownList.DataValueField = "Id";
            categoryDropDownList.DataBind();
         }
        protected void PopulateGridView(string type,string categoryId,string companyId )
        {
            if (type == "company")
            {
                List<SearchView> searches = aSearchViewManager.SearchByCompany(Convert.ToInt32(companyId));
                searchGridView.DataSource = searches;
                searchGridView.DataBind();

            }
            else if (type == "category")
            {
               List<SearchView>  searches = aSearchViewManager.SearchByCategory( Convert.ToInt32( categoryId)) ;
               searchGridView.DataSource = searches;
               searchGridView.DataBind();
            }
            else if (type == "both")
            {
                List<SearchView> searches = aSearchViewManager.SearchByBoth(Convert.ToInt32 (categoryId),Convert.ToInt32(companyId) ) ;
                searchGridView.DataSource = searches;
                searchGridView.DataBind();
            } 
          

        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedValue=="0" && categoryDropDownList.SelectedValue=="0" ) {

                messageLabel.Text="you must select any company or category ";

            }
            else if (companyDropDownList.SelectedValue=="0" && categoryDropDownList.SelectedValue !="0" )  {

                string categoryId = categoryDropDownList.SelectedValue;
                PopulateGridView("category", categoryId ,"");

            } 
             else if (companyDropDownList.SelectedValue!="0" && categoryDropDownList.SelectedValue =="0" )  {
                 string  companyId =  companyDropDownList.SelectedValue ;

                 PopulateGridView("company","",companyId);
            } 
             else if (companyDropDownList.SelectedValue !="0" && categoryDropDownList.SelectedValue !="0" )  {

                 string categoryId = categoryDropDownList.SelectedValue;
                 string companyId = companyDropDownList.SelectedValue;
                 PopulateGridView("both",categoryId,companyId);
            } 







            companyDropDownList.AppendDataBoundItems = false;
            PopulateCompanyDropDownList();
            companyDropDownList.Items.Insert(0, new ListItem("Select Company", "0"));


            categoryDropDownList.AppendDataBoundItems = false;

            PopulateCategoryDropDownList();
            categoryDropDownList.Items.Insert(0, new ListItem("Select Category", "0"));



        }

        protected void logOutButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("LogInUI.aspx");
        }


        //protected void logOutButton_Click(object sender, EventArgs e)
        //{
        //    Session["User"] = null;
        //    Response.Redirect("LogInUI.aspx");
        //}

       
    }
}