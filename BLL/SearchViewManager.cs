using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class SearchViewManager
    {
        SearchViewGateway aSearchViewGateway = new SearchViewGateway();
        public List<Company> GetAllCompanies()
        {
            return aSearchViewGateway.GetAllCompanies();
        }

        public List<Category> GetAllCategories()
        {
            return aSearchViewGateway.GetAllCategories();
        }

        public List<SearchView> SearchByCategory(int id)
        {

            return aSearchViewGateway.SearchByCategory(id);
        }
        public List<SearchView> SearchByCompany(int id)
        {

            return aSearchViewGateway.SearchByCompany(id);
        }
        public List<SearchView> SearchByBoth(int categoryId,int companyId)
        {

            return aSearchViewGateway.SearchByBoth(categoryId, companyId);
        } 

        
    }
}