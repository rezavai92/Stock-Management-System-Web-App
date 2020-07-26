using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;

namespace StockManagementSystem.BLL
{
    public class LogInManager
    {

        LogInGateway aLogInGateway = new LogInGateway();
        public bool ValidateUser(string username, string password) {

            return aLogInGateway.ValidateUser(username, password);
        }
    }
}