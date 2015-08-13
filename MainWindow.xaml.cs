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

namespace Buttons
{
    using System.Diagnostics;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ButtonsConfig config)
        {
            this.InitializeComponent();

            if (config == null) return;

            if (config.WindowWidth > 0)
            {
                this.Width = config.WindowWidth;
            }
            if (config.WindowHeight > 0)
            {
                this.Height = config.WindowHeight;
            }
            if (!string.IsNullOrEmpty(config.BackgroundColor))
            {
                this.Background = new BrushConverter().ConvertFromString(config.BackgroundColor) as SolidColorBrush;
            }
            if (!string.IsNullOrEmpty(config.Title))
            {
                this.Title = config.Title;
            }
            this.ApplicationMessage.Content = config.ApplicationMessage;
            this.AppsButtons.ItemsSource = config.Buttons;
        }

        void BtnOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var btn = (Button)sender;
            var applicationButton = (ApplicationButton)btn.DataContext;
            if (!string.IsNullOrWhiteSpace(applicationButton.ApplicationPath))
            {
                var psi = new ProcessStartInfo { FileName = applicationButton.ApplicationPath };
                Process.Start(psi);
            }
        }
    }
}
