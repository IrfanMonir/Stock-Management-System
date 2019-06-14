using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.BLL.Models
{
    public class StockOut
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int StockOutQuantity { get; set; }
    }
}