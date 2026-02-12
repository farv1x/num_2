using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    public partial class auth : Window
    {
        public static int UserID;
        public auth()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = log.Text;
            string password = pass.Password;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
                return;
            }
            using (var context = new user42_dbEntities1())
            {
                var user = context.Employee_s.FirstOrDefault(u => u.login == login);
                if (user == null && password != user.password)
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль");
                    return;
                }
                UserID = user.id;

                if (user.id_position == 2)
                {
                    var dir = new MainWindow();
                    dir.Show();
                    this.Close();
                }
                else 
                {
                    var win = new Client();
                    win.Show();
                    this.Close();
                }


            }
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
