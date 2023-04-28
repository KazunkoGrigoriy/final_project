using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows;
using WpfApplication.UserApp;
using WpfApplication.Data;
using System.Linq;
using System;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool _ok = false;
        private UserRoles _status = UserRoles.Manager;
        public LoginWindow()
        {
            InitializeComponent();
            btnExit.Click += BtnExit_Click;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxUserName.Text;
            string password = textBoxPassword.Password;
            
            using (DataUsers context = new DataUsers())
            {
                var user = context.Users.FirstOrDefault(t => t.Login == login && t.Password == password);
                if (user != null)
                {
                    _ok = true;
                    
                    if (user.Role == UserRoles.Administrator)
                    {
                        _status = UserRoles.Administrator;
                    }
                    else _status = UserRoles.Manager;

                    this.Close();
                }
                else MessageBox.Show("Неверные логин или пароль");
            }
        }

        public bool GetOk()
        {
            return _ok;
        }

        public UserRoles GetStatus()
        {
            return _status;
        }

        public void ResetStatus()
        {
            _status = UserRoles.Manager;
        }
    }
}
