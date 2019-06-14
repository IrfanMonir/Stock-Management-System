using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL.Manager;
using StockManagementWebApp.BLL.Models;

namespace StockManagementWebApp.UI
{
    public partial class CategoryUpdateUI : System.Web.UI.Page
    {
        private CategoryManager categoryManager;

        public CategoryUpdateUI()
        {
            categoryManager = new CategoryManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                Category student = categoryManager.GetCategoryById(id);

                idHiddenField.Value = student.Id.ToString();
                categoryTextBox.Value = student.Name;
               }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(idHiddenField.Value);
            category.Name = categoryTextBox.Value;
          
            string messege = categoryManager.UpdateCategory(category);
            if (messege == "Category Already Exists")
            {
                errorMessageLabel.InnerHtml = "Category Already Exists";
                
            }
            else
            {
                Response.Redirect("CategoryUI.aspx");
                
            }
        }
    }
}