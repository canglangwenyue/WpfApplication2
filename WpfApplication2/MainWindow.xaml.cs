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
using SQLBase;
using WpfApplication2.DAL;

namespace WpfApplication2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SQL SQL = new SQL();
        UsersInfo usersinfo = new UsersInfo();

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            int count = SQL.GetSelectCount("Users", " and LoginName='" + textboxUsername.Text.Trim() + "' and LoginPwd='" + textboxPassword.Text.Trim() + "'");
            if (string.IsNullOrEmpty(textboxUsername.Text) || string.IsNullOrEmpty(textboxPassword.Text))
            {
                MessageBox.Show("用户名或密码不能为空！");
                return;
            }
            else if (count == 0)
            {
                MessageBox.Show("用户名或密码错误！");
                return;
            }
            else
            {
                usersinfo.GetOne(textboxUsername.Text);
                MessageBox.Show("登陆成功");
               // Main main = new Main();
                //main.Show();
                this.DialogResult = true;
                //this.Hide();
            }
        }

        private void cancle_Click(object sender, RoutedEventArgs e)
        {
            window.Close();
        }

        private void textboxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
