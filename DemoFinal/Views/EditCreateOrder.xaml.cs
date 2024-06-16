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
using System.Windows.Shapes;
using DemoFinal.Database;

namespace DemoFinal.Views
{
    /// <summary>
    /// Логика взаимодействия для EditOrder.xaml
    /// </summary>
    public partial class EditCreateOrder : Window
    {
        Orders order;
        MainWindow main;
        bool IsAdd;
        public EditCreateOrder(MainWindow main, Orders order = null)
        {
            if (order == null)
            {
                order = new Orders();
                this.IsAdd = true;
            }
            else
            {
                this.IsAdd = false;
            }
            this.order = order;
            this.main = main;
            InitializeComponent();
            TypeCMB.ItemsSource = Requests.ReqObj.ElectronicType.ToList();
            TypeCMB.SelectedValuePath = "Id";
            TypeCMB.DisplayMemberPath = "name";
            if (this.main.user.Type == "Менеджер")
            {
                TypeLabel.Visibility = Visibility.Collapsed;
                TypeCMB.Visibility = Visibility.Collapsed;
                MessageBox.Show("asd");
            }

            TypeCMB.SelectedValue = this.order.ElectronicTypeId;
            FIOTxt.Text = this.order.FIO;
            ModelNameTxt.Text = this.order.ElectronicModel;
            StatusCMB.Text = this.order.OrderStatus;
            PhoneTxt.Text = this.order.Phone;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            order.FIO = FIOTxt.Text;
            order.ElectronicModel = ModelNameTxt.Text;
            order.OrderStatus = StatusCMB.Text;
            order.ElectronicTypeId = (int)TypeCMB.SelectedValue;
            order.Phone = PhoneTxt.Text;
            if (this.IsAdd) Requests.ReqObj.Orders.Add(order);
            Requests.ReqObj.SaveChanges();
            this.main.RefreshData();
            Close();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Requests.ReqObj.Orders.Remove(order);
            Requests.ReqObj.SaveChanges();
            this.main.RefreshData();
            Close();
        }
    }
}
