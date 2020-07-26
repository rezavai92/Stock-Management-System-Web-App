using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class CompanyManager
    {
        CompanyGateway companyGateway = new CompanyGateway();

        private bool IsCompanyExists(string companyName)
        {
            return companyGateway.IsCompanyExists(companyName);
        }
        public string Save(Company company)
        {

            if (IsCompanyExists(company.Name))
            {
                return "this company already exists";

            }
            if (companyGateway.Save(company) > 0)
            {
                return "Saved Successfully";
            }
            return "Failed to save";
        }
        public List<Company> GetAllCompanies()
        {
            return companyGateway.GetAllCompanies();
        }
    }
}