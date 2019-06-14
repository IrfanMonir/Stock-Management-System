using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using StockManagementWebApp.BLL.Models;

namespace StockManagementWebApp.DAL
{
    public class ItemGateway : BaseGateway
    {
        public List<SummaryViewByCategory> GetAllSummaryByCategory(string category)
        {
            string query = "SELECT * FROM SummaryViewByCategory WHERE Category = '"+category+"'";

            Command = new SqlCommand(query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<SummaryViewByCategory> summaryViewByCategories = new List<SummaryViewByCategory>();
            while (Reader.Read())
            {
                SummaryViewByCategory summaryView = new SummaryViewByCategory();
                summaryView.Item = Reader["Item"].ToString();
                summaryView.Company = Reader["Company"].ToString();
                summaryView.Category = Reader["Category"].ToString();

                summaryView.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                summaryView.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                summaryViewByCategories.Add(summaryView);
            }
            Connection.Close();
            return summaryViewByCategories;
        }

        public List<SummaryView> GetAllSummaryByCompany(string company)
        {
           // SELECT * FROM SummaryView WHERE	Company = 'Nova'
            string query = "SELECT * FROM SummaryView WHERE	Company = '"+company+"'";

            Command = new SqlCommand(query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<SummaryView> companyList = new List<SummaryView>();
            while (Reader.Read())
            {
                SummaryView summaryView = new SummaryView();
                summaryView.Item = Reader["Item"].ToString();
                summaryView.Company = Reader["Company"].ToString();
                summaryView.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                summaryView.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
               
                companyList.Add(summaryView);
            }
            Connection.Close();
            return companyList;
        }

        public List<SummaryView> GetAllSummary()
        {
            string query = "SELECT * FROM SummaryView";
            Command = new SqlCommand(query, Connection);

            Connection.Open(); 
            Reader = Command.ExecuteReader();
            List<SummaryView> companyList = new List<SummaryView>();
            while (Reader.Read())
            {
                SummaryView summaryView = new SummaryView();
                summaryView.Item = Reader["Item"].ToString();
                summaryView.Company = Reader["Company"].ToString();
                summaryView.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                summaryView.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                companyList.Add(summaryView);
            }
            Connection.Close();
            return companyList;
        }
      
        public int SaveItem(Item item)
        {
            string query = "INSERT INTO Item(CategoryId,CompanyId,Name,ReorderLevel) VALUES (" + item.CategoryId + "," + item.CompanyId + ",'" + item.Name + "',"+item.ReorderLevel+")";
             Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }

        public List<Company> GetAllCompany()
        {
            string query = "SELECT * FROM Company";
             Command = new SqlCommand(query, Connection);

            Connection.Open();
             Reader = Command.ExecuteReader();
            List<Company> companyList = new List<Company>();
            while (Reader.Read())
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(Reader["Id"]);
                company.Name = Reader["Name"].ToString();
                companyList.Add(company);
            }
            Connection.Close();
            return companyList;
        }
        public List<Category> GetAllCategory()
        {
           
            string query = "SELECT * FROM Category";
             Command = new SqlCommand(query, Connection);


            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Category> categoryList = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(reader["Id"]);
                category.Name = reader["Name"].ToString();
                categoryList.Add(category);
            }
            Connection.Close();
            return categoryList;
        }
        public bool IsItemExist(string Name)
        {
            SqlConnection connection = new SqlConnection(connectionStirng);
            string query = "SELECT * FROM Item WHERE Name = '" + Name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            bool isItemExist = reader.HasRows;
            connection.Close();

            return isItemExist;
        }


        public List<SummaryViewByCategory> GetSummaryByBoth(string company, string category)
        {
           // SELECT * FROM SummaryViewByCategory WHERE Company = 'Unilever' and Category = 'Electronics'
            string query = "SELECT * FROM SummaryViewByCategory WHERE Company = '"+company+"' and Category = '"+category+"'";
            Command = new SqlCommand(query, Connection);
            
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<SummaryViewByCategory> bothSummaryList = new List<SummaryViewByCategory>();
            while (reader.Read())
            {
                SummaryViewByCategory bothSummary = new SummaryViewByCategory();
                bothSummary.Item = reader["Item"].ToString();
                bothSummary.Company = reader["Company"].ToString();
                bothSummary.Category = reader["Category"].ToString();

                bothSummary.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                bothSummary.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);

                bothSummaryList.Add(bothSummary);
            }
            Connection.Close();
            return bothSummaryList;
        }
    }
}