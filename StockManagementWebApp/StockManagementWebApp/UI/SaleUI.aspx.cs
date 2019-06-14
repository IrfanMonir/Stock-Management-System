using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL.Manager;

namespace StockManagementWebApp.UI
{
    public partial class SaleUI : System.Web.UI.Page
    {
        private SaleManager saleManager;

        public SaleUI()
        {
            saleManager = new SaleManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            saleGridView.DataSource = null;
            saleGridView.DataBind();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;
            
            saleGridView.DataSource = saleManager.GetAllSellByDate(fromDate, toDate);
            saleGridView.DataBind();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
          
        }
    }
}