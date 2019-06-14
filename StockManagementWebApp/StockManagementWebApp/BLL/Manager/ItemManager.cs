using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.BLL.Models;
using StockManagementWebApp.DAL;

namespace StockManagementWebApp.BLL.Manager
{
    public class ItemManager
    {
        private ItemGateway itemGateway;
        private CompanyGateway companyGateway;
        private CategoryGateway categoryGateway;
        
        public ItemManager()
        {
            itemGateway = new ItemGateway();
            companyGateway = new CompanyGateway();
            categoryGateway = new CategoryGateway();
        }

         public List<SummaryViewByCategory> GetSummaryByBoth(string company, string category)
         {
             List<SummaryViewByCategory> summaryByBoth =  itemGateway.GetSummaryByBoth(company, category);
            
             return summaryByBoth;
         }
        public List<SummaryViewByCategory> GetAllSummaryByCategory(string category)
        {

            return itemGateway.GetAllSummaryByCategory(category);
        }
        public List<SummaryView> GetAllSummaryByCompany(string company)
        {
           
            return itemGateway.GetAllSummaryByCompany(company);
        }

        public List<SummaryView> GetAllSummary()
        {
            
            return itemGateway.GetAllSummary();
        }

        public string SaveItem(Item item)
        {
            bool isItemExist = itemGateway.IsItemExist(item.Name);
            if (isItemExist == true)
            {
                return "Item Already Exists";
            }
            else
            {
                int rowAffect = itemGateway.SaveItem(item);
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
        public List<Category> GetAllCategory()
        {
            return categoryGateway.GetAllCategory();
        }

    }
}