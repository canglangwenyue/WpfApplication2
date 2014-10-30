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
using System.Windows.Forms;
using StuSystem;

namespace WpfApplication2
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {         
            Student student = new Student();
            student.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Classes classes = new Classes();

            classes.Show();
           
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Score score = new Score();

            score.Show();
           
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Course course = new Course();

            course.Show();
           
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Users users = new Users();

            users.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }
    }
}
