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
using SQL_WpfApp1.SQL;
using System.Globalization;

namespace SQL_WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string _productsTotal = "0";
        public string _dayDate = DateTime.Now.ToString("dddd d", CultureInfo.InvariantCulture);
        public string _monthDate = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
        public int _yearDate = DateTime.Now.Year;


        public MainWindow()
        {
            InitializeComponent();
            Window.Content = new Page2();
            DataContext = this;
            PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }
        public int yearDate
        {
            get { return _yearDate; }
            set { _yearDate = value; }
        }
        public string monthDate
        {
            get { return _monthDate; }
            set { _monthDate = value; }
        }
        public string dayDate
        {
            get { return _dayDate; }
            set { _dayDate = value; }
        }
        public string productsTotal
        {
            get { return _productsTotal; }
            set { _productsTotal = value; }
        }
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void Border_MouseDown(object sender, RoutedEventArgs e)
        {
            
        }

        private void InfoUser_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void InfoUser_Loaded_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.Content = new Page1();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnClickList(object sender, RoutedEventArgs e)
        {
            Window.Content = new Page2();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window.Content = new Page3();
        }
    }
}