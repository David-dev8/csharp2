using Microsoft.Toolkit.Helpers;
using Quiz_Royale.Base;
using Quiz_Royale.DataAccess;
using Quiz_Royale.DataAccess.API;
using Quiz_Royale.Exceptions;
using Quiz_Royale.Models.Items;
using Quiz_Royale.Models.User;
using Quiz_Royale.Storage;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz_Royale.ViewModels
{
    /// <summary>
    /// Deze klasse dient als de ViewModel voor de login.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        private IAccountCreator _creator;
        private Account _account;

        public string Username { get; set; }

        public RelayCommand Login { get; set; }

        /// <summary>
        /// Creëert een LoginViewModel met een navigationStore.
        /// </summary>
        /// <param name="navigationStore">De navigationStore die wordt gebruikt voor navigatie.</param>
        public LoginViewModel(NavigationStore store) : base(store)
        {
            _creator = new APIAccountCreator();
            Login = new RelayCommand(async () =>
            {
                await LoginUser();
            }, CanLogin);
        }

        // Probeert een account aan te maken voor de gebruiker.
        // De hiervoor opgegeven username, die is opgeslagen in de Username property, zal hiervoor worden gebruikt.
        private async Task LoginUser()
        {
            try
            {
                await CreateUser();
                _account = await new APIAccountProvider().GetAccount();
                _account.Inventory.PropertyChanged += Inventory_PropertyChanged;
                NavigateToHome();
            }
            catch(ArgumentException)
            {
                _navigationStore.Error = "Username must be non empty and less than 20 characters";
            }
            catch(InvalidDataException)
            {
                _navigationStore.Error = "Username is already taken";
            }
            catch(Exception)
            {
                _navigationStore.Error = "Something went wrong";
            }
        }

        // Navigeer naar de homepagina
        private void Inventory_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NavigateToHome();
        }

        // Navigeer naar de homepagina
        private void NavigateToHome()
        {
            if(_account.Inventory.ActiveBorder != null)
            {
                _account.Inventory.PropertyChanged -= Inventory_PropertyChanged;
                _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            }
        }

        // Zorgt ervoor dat een gebruiker geregistreerd wordt.
        private async Task CreateUser()
        {
            TokenCredentials credentials = await _creator.CreateAccount(Username);
            LocalStorage.Settings.Credentials = credentials;
        }

        // Controleert of een gebruiker een account aan mag maken.
        // Daarvoor moet er een gebruikersnaam zijn opgegeven die niet leeg is.
        private bool CanLogin(object o)
        {
            return !string.IsNullOrEmpty(Username);
        }
    }
}
