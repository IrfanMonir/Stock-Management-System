using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.BLL.Models
{
    [Serializable]
    public class StockOutData
    {
        public string Item { get; set; }
        public int ItemId { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
    }
}