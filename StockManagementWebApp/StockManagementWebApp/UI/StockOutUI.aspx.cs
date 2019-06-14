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
    [Serializable]
    public partial class StockOutUI : System.Web.UI.Page
    {
        private List<StockOutData> stockOutDataList;
        private StockInManager stockInManager;
        private CompanyManager companyManager;
        private StockOutManager stockOutManager;
        private StockOutData stockOutData;
       
        public StockOutUI()
        {
            stockInManager = new StockInManager();
            companyManager = new CompanyManager();
            stockOutManager = new StockOutManager();
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
            int remainingQuantity = stockInManager.GetAvailableQuantity(Convert.ToInt32(itemDropDownList.SelectedValue));
          //  availableQuantityTextBox.Text = remainingQuantity.ToString();
           ///---
            int temp = 0;
            if (stockOutGridView.Rows.Count > 0)
            {
                for (int i = 0; i < stockOutGridView.Rows.Count; i++)
                {
                    HiddenField hiddenField = stockOutGridView.Rows[i].FindControl("HiddenField1") as HiddenField;
                    Label quantityLabel = stockOutGridView.Rows[i].FindControl("ItemQuantity") as Label;
                    int itemId = Convert.ToInt32(hiddenField.Value);

                    if (itemId == Convert.ToInt32(itemDropDownList.SelectedValue))
                    {
                       temp = Convert.ToInt32(quantityLabel.Text);
                        break;
                    }
                }
            }
            ///---
            if (temp > 0)
            {
                availableQuantityTextBox.Text = (remainingQuantity -temp).ToString();
            }
            else
            {
                availableQuantityTextBox.Text = remainingQuantity.ToString();
                
            }
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
            companyErrorMessege.Text = "";
        }

        protected void ItemList(object sender, EventArgs e)
        {
            View();
            itemErrorMessege.Text = "";
        }
        protected void stockAgainButton_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("StockOutUI.aspx");
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
           // remainingQuantity = (int) ViewState["quantityVS"];
            if (companyDropDownList.SelectedValue == "0")
            {
                companyErrorMessege.Text = "Please select a company.";
            }
            else if (itemDropDownList.SelectedValue == "0")
            {
                itemErrorMessege.Text = "Please select an item.";
            }
            else if (stockOutQuantityTextBox.Text == "")
            {
                errorMessegeLabel.Text = "*Stock Out quantity required";
            }
            else if (Convert.ToInt32(stockOutQuantityTextBox.Text) < 0)
            {
                errorMessegeLabel.Text = "*Stock Out quantity can not be negetive";
            }
            else if (Convert.ToInt32(availableQuantityTextBox.Text) < Convert.ToInt32(stockOutQuantityTextBox.Text))
            {
                errorMessegeLabel.Text = "Insufficient Stock";
            }
            else
            {
                
                int   temp = Convert.ToInt32(stockOutQuantityTextBox.Text);
                if (stockOutGridView.Rows.Count > 0)
                {
                    for (int i = 0; i < stockOutGridView.Rows.Count; i++)
                    {
                        HiddenField hiddenField = stockOutGridView.Rows[i].FindControl("HiddenField1") as HiddenField;
                        Label quantityLabel = stockOutGridView.Rows[i].FindControl("ItemQuantity") as Label;
                        int ItemId = Convert.ToInt32(hiddenField.Value);

                        if (ItemId == Convert.ToInt32(itemDropDownList.SelectedValue))
                        {
                            temp += Convert.ToInt32(quantityLabel.Text);
                         break;
                        }
                    }
                }
               
                
                  //  remainingQuantity -= Convert.ToInt32(stockOutQuantityTextBox.Text);
                int remainingQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                remainingQuantity -= temp;

                availableQuantityTextBox.Text = remainingQuantity.ToString();


                stockOutGridView.DataSource = GetAllStockOut();
                stockOutGridView.DataBind();
                stockOutQuantityTextBox.Text = String.Empty;
            }
        }

        public List<StockOutData> GetAllStockOut()
        {
            stockOutData = new StockOutData();
            stockOutData.Item = itemDropDownList.SelectedItem.Text;
            stockOutData.ItemId = Convert.ToInt32(itemDropDownList.SelectedItem.Value);
            stockOutData.Company = companyDropDownList.SelectedItem.Text;
            stockOutData.Quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);

            if (ViewState["stockListVS"] == null)
            {
                stockOutDataList = new List<StockOutData>();
                stockOutDataList.Add(stockOutData);
                ViewState["stockListVS"] = stockOutDataList;
                return stockOutDataList;
            }
            else
            {
                stockOutDataList = (List<StockOutData>)ViewState["stockListVS"];

                if (stockOutGridView.Rows.Count > 0)
                {
                    for (int i = 0; i < stockOutDataList.Count; i++)
                    {
                        if (stockOutDataList[i].ItemId == stockOutData.ItemId)
                        {
                            // stockOutDataList[0].Quantity += stockOutData.Quantity;
                            stockOutData.Quantity += stockOutDataList[0].Quantity;
                            stockOutDataList.RemoveAt(0);
                            break;
                        }
                    }
                    stockOutDataList.Add(stockOutData);
                }
                ViewState["stockListVS"] = stockOutDataList;
                return stockOutDataList;
            }
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            messegeLabel.Text = StockOut("Sell") + " recorded successfully";
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            messegeLabel.Text = StockOut("Damage") + " recorded successfully";
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            messegeLabel.Text = StockOut("Lost") + " recorded successfully";
        }

        public string StockOut(string type)
        {
            DateTime date = DateTime.Today;
            StockOut stockOut = new StockOut();
            StockIn stockIn = new StockIn();
            for (int i = 0; i < stockOutGridView.Rows.Count; i++)
            {
                HiddenField hiddenField = stockOutGridView.Rows[i].FindControl("HiddenField1") as HiddenField;
                Label quantityLabel = stockOutGridView.Rows[i].FindControl("ItemQuantity") as Label;
                stockOut.ItemId = Convert.ToInt32(hiddenField.Value);
                stockOut.StockOutQuantity = Convert.ToInt32(quantityLabel.Text);
                stockOut.Date = date;
                stockOut.Type = type;
                stockOutManager.SaveStockOut(stockOut);

                stockIn.ItemId = Convert.ToInt32(hiddenField.Value);
                int realQuantity = stockInManager.GetAvailableQuantity(stockIn.ItemId);
                if (realQuantity >= Convert.ToInt32(quantityLabel.Text))
                {
                    stockIn.AvailableQuantity = realQuantity - Convert.ToInt32(quantityLabel.Text);
                }
                else
                {
                    errorMessegeLabel.Text = "Insufficient stock";
                }
                stockInManager.SaveStockIn(stockIn);
            }
            return type;
        }
    }
}