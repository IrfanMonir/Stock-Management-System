using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.BLL.Models;
using StockManagementWebApp.DAL;

namespace StockManagementWebApp.BLL.Manager
{
    
    public class CategoryManager
    {
        private CategoryGateway categoryGateway;

        public CategoryManager()
        {
            categoryGateway = new CategoryGateway();
        }

       
        public string SaveCategory(Category category)
        {
            bool isCategoryExist = categoryGateway.IsCategoryExist(category.Name);
            if (isCategoryExist == true)
            {
                return "Category Already Exists";
            }
            else
            {
                int rowAffect = categoryGateway.SaveCategory(category);
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

        public List<Category> GetAllCategory()
        {
            return categoryGateway.GetAllCategory();
        }
        
            public Category GetCategoryById(int id)
        {
            return categoryGateway.GetCategoryById(id);
        }

            public string UpdateCategory(Category category)
        {

            bool isCategoryExist = categoryGateway.IsCategoryExist(category.Name);
            if (isCategoryExist == true)
            {
                return "Category Already Exists";
            }
            else
            {
                int rowAffect = categoryGateway.UpdateCategory(category);
                if (rowAffect > 0)
                {
                    return "Update Successful";
                }
                else
                {
                    return "Update Failed";
                }
            }
           
        }
    }
}