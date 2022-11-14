using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SQL_WpfApp1.SQL
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["InvDatabase2DB"].ConnectionString;
        }
    }
}
