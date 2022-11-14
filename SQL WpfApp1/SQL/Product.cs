using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_WpfApp1.SQL
{
    public class Product
    {
        public int NumberOfChanges { get; set; }
        public string ProductName { get; set; }
        public string ProducID { get; set; }
        public string ProducUnicode { get; set; }
        public string LastChage { get; set; }


        public string FullInfo
        {
            get
            {
                return $"{NumberOfChanges} {ProductName} {ProducID} [{ProducUnicode}] <{LastChage}>";
            }
        }

    }
}
