using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient ;
using StockManagementSystem.DAL.Model;
namespace StockManagementSystem.DAL.Gateway
{
    public class StockInGateway:CommonGateway
    {

        public List<Item> GetAllItemsDependentOnSelectedCompanies(int value)
        {

            Query = "select * from Item_tb where CompanyId = @CompanyId";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.AddWithValue("CompanyId", value);

            Reader = Command.ExecuteReader();
            List<Item> items = new List<Item>();

            while (Reader.Read())
            {
                Item item = new Item();

                item.Name = Reader["Name"].ToString();
                item.Id = Convert.ToInt32 (Reader["Id"] );

                item.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                item.CompanyId = Convert.ToInt32(Reader["CompanyId"]);

                items.Add(item);

            }
            Reader.Close();
            Connection.Close();
            return items;
 
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


         public int GetAvailableQuantity(int id)
         {

             Query = "select Quantity from Item_tb where Id=@Id";

             Command = new SqlCommand(Query, Connection);
             Connection.Open();

             Command.Parameters.AddWithValue("Id",id);

             Reader = Command.ExecuteReader();

             Reader.Read();
             int quantity =Convert.ToInt32( Reader["Quantity"] );

             Reader.Close();

             Connection.Close();
             return quantity;
         }

         public int GetReorderLevel(int id)
         {

             Query = "select ReOrderLevel from Item_tb where Id=@Id";

             Command = new SqlCommand(Query, Connection);
             Connection.Open();

             Command.Parameters.AddWithValue("Id", id);

             Reader = Command.ExecuteReader();

             Reader.Read();
             int reOrderLevel = Convert.ToInt32(Reader["ReOrderLevel"]);

             Reader.Close();

             Connection.Close();
             return reOrderLevel;
         }

         public int UpdateQuantity(int id, int quantity)
         {

             Query = "select * from Item_tb where Id = @Id";

             Command = new SqlCommand(Query, Connection);
             Connection.Open();
             Command.Parameters.AddWithValue("Id", id);

             Reader = Command.ExecuteReader();


             Reader.Read();
             int existingQuantity = (int)Reader["Quantity"];

             existingQuantity += quantity;

             Reader.Close();
             Connection.Close();

            string  query1 = "update Item_tb set Quantity= @Quantity where Id=@Id  ";

            Command = new SqlCommand(query1, Connection);

            Connection.Open();
            Command.Parameters.AddWithValue("Quantity", existingQuantity);

            Command.Parameters.AddWithValue("Id", id);


            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowAffected;
 

             

         }

    }
    }
