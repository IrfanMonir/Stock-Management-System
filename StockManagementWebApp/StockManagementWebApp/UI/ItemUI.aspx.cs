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
    public partial class ItemUI : System.Web.UI.Page
    {

        private ItemManager itemManager;
        private CategoryManager categoryManager;
        private CompanyManager companyManager;
        private StockInManager stockInManager;

        public ItemUI()
        {
            itemManager = new ItemManager();
            categoryManager = new CategoryManager();
            companyManager = new CompanyManager();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CategoryDropDownList.DataSource = categoryManager.GetAllCategory();
                CategoryDropDownList.DataTextField = "Name";
                CategoryDropDownList.DataValueField = "Id";
                CategoryDropDownList.DataBind();
                CategoryDropDownList.Items.Insert(0, new ListItem("--Select Item--", "0"));


                CompanyDropDownList.DataSource = companyManager.GetAllCompany();
                CompanyDropDownList.DataTextField = "Name";
                CompanyDropDownList.DataValueField = "Id";
                CompanyDropDownList.DataBind();
                CompanyDropDownList.Items.Insert(0, new ListItem("--Select Item--", "0"));
                ReorderLevelTextBox.Text = "0";
            }
        }

        protected void saveButton_Click1(object sender, EventArgs e)
        {
            if (ReorderLevelTextBox.Text == "")
            {
                errorMessegeLabel.Text = "*Reorder Level required";
            }
            else if (Convert.ToInt32(ReorderLevelTextBox.Text) < 0)
            {
                errorMessegeLabel.Text = "*Reorder Level can not be negetive";
            }
          
            else
            {
                Item item = new Item();
              
                item.CategoryId = Convert.ToInt32(CategoryDropDownList.SelectedValue);
                item.CompanyId = Convert.ToInt32(CompanyDropDownList.SelectedValue);
                item.Name = ItemNameTextBox.Text;
                item.ReorderLevel = Convert.ToInt32(ReorderLevelTextBox.Text);

                //item.ReorderLevel = Convert.ToInt32(ReorderLevelTextBox.Text);

                string message = itemManager.SaveItem(item);
                //StockIn stockIn = new StockIn();
                //stockIn 
                //stockInManager.SaveStockIn();
                messageLevel.Text = message;
            }
          
        }
    }
}