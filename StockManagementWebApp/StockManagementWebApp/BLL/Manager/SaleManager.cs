using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.BLL.Models;
using StockManagementWebApp.DAL;

namespace StockManagementWebApp.BLL.Manager
{
    public class SaleManager
    {
        private StockOutGateway stockOutGateway;

        public SaleManager()
        {
            stockOutGateway = new StockOutGateway();
        }


        public List<Sale> GetAllSellByDate(string fromDate, string toDate)
        {
            return stockOutGateway.GetAllSellByDate(fromDate, toDate);
        }
           

    }
}