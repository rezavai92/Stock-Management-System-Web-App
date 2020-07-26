using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class ItemGateway:CommonGateway
    {
       



        public bool IsItemExists(string name)
        {
            Query = "Select * from Item_tb where Name=@Name";

            Command = new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("Name", name);
            Connection.Open();

            Reader = Command.ExecuteReader();

            bool row = false;
            if (Reader.HasRows)
            {
                row = true;
            }
            Reader.Close();
            Connection.Close();
            return row;
        }

        //public bool IsItemExistsInStock (string  name )
        //{
        //    Query = "Select * from Stock_tb where ItemName=@ItemName";

        //    Command = new SqlCommand(Query, Connection);
        //    Command.Parameters.AddWithValue("ItemName", name);
        //    Connection.Open();

        //    Reader = Command.ExecuteReader();

        //    bool row = false;
        //    if (Reader.HasRows)
        //    {
        //        row = true;
        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return row;
        //}

       

        //public int SaveInStock(Item item)
        //{



        //    Query = "Insert into Stock_tb (CompanyId,CategoryId,ItemName,ReOrderLevel,AvailableQuantity,ItemId)values (@CompanyId,@CategoryId,@ItemName,@ReOrderLevel,@AvailableQuantity,@ItemId) ";

        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();

           
        //    Command.Parameters.AddWithValue("CompanyId", item.CompanyId);
        //    Command.Parameters.AddWithValue("CategoryId", item.CategoryId);
        //    Command.Parameters.AddWithValue("ReOrderLevel", item.ReorderLevel);
        //    Command.Parameters.AddWithValue("ItemName", item.Name);
        //    Command.Parameters.AddWithValue("AvailableQuantity", 0);
        //    Command.Parameters.AddWithValue("ItemId", item.Id);

        //    int rowAffected = Command.ExecuteNonQuery();


        //    Connection.Close();
        //    return rowAffected;

        //}

        public int Save(Item item)
        {

            Query = "Insert into Item_tb (Name,CompanyId,CategoryId,ReOrderLevel,Quantity)values (@Name,@CompanyId,@CategoryId,@ReOrderLevel,@Quantity ) ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Command.Parameters.AddWithValue("Name", item.Name);
            Command.Parameters.AddWithValue("CompanyId", item.CompanyId);
            Command.Parameters.AddWithValue("CategoryId", item.CategoryId);
            Command.Parameters.AddWithValue("ReOrderLevel", item.ReorderLevel);
            Command.Parameters.AddWithValue("Quantity", 0);

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }



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