using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApplication.Data;
using WpfApplication.Model;
using WpfApplication.UserApp;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginWindow _loginWindow;
        private DataRequest _dataRequest = new DataRequest();
        public MainWindow()
        {
            InitializeComponent();
            using (DataUsers db = new DataUsers())
            {
                int length = db.Users.Count();
                if (length == 0)
                {
                    db.Users.Add(new User() { Login = "admin", Password = "admin", Role = UserRoles.Administrator });
                    db.Users.Add(new User() { Login = "user", Password = "user", Role = UserRoles.Manager});
                    db.SaveChanges();
                }
            }
            btnMainLogin.Click += btnMainLogin_Click;
            _loginWindow = new LoginWindow();
            _loginWindow.btnLogin.Click += BtnLogin_Click;   
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(_loginWindow.GetOk())
            {
                dataGridRequest.ItemsSource = _dataRequest.GetRequests();

                
                
                
                
                
                if (_loginWindow.GetStatus() == UserRoles.Administrator)
                {
                    btnMainLogin.Content = "Выход";
                }
                else
                {
                    
                }
            }
            else
            {
                _loginWindow.Close();
            }
        }

        private void btnMainLogin_Click(object sender, RoutedEventArgs e)
        {
            if (btnMainLogin.Content.ToString() != "Выход")
            {
                _loginWindow.Show();
            }     
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string comboBoxItemText = comboBox.Text;
            if(comboBoxItemText != "")
            {
                int id = dataGridRequest.SelectedIndex;
                Request request = (Request)_dataRequest.GetRequests().Where(x => x.Id == id).FirstOrDefault();
                _dataRequest.Update(request);

                //MessageBox.Show(comboBoxItemText);
            }
        }
    }
}
