using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Buttons
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_OnStartup(object sender, StartupEventArgs e)
        {
            var configFile = e.Args.Length == 1 ? e.Args[0] : "buttons.btxml";
            var config = ButtonsConfig.LoadFile(configFile);

            var mainWindow = new MainWindow(config);
            mainWindow.Show();
        }
    }
}
