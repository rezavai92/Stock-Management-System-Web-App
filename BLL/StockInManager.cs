using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;
using StockManagementSystem.DAL.Gateway;

namespace StockManagementSystem.BLL
{

    public class StockInManager
    {
        StockInGateway aStockInGateway = new StockInGateway();
        public List<Company> GetAllCompanies()
        {

            return aStockInGateway.GetAllCompanies();
        }

        public List<Item> getAllItemsDependentOnSelectedCompany(int value)
        {

            return aStockInGateway.GetAllItemsDependentOnSelectedCompanies(value);

        }

        public int GetAvailableQuantity(int id)
        {

            return aStockInGateway.GetAvailableQuantity(id);
        } 

        public int GetReorderLevel (int id) {

            return aStockInGateway.GetReorderLevel(id);
        }

        public string UpdateQuantity(int id, int quantity)
        {

            if (aStockInGateway.UpdateQuantity(id, quantity) > 0)
            {

                return " Quantity Updated Successfully ";
            }

            return "failed to update quantity"; 
        }
    }
}