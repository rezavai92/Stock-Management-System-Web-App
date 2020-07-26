using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;

using System.Data.SqlClient;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class LogInGateway: CommonGateway
    {
        public bool ValidateUser(string username, string password)
        {
           
            
            Query = "Select UserName from User_tb where Username=@UserName and Password =@Password ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Command.Parameters.AddWithValue("UserName", username);
            Command.Parameters.AddWithValue("Password", password);

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
    }
}