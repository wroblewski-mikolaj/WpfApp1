using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace SQL_WpfApp1.SQL
{
    class ProcedureCreator
    {
        internal void AddIntoTable()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("InvDatabase2DB")))
            {
                string tableProcedure;
                tableProcedure = "CREATE PROCEDURE dbo.Product_Insert @ProductName nvarchar(50), @ProducID nvarchar(30), @ProducUnicode nvarchar(100), @LastChage nvarchar(50) " +
                    "AS " +
                    "BEGIN " +
                    "SET NOCOUNT ON; " +
                    "INSERT INTO dbo.People(NumberOfChanges, ProductName, ProducID, ProducUnicode, LastChage) " +
                    "VALUES(1, @ProductName, @ProducID, @ProducUnicode, @LastChage) " +
                    "END ";
                SqlCommand CreateProcedureCommand = new SqlCommand(tableProcedure);
                connection.Execute(tableProcedure);
            }
        }
        internal void EditTable()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("InvDatabase2DB")))
            {
                string tableProcedure;
                tableProcedure = "CREATE PROCEDURE dbo.Product_Edit @LastChage nvarchar(50), @ProductName nvarchar(50), @ProducID nvarchar(30) " +
                    "AS " +
                    "BEGIN " +
                    "SET NOCOUNT ON; " +
                    "UPDATE dbo.People " +
                    "SET NumberOfChanges = NumberOfChanges+1, ProductName = @ProductName, LastChage = @LastChage " +
                    "WHERE ProducID = @ProducID " +
                    "END ";
                SqlCommand CreateProcedureCommand = new SqlCommand(tableProcedure);
                connection.Execute(tableProcedure);
            }
        }


    }
}
