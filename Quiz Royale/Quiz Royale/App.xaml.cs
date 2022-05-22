using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Quiz_Royale
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            NavigationStore store = new NavigationStore();

            MainWindow = new MainWindow() {
                DataContext = new MainWindowViewModel(store)
        };
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
