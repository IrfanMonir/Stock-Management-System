using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.BLL.Models;
using StockManagementWebApp.DAL;

namespace StockManagementWebApp.BLL.Manager
{
    public class StockInManager
    {
        private StockInGateway stockInGateway;

        public StockInManager()
        {
            stockInGateway = new StockInGateway();
        }

        public string SaveStockIn(StockIn stockIn)
        {
            bool isItemExist = stockInGateway.IsItemExist(stockIn.ItemId);
            if (isItemExist)
            {

                int rowAffect = stockInGateway.UpdateAvailableQuantityByItem(stockIn);
                if (rowAffect > 0)
                {
                    return "Stocked in successfully";
                }
                else
                {
                    return "Stocked in failed";
                }
            }
            else
            {
                int rowAffect = stockInGateway.SaveStockIn(stockIn);
                if (rowAffect > 0)
                {
                    return "Stocked in successfully";
                }
                else
                {
                    return "Stocked in failed";
                }
            }
           
        }

        public List<GetAllItemView> GetAllItem(int company)
        {
            return stockInGateway.GetAllItemByCompany(company);
        }
        
        public int GetReorderLevel(int Id)
        {
            return stockInGateway.GetReorderLevel(Id);
        }

        public int GetAvailableQuantity(int Id)
        {
            int i = 0;
            bool isNullAavailableQuantity = stockInGateway.IsNullAvailableQuantity(Id);
            if (isNullAavailableQuantity)
            {
                return i;
            }
            else
            {
                return stockInGateway.GetAvailableQuantity(Id);                
            }
        }
    }
}