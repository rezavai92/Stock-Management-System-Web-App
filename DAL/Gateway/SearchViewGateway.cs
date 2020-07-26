using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class SearchViewGateway:CommonGateway
    {

        public List<Company> GetAllCompanies()
        {

            Query = "Select * from Company_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Company> companies = new List<Company>();
            while (Reader.Read())
            {

                Company company = new Company();

                company.Name = Reader["Name"].ToString();
                company.Id = (int)Reader["Id"];
                companies.Add(company);

            }
            Reader.Close();
            Connection.Close();
            return companies;
        }
        private string GetCompanyName(int id)
        {
            Query = "Select Name from Company_tb where Id =@Id";

            Command = new SqlCommand(Query, Connection);

           

            Command.Parameters.AddWithValue("Id", id);

           
            SqlDataReader reader = Command.ExecuteReader();

            reader.Read();

            string companyName = reader["Name"].ToString();

            reader.Close();
            

            return companyName;


        }
        private string GetCategoryName(int id)
        {
            Query = "Select Name from Category_tb where Id =@Id";

            Command = new SqlCommand(Query, Connection);

           

            Command.Parameters.AddWithValue("Id", id);

            SqlDataReader reader = Command.ExecuteReader();

            reader.Read();

            string categoryName = reader["Name"].ToString();

            reader.Close();
            return categoryName;


        }



        public List<SearchView> SearchByCategory(int id)
        {
            Query = "select * from Item_tb where CategoryId =@CategoryId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Command.Parameters.AddWithValue("CategoryId", id);
            Reader = Command.ExecuteReader();

            List<SearchView> searchViews = new List<SearchView>();
            while (Reader.Read())
            {

                SearchView searchView = new SearchView();

                searchView.Item = Reader["Name"].ToString();

                searchView.AvailableQuantity = (int) Reader["Quantity"];

                searchView.ReorderLevel = (int)Reader["ReOrderLevel"];
                
                searchView.Company =  GetCompanyName ( (int) Reader["CompanyId"] ) ;

                searchView.Category = GetCategoryName((int)Reader["CategoryId"]);

                

                searchViews.Add(searchView);

                

            }

            Reader.Close();
            Connection.Close();
            return searchViews;
        }
        public List<SearchView> SearchByCompany(int id)
        {
            Query = "select * from Item_tb where CompanyId =@CompanyId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Command.Parameters.AddWithValue("CompanyId", id);
            Reader = Command.ExecuteReader();

            List<SearchView> searchViews = new List<SearchView>();
            while (Reader.Read())
            {

                SearchView searchView = new SearchView();

                searchView.Item = Reader["Name"].ToString();

                searchView.AvailableQuantity = (int)Reader["Quantity"];

                searchView.ReorderLevel = (int)Reader["ReOrderLevel"];

                searchView.Company = GetCompanyName((int)Reader["CompanyId"]);

                searchView.Category = GetCategoryName((int)Reader["CategoryId"]);



                searchViews.Add(searchView);



            }

            Reader.Close();
            Connection.Close();
            return searchViews;
        }


        public List<SearchView> SearchByBoth(int categoryId,int companyId)
        {
            Query = "select * from Item_tb where CompanyId =@CompanyId and CategoryId=@CategoryId" ;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Command.Parameters.AddWithValue("CategoryId", categoryId);
            Command.Parameters.AddWithValue("CompanyId", companyId);
            Reader = Command.ExecuteReader();

            List<SearchView> searchViews = new List<SearchView>();
            while (Reader.Read())
            {

                SearchView searchView = new SearchView();

                searchView.Item = Reader["Name"].ToString();

                searchView.AvailableQuantity = (int)Reader["Quantity"];

                searchView.ReorderLevel = (int)Reader["ReOrderLevel"];

                searchView.Company = GetCompanyName((int)Reader["CompanyId"]);

                searchView.Category = GetCategoryName((int)Reader["CategoryId"]);



                searchViews.Add(searchView);



            }

            Reader.Close();
            Connection.Close();
            return searchViews;
        } 
        
        public List<Category> GetAllCategories()
        {

            Query = "Select * from Category_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Category> categories = new List<Category>();
            while (Reader.Read())
            {
                Category category = new Category();

                category.Name = Reader["Name"].ToString();
                category.Id = (int)Reader["Id"];
                categories.Add(category);

            }
            Reader.Close();
            Connection.Close();
            return categories;
        } 


    }
}