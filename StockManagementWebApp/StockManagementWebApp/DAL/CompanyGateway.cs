using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementWebApp.BLL.Models;

namespace StockManagementWebApp.DAL
{
    public class CompanyGateway : BaseGateway
    {

        public int SaveCompany(Company company)
        {
            string query = "INSERT INTO Company VALUES ('" + company.Name + "')";
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

        public bool IsCompanyExist(string Name)
        {

            string query = "SELECT * FROM Companies WHERE Name = '" + Name + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();


            bool isCompanyExist = Reader.HasRows;
            Connection.Close();

            return isCompanyExist;
        }
    }
}