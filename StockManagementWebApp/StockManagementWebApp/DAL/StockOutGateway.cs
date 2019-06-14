using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.BLL.Models;

namespace StockManagementWebApp.DAL
{
    public class StockOutGateway : BaseGateway
    {
        public int SaveStockOut(StockOut stockOut)
        {
            string query = "INSERT INTO StockOut (ItemId, Date, Type, StockOutQuantity) VALUES ("+stockOut.ItemId+",'"+stockOut.Date+"','"+stockOut.Type+"',"+stockOut.StockOutQuantity+")";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<Sale> GetAllSellByDate(string fromDate, string toDate)
        {
             string query = " SELECT I.Name AS Item, C.Name AS Company, StockOutQuantity as SaleQuantity FROM Company AS C FULL  JOIN Item AS I ON C.Id = I.CompanyId  FULL JOIN StockOut AS SO ON SO.ItemId = I.Id WHERE Type = 'Sell' AND (Date >= '"+fromDate+"' AND Date <= '"+toDate+"' ) ";
             Command = new SqlCommand(query, Connection);


            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Sale> saleList = new List<Sale>();
            while (reader.Read())
            {
                Sale sale = new Sale();
                sale.Item = reader["Item"].ToString();
                sale.Company = reader["Company"].ToString();
                sale.SaleQuantity = Convert.ToInt32(reader["SaleQuantity"]);
            
                saleList.Add(sale);
            }
            Connection.Close();
            return saleList;
        }
           
    }
}