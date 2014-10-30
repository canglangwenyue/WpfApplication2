using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication2
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;
            MainWindow main = new MainWindow();
            bool? b = main.ShowDialog();
            if ((b.HasValue == true) && (b.Value == true))
            {
                Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
