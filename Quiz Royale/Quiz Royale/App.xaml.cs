using Quiz_Royale.Base;
using Quiz_Royale.DataAccess.API;
using Quiz_Royale.Storage;
using Quiz_Royale.ViewModels;
using Quiz_Royale.Views;
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
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationStore = new NavigationStore();

            var splashScreen = new Splashscreen();
            MainWindow = splashScreen;
            splashScreen.Show();

            Task.Factory.StartNew(async () => {
                await Initialize(navigationStore);

                Dispatcher.Invoke(() =>
                {
                    MainWindow = new MainWindow()
                    {
                        DataContext = new MainWindowViewModel(navigationStore)
                    };
                    MainWindow.Show();
                    splashScreen.Close();
                    base.OnStartup(e);
                });
            });
        }

        protected override void OnExit(ExitEventArgs e)
        {
            LocalStorage.Save();
            base.OnExit(e);
        }

        // Zorgt ervoor dat alle benodigde data wordt verwerkt en geïnitaliseerd
        private async Task Initialize(NavigationStore navigationStore)
        {
            // Controleer of de gebruiker al een account heeft, dit is het geval wanneer er een access token aanwezig is
            if (LocalStorage.Settings.Credentials?.AccessToken != null)
            {
                try
                {
                    await InitializeData();
                    navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
                }
                catch (Exception)
                {
                    navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
                    navigationStore.Error = "Cannot connect to the server. Please try again";
                }
            }
            else
            {
                navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
            }
        }

        // Probeert de app naar de homepagina te sturen als dit mogelijk is, als dit niet mogelijk is dan komt de app op de login pagina
        private async Task InitializeData()
        {
            await new APIAccountProvider().GetAccount();
        }
    }
}
