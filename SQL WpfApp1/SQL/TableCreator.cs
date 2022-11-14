using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace SQL_WpfApp1.SQL
{
    internal class TableCreator
    {

        public void CreateTable(string TableName)
        {
            using (System.Data.IDbConnection connection = new SqlConnection(Helper.CnnVal("InvDatabase2DB")))
            {
                string tablecreate; 
                tablecreate = $"CREATE TABLE {TableName} " +
                  " (NumberOfChanges " +
                  "int, " +
                  "ProductName nvarchar(50), " +
                  "ProducID nvarchar(30), " +
                  "ProducUnicode nvarchar(100), " +
                  "LastChage nvarchar(50)) ";
                SqlCommand CreateProcedureCommand = new SqlCommand(tablecreate);
                connection.Execute(tablecreate);


            }
        }
    }
}
