using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;
using StockManagementSystem.DAL.Gateway;

namespace StockManagementSystem.BLL
{
    public class StockOutManager
    {
        StockOutGateway aStockOutGateway = new StockOutGateway();
        public List<Company> GetAllCompanies()
        {

            return aStockOutGateway.GetAllCompanies();
        }

        public List<Item> getAllItemsDependentOnSelectedCompany(int value)
        {

            return aStockOutGateway.GetAllItemsDependentOnSelectedCompanies(value);

        }

        public int GetAvailableQuantity(int id)
        {

            return aStockOutGateway.GetAvailableQuantity(id);
        }

        public int GetReorderLevel(int id)
        {

            return aStockOutGateway.GetReorderLevel(id);
        }

        public string UpdateQuantity(int id, int quantity)
        {

            if ( aStockOutGateway.UpdateQuantity(id,quantity) >0 ) 
            {

                return " Quantity Updated Successfully ";
            }

            return "failed to update quantity";
        }

        public string SaveStockOut( List<StockOut> stockout)
        {
            if (aStockOutGateway.SaveStockOut(stockout) == stockout.Count )
            {
                return "Saved Successfully";
            }
            return "Failed to Save ";
        }

    }
}