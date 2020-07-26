using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using StockManagementSystem.DAL.Model;
namespace StockManagementSystem.DAL.Gateway
{
    public class CategoryGateway:CommonGateway
    {
        public bool IsCategoryExists(string name ,int id)
        {

            Query = "select * from Category_tb where name =@Name and id <> @Id ";
            
            Command=new SqlCommand (Query,Connection);
            Command.Parameters.AddWithValue("Name", name);
            Command.Parameters.AddWithValue("Id", id);
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

        public int Save(Category category)
        {
            Query = "Insert into Category_tb(Name) values (@Name) ";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("Name", category.Name);
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

        public List<Category> GetAllCategories()
        {

            Query = "Select * from Category_tb"; 
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Category> categories = new List<Category>();
            while (Reader.Read())
            {
                Category category = new Category();

                category.Name = Reader["Name"].ToString();
                category.Id = (int) Reader["Id"];
                categories.Add(category);
                
            }
            Reader.Close();
            Connection.Close();
            return categories;
        }
        public int Update(Category category)
        {
            Query = "Update Category_tb set Name=@Name where Id= @Id ";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("Name", category.Name);
            Command.Parameters.AddWithValue("Id", category.Id);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowAffected;
        }
    }
}