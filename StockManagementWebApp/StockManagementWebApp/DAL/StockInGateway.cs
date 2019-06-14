using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementWebApp.BLL.Models;

namespace StockManagementWebApp.DAL
{
    public class StockInGateway : BaseGateway
    {
        public int SaveStockIn(StockIn stockIn)
        {
            string query = "INSERT INTO StockIn (ItemId, AvailableQuantity) VALUES (" + stockIn.ItemId + "," + stockIn.AvailableQuantity + ")";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<GetAllItemView> GetAllItemByCompany(int company)
        {
            
            string query = " SELECT * FROM GetAllItemView WHERE CompanyId = "+company;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<GetAllItemView> itemList = new List<GetAllItemView>();

            while (Reader.Read())
            {
                GetAllItemView itemView = new GetAllItemView();
                itemView.ItemId = Convert.ToInt32(Reader["ItemId"]);
                itemView.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                itemView.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                itemView.ItemName = Reader["ItemName"].ToString();
                itemView.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                itemView.CompanyName = Reader["CompanyName"].ToString();

                itemList.Add(itemView);
            }
            Connection.Close();

            return itemList;
        }

        public int GetReorderLevel(int Id)
        {
            string query = "SELECT ReorderLevel FROM Item WHERE Id = "+Id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Item item = null;

            if (Reader.Read())
            {
                 item = new Item();
               
                item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
            }
            Connection.Close();
            return item.ReorderLevel;
        }

        public bool IsNullAvailableQuantity(int Id)
        {
            //SELECT Item.Id as ItemId, AvailableQuantity FROM StockIn FULL JOIN Item on Item.Id = StockIn.ItemId
            //WHERE AvailableQuantity IS NULL and ItemId =1;
            string query = "SELECT * FROM  IsNullView WHERE ItemId = " + Id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isNullAvailableQuantity = Reader.HasRows;
            Connection.Close();
            return isNullAvailableQuantity;
        }

        public int GetAvailableQuantity(int Id)
        {
            //SELECT Sum(AvailableQuantity) as AvailableQuantity FROM Item FULL JOIN StockIn 
            //on Item.Id = StockIn.ItemId WHERE StockIn.ItemId = 12
            string query = "SELECT Sum(AvailableQuantity) as AvailableQuantity FROM Item INNER JOIN StockIn   on Item.Id = StockIn.ItemId WHERE StockIn.ItemId = " + Id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
           
            int availableQuantity=0; 
            if (Reader.Read())
            {
               availableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);

            }
            Connection.Close();
          return availableQuantity;
        }

        public int UpdateAvailableQuantityByItem(StockIn stockIn)
        {
            //UPDATE StockIn SET AvailableQuantity = 1 WHERE ItemId = 1
            string query = "UPDATE StockIn SET AvailableQuantity = "+stockIn.AvailableQuantity+" WHERE ItemId = "+ stockIn.ItemId;
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsItemExist(int Id)
        {
            string query = "SELECT * FROM StockIn FULL JOIN Item on Item.Id = StockIn.ItemId WHERE  ItemId ="+Id;
            Command = new SqlCommand(query, Connection);
            
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isItemExist = Reader.HasRows;
            Connection.Close();
            return isItemExist;
           
        }

      }
}