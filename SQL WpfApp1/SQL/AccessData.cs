using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace SQL_WpfApp1.SQL
{
    class AccessData
    {
        public string Choice;
        public string countNumber;
        public void CreateDataBase()
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "CREATE DATABASE InvDatabase2 ON PRIMARY " +
                "(NAME = InvDatabase, " +
                "FILENAME = 'e:\\InvDatabase2.mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
                "LOG ON (NAME = InvDatabase2_Log, " +
                "FILENAME = 'e:\\InvDatabase2.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        public List<Product> GetProduct(string lastName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("InvDatabase2DB")))
            {
                var output = connection.Query<Product>($"SELECT * FROM People where {Choice} LIKE '%{lastName}%'").ToList();
                //Next one is the same but uses a stored procedure, use interchangeably
                //var output = connection.Query<Person>("dbo.People_GetByLastName @LastName", new { LastName = lastName }).ToList();
                return output;

            }
        }

        internal void InsertProduct(string productName, string producID, string producHashCode, string lastChage)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("InvDatabase2DB")))
            {
                List<Product> people = new List<Product>();
                people.Add(new Product
                {
                    ProductName = productName,
                    ProducID = producID,
                    ProducUnicode = producHashCode,
                    LastChage = lastChage
                });
                connection.Execute("dbo.Product_Insert @ProductName, @ProducID, @ProducUnicode, @LastChage", people);

            }
        }

        internal void EditProduct(string productName, string producID, string timeNow)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("InvDatabase2DB")))
            {
                connection.Execute("dbo.Product_Edit @ProductName = '"+productName+"', @ProducID = "+producID+ ", @LastChage = '" + timeNow+ "' ");
            }
        }


    }
}
