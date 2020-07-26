using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;
using System.Data.SqlClient;
namespace StockManagementSystem.DAL.Gateway
{
    public class ViewSaleGateway:CommonGateway
    {
        public List<ViewSale> GetAllSoldItems(string fromDate,string toDate)
        {
            Query = "select Item, sum(Quantity) as SaleQuantity from StockOut_tb  where Date between @FromDate and @ToDate group by Item";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Command.Parameters.AddWithValue("FromDate", fromDate);
            Command.Parameters.AddWithValue("ToDate", toDate);

            Reader = Command.ExecuteReader();

            List<ViewSale> sales = new List<ViewSale>();

            while (Reader.Read())
            {
                ViewSale viewSale = new ViewSale();
                viewSale.Item = Reader["Item"].ToString();
                viewSale.SaleQuantity = Convert.ToInt32(Reader["SaleQuantity"]);

                sales.Add(viewSale);

            }
            Reader.Close();
            Connection.Close();
            return sales;
        }

    }
}