using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    public class SearchView
    {
        public string Item { get; set; }
        public string Company { get; set; }

        public string Category { get; set; }

        public int AvailableQuantity { get; set; }

        public int ReorderLevel { get; set; }
    }
}