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
using System.Data.SqlClient;
using SQL_WpfApp1.SQL;


namespace SQL_WpfApp1
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void nameTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void IdTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextbox.Text;
            string codeNumber = Convert.ToBase64String(Encoding.Unicode.GetBytes(name));
            string dateTime = DateTime.Now.ToString();

            try
            {
                AccessData db = new AccessData();
                db.InsertProduct(nameTextbox.Text, IdTextbox.Text, codeNumber, dateTime);

                IdTextbox.Clear();
                nameTextbox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram");
            }
        }
    }
}
