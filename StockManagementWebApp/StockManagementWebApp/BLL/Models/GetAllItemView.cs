using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.BLL.Models
{
    public class GetAllItemView
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public int  CompanyId { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public string CompanyName { get; set; }

    }
}