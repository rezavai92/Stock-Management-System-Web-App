using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;
using StockManagementSystem.DAL.Gateway;

namespace StockManagementSystem.BLL
{
    public class ViewSaleManager
    {
        ViewSaleGateway aViewSaleGateway = new ViewSaleGateway();
        public List<ViewSale> GetAllSoldItems(string fromDate, string toDate)
        {
            return aViewSaleGateway.GetAllSoldItems(fromDate,toDate); 
        }
    }
}