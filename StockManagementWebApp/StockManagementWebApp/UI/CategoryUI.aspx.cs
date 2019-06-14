using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL.Manager;
using StockManagementWebApp.BLL.Models;

namespace StockManagementWebApp.UI
{
    public partial class CategoryUI : System.Web.UI.Page
    {
         private CategoryManager categoryManager;
        public CategoryUI()
        {
            categoryManager = new CategoryManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryGridView.DataSource = categoryManager.GetAllCategory();
            categoryGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            
            if (categoryTextBox.Value.Equals(""))
            {

                errorMessageLabel.InnerHtml = "*Please enter category name";
            }
            else
            {
                Category category = new Category();
                category.Name = categoryTextBox.Value;

                string message = categoryManager.SaveCategory(category);
                messageLabel.InnerHtml = message;

                categoryTextBox.Value = String.Empty;
                
            }
        }
        protected void updateLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton updateLinkButton = (LinkButton)sender;
            DataControlFieldCell cell = updateLinkButton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            
            HiddenField hiddenField = row.FindControl("HiddenField1") as HiddenField;
            
            //idLabel.Text = hiddenField.Value.ToString();
           Response.Redirect("CategoryUpdateUI.aspx?Id=" + hiddenField.Value);

        }
        protected void categoryGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}