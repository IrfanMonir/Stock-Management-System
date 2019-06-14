using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.BLL.Models;
using StockManagementWebApp.DAL;

namespace StockManagementWebApp.BLL.Manager
{
    public class StockOutManager
    {
        private StockOutGateway stockOutGateway;

        public StockOutManager()
        {
            stockOutGateway = new StockOutGateway();
        }

        public string SaveStockOut(StockOut stockOut)
        {
            int rowAffect = stockOutGateway.SaveStockOut(stockOut);
            if (rowAffect > 0)
            {
                return "Stocked out successfully";
            }
            else
            {
                return "Stocked out failed";
            }
        }
    }
}