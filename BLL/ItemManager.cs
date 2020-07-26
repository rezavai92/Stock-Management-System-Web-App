using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;
using StockManagementSystem.DAL.Gateway;
namespace StockManagementSystem.BLL
{
    public class ItemManager
    {
        ItemGateway aItemGateway = new ItemGateway();




        public bool IsItemExists(string name)
        {
            return aItemGateway.IsItemExists(name);
        }
        public List<Company> GetAllCompanies()
        {
            return aItemGateway.GetAllCompanies();
        }

        public List<Category> GetAllCategories()
        {
            return aItemGateway.GetAllCategories(); 
        }

        //public bool IsItemExistsInStock(string name)
        //{
        //    return aItemGateway.IsItemExistsInStock(name);
        //}
       
        //public string SaveInStock(Item item)
        //{

        //    if (IsItemExistsInStock(item.Name))
        //    {

        //        return " this item already exists in stock"; 
        //    }

        //    if (aItemGateway.SaveInStock(item)  > 0)
        //    {
        //        return " item successfully saved in Stock Table";
        //    }

        //    return "failed to save in Stock";
        //}



        public string Save(Item item)
        {
            if (IsItemExists(item.Name))
            {
                return "this item name already exists in database";
            }

            if (aItemGateway.Save(item)  > 0)
            {
                return "Item Saved Successfully ";
            }

            return "failed to save";
        }
    }
}