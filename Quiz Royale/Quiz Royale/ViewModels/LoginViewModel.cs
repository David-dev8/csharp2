using Quiz_Royale.DataAccess;
using Quiz_Royale.DataAccess.API;
using Quiz_Royale.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class LoginViewModel : BaseViewModel
    {
        private IAccountCreator _creator;

        public string Username { get; set; }

        public RelayCommand Login { get; set; }

        public LoginViewModel(NavigationStore store) : base(store)
        {
            _creator = new APIAccountCreator();
            Login = new RelayCommand(async () => { 
                await LoginUser();
            }, CanLogin);
        }

        private async Task LoginUser()
        {
            try
            {
                await CreateUser();
                Account acocunt = await new APIAccountProvider().GetAccount();
                _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            }
            catch(ArgumentException)
            {
                _navigationStore.Error = "Username must be non empty and less than 20 characters";
            }
            catch (InvalidDataException)
            {
                _navigationStore.Error = "Username is already taken";
            }
            catch (Exception)
            {
                _navigationStore.Error = "Something went wrong";
            }
        }

        private async Task CreateUser()
        {
            TokenCredentials credentials = await _creator.CreateAccount(Username);
            Storage.Settings.Credentials = credentials;
        }

        private bool CanLogin(object o)
        {
            return !string.IsNullOrEmpty(Username);
        }
    }
}
