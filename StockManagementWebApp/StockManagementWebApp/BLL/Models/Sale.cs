using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.BLL.Models
{
    public class Sale
    {
       
        public string Item { get; set; }
        public string Company { get; set; }
        public int SaleQuantity { get; set; }
    }
}