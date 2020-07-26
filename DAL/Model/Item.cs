using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    public class Item
    {
        public string  Name { get; set; }
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int CategoryId { get; set; }

        public  int  ReorderLevel { get; set; }
    }
}