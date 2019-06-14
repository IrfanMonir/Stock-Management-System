using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL.Manager;

namespace StockManagementWebApp.UI
{
    public partial class SummaryUI : System.Web.UI.Page
    {
        private CategoryManager categoryManager;
        private CompanyManager companyManager;
        private ItemManager itemManager;

        public SummaryUI()
        {
            categoryManager = new CategoryManager();
            companyManager = new CompanyManager();
            itemManager = new ItemManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
             
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            

            if (CategoryDropDownList.SelectedValue == "0" & CompanyDropDownList.SelectedValue == "0")
            {
                summaryGridView.DataSource = itemManager.GetAllSummary();
                summaryGridView.DataBind();
            }
            else if (CategoryDropDownList.SelectedValue == "0")
            {
                 summaryGridView.DataSource =  itemManager.GetAllSummaryByCompany(CompanyDropDownList.SelectedItem.ToString());
                summaryGridView.DataBind();
               
            }
            else if (CompanyDropDownList.SelectedValue == "0")
            {
                summaryGridView.DataSource =
                    itemManager.GetAllSummaryByCategory(CategoryDropDownList.SelectedItem.ToString());
                summaryGridView.DataBind();
            }
            else
            {
                summaryGridView.DataSource = itemManager.GetSummaryByBoth(CompanyDropDownList.SelectedItem.ToString(),
                    CategoryDropDownList.SelectedItem.ToString());
               
                   summaryGridView.DataBind();
            }

            if (summaryGridView.Rows.Count < 1)
            {
                messageLevel.Text = "No data found in this match";
            }
        }

       

       
    }
}