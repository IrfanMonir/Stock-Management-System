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
    public partial class CompanyUI : System.Web.UI.Page
    {
        private CompanyManager companyManager;

        public CompanyUI()
        {
            companyManager = new CompanyManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            companyGridView.DataSource = companyManager.GetAllCompany();
            companyGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (companyTextBox.Value.Equals(""))
            {
                errorMessageLabel.InnerHtml = "*Please enter company name";
            }

            else
            {
                Company company = new Company();

                company.Name = companyTextBox.Value;


                string message = companyManager.SaveCompany(company);

                messageLabel.InnerHtml = message;

                companyTextBox.Value = String.Empty;
            }
          
        }
    }
}