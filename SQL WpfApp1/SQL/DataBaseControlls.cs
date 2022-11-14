using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using SQL_WpfApp1.SQL;

namespace SQL_WpfApp1.SQL
{
    internal class DataBaseControlls
    {
        public async Task CreateDataBase()
        {
            AccessData db = new AccessData();

            try
            {
                db.CreateDataBase();
                MessageBox.Show("DataBase is Created Successfully", "MyProgram");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram");
            }
        }
        public async Task CreateTable()
        {
            TableCreator db = new TableCreator();
            try
            {
                db.CreateTable("People");
                MessageBox.Show("Table Created Successfully", "MyProgram");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram");
            }
        }
        public async Task CreateProcedures()
        {
            ProcedureCreator ins = new ProcedureCreator();
            try
            {

                ins.AddIntoTable();
                ins.EditTable();
                MessageBox.Show("Procedures Created Successfully", "MyProgram");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram");
            }
        }

        public async Task StartUp()
        {
            Task first = CreateDataBase();
            await first;
            Task second = CreateTable();
            await Task.WhenAll(first, second);
            Task third = CreateProcedures();
        }
    }
}
