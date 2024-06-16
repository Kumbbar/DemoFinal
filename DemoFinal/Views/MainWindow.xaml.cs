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
using DemoFinal.Database;

namespace DemoFinal.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Users user;
        public MainWindow(Users user)
        {
            this.user = user;
            InitializeComponent();
            OrdersDtGr.ItemsSource = Requests.ReqObj.Orders.ToList();
        }

        public void RefreshData()
        {
            OrdersDtGr.ItemsSource = Requests.ReqObj.Orders.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = (Orders)(sender as Button).DataContext;
            Window window = new EditCreateOrder(this, currentUser);
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = new Login();
            window.Show();
            this.Close();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new EditCreateOrder(this);
            window.Show();
        }
    }
}
