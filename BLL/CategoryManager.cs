using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;
using StockManagementSystem.DAL.Gateway;

namespace StockManagementSystem.BLL
{
    public class CategoryManager
    {
        CategoryGateway categoryGateway = new CategoryGateway();

        public bool IsCategoryExists(string name,int id)
        {
            return categoryGateway.IsCategoryExists(name,id);
        }
        public string Save(Category category)
        {
            if (IsCategoryExists(category.Name,category.Id))
            {
                return "this category already exists ";
            }
            if (categoryGateway.Save(category) > 0)
            {
                return "Successfully Saved";
            }

            return "Failed to save";
        }
        public List<Category> GetAllCategories()
        {
            return categoryGateway.GetAllCategories();
        }

        public string Update (Category category){


            if (IsCategoryExists(category.Name, category.Id))
            {
                return "this category already exists ";

            }
            if (categoryGateway.Update(category) > 0)
            {
                return "Successfully Updated";
            }

            return "failed to update";

        }
    }
}