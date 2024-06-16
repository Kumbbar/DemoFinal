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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = Requests.ReqObj.Users.Where(svo => svo.Login == LoginTxt.Text && svo.Password == PasswordTxt.Password).FirstOrDefault();
            if (user != null) {
                Window window = new MainWindow(user);
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильно да");
            }

        }
    }
}
