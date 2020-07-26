using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    public class StockOut
    {

        public string Item { get; set; }
        public string Company { get; set; }

        public int Quantity { get; set; }

        public string  Type { get; set; } 



    }
}