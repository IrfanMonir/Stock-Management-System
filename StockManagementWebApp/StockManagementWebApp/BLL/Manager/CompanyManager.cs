using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.BLL.Models;
using StockManagementWebApp.DAL;

namespace StockManagementWebApp.BLL.Manager
{
    public class CompanyManager
    {
        private CompanyGateway companyGateway;

        public CompanyManager()
        {
            companyGateway = new CompanyGateway();
        }
      


        public string SaveCompany(Company company)
        {
            bool isCompanyExist = companyGateway.IsCompanyExist(company.Name);
            if (isCompanyExist == true)
            {
                return "Company Already Exists";
            }
            else
            {
                int rowAffect = companyGateway.SaveCompany(company);
                if (rowAffect > 0)
                {
                    return "Saved successfully";
                }
                else
                {
                    return "Saved failed";

                }
            }
           
        }

        public List<Company> GetAllCompany()
        {
            return companyGateway.GetAllCompany();
        }

    }
}