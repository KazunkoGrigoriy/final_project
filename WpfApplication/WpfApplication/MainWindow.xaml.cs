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
        private string _comboBoxItemText = "";
        private int _idSelectedItem = 0;
        private IEnumerable<Request> _requests;
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
                btnChangeStatus.IsEnabled = true;
                dataGridRequest.ItemsSource = _requests = DataRequest.GetRequests();
                if (_loginWindow.GetStatus() == UserRoles.Administrator)
                {
                    lbUser.Content = "Admin";
                    btnMainLogin.Content = "Выход";
                }
                if (_loginWindow.GetStatus() == UserRoles.Manager)
                {
                    lbUser.Content = "Manager";
                    btnMainLogin.Content = "Выход";
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
            else
            {
                _loginWindow.ResetStatus();
                lbUser.Content = null;
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            _comboBoxItemText = comboBox.Text;
            _idSelectedItem = dataGridRequest.SelectedIndex;
            //MessageBox.Show(e.OriginalSource.ToString());
        }
        private void btnChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            if (_loginWindow.GetStatus() == UserRoles.Administrator)
            {
                Request request = _requests.Where(x => x.Id == _idSelectedItem + 1).FirstOrDefault();
                if (request.Status != null)
                {
                    if(request.Status != _comboBoxItemText)
                    {
                        request.Status = _comboBoxItemText;
                        MessageBox.Show(DataRequest.Update(request));
                    }
                }
            }
        }

        private int GetIdRequest(int idDataGrid)
        {
            return -1;
        }
    }
}
