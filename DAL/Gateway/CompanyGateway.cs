using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using StockManagementSystem.DAL.Model;



namespace StockManagementSystem.DAL.Gateway
{
    public class CompanyGateway:CommonGateway
    {
        public bool IsCompanyExists(string companyName)
        {
            Query = "select * from Company_tb where Name= @Name";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("Name",companyName);
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
         public int Save(Company company)
        {
            Query = "Insert into Company_tb(Name) values (@Name) ";

             

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Name", company.Name);

            Connection.Open();

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
    }
}