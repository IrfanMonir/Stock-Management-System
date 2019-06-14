using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementWebApp.BLL.Models;

namespace StockManagementWebApp.DAL
{
    public class CategoryGateway : BaseGateway
    {
        public int SaveCategory(Category category)
        {
            string query = "INSERT INTO Category VALUES ('" + category.Name + "')";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<Category> GetAllCategory()
        {
            string query = "SELECT * FROM Category";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Category> categoryList = new List<Category>();

            while (Reader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(Reader["Id"]);
                category.Name = Reader["Name"].ToString();
                
                categoryList.Add(category);
            }
            Connection.Close();

            return categoryList;
        }

        public bool IsCategoryExist(string Name)
        {

            string query = "SELECT * FROM Category WHERE Name = '" + Name + "'";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isCategoryExist = Reader.HasRows;
            Connection.Close();

            return isCategoryExist;
        }

        public Category GetCategoryById(int id)
        {
            string query = "SELECT * FROM Category WHERE Id =" + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Category category = null;

            if (Reader.Read())
            {
                category = new Category();
                category.Id = Convert.ToInt32(Reader["Id"]);
                category.Name = Reader["Name"].ToString();
               }
            Connection.Close();
            return category;
        }

        public int UpdateCategory(Category category)
        {
            string query = "UPDATE Category SET Name ='"+category.Name+" ' WHERE Id = "+category.Id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
    }
}