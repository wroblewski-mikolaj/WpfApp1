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

namespace SQL_WpfApp1
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        string productID = "";
        object item = "";
        public string productsTotalNumber = "";


        List<Product> people = new List<Product>();
        public Page2()
        {
            InitializeComponent();
            UpdateBinding();
            SearchRefresh();
        }
        private void UpdateBinding()
        {
            dataGrid.ItemsSource = people;
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            DataBaseControlls dbC = new DataBaseControlls();
            dbC.StartUp();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchRefresh();
        }
        public void SearchRefresh()
        {
            try
            {
                AccessData db = new AccessData();
                db.Choice = "ProductName";
                people = db.GetProduct("");
                UpdateBinding();
                if (people.Count == 0)
                {
                    MessageBox.Show("No products found. Add new products");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("First Run. Create a new database using a red button named \"Create Database\"", "CoolProgram");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void EditProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try {
                string time = DateTime.Now.ToString();
                AccessData db = new AccessData();
            db.EditProduct(ProducName.Text, ProducID.Text, time);
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "CoolProgram");
            }
}

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            item = dataGrid.SelectedItem;
            if (item != null)
            {
                productID = (dataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                ProducID.Text = productID;
            }
            
        }
    }
}
