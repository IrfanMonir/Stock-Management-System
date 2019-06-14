using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL.Manager;
using StockManagementWebApp.BLL.Models;

namespace StockManagementWebApp.UI
{
    public partial class StockInUI : System.Web.UI.Page
    {
        private StockInManager stockInManager;
        private CompanyManager companyManager;
        public StockInUI()
        {
            stockInManager = new StockInManager();
            companyManager = new CompanyManager();
        }

        public void CompanyList()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompany();
            companyDropDownList.DataTextField = "Name";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0, new ListItem("--Select Company--", "0"));
        }

        public void ItemList()
        {
            itemDropDownList.DataSource =
                    stockInManager.GetAllItem(Convert.ToInt32(companyDropDownList.SelectedValue));
            itemDropDownList.DataTextField = "ItemName";
            itemDropDownList.DataValueField = "ItemId";
            itemDropDownList.DataBind();
            itemDropDownList.Items.Insert(0, new ListItem("--Select Item--", "0"));
        }

        public void View()
        {
            reorderLevelTextBox.Enabled = false;
            availableQuantityTextBox.Enabled = false;
            reorderLevelTextBox.Text =
                stockInManager.GetReorderLevel(Convert.ToInt32(itemDropDownList.SelectedValue)).ToString();
            availableQuantityTextBox.Text =
               stockInManager.GetAvailableQuantity(Convert.ToInt32(itemDropDownList.SelectedValue)).ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CompanyList();
            }
        }


        protected void CompanyList(object sender, EventArgs e)
        {
            ItemList();
        }

        protected void ItemList(object sender, EventArgs e)
        {
            View();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (stockInQuantityTextBox.Text == "")
            {
                errorMessegeLabel.Text = "*Stock In quantity required";
            }
            else if (Convert.ToInt32(stockInQuantityTextBox.Text) < 0)
            {
                errorMessegeLabel.Text = "*Stock In quantity can not be negetive";
            }
            else
            {
                StockIn stockIn = new StockIn();

                stockIn.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                int realQuantity = stockInManager.GetAvailableQuantity(stockIn.ItemId);

                stockIn.AvailableQuantity = Convert.ToInt32(stockInQuantityTextBox.Text) + realQuantity;

                string message = stockInManager.SaveStockIn(stockIn);

                messegeLabel.Text = message;

                
                //int temp = Convert.ToInt32(availableQuantityTextBox.Text);
                int stockInQuantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                int TotalQuantity = stockInQuantity + realQuantity;
                availableQuantityTextBox.Text = TotalQuantity.ToString();
                stockInQuantityTextBox.Text = String.Empty;
            }
          
        }

        protected void stockAgainButton_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("StockInUI.aspx");
        }


    }
}