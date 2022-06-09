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

        private string _errorMessage;

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public bool HasErrors
        {
            get
            {
                return !string.IsNullOrEmpty(ErrorMessage);
            }
        }

        public LoginViewModel(NavigationStore store) : base(store)
        {
            _creator = new APIAccountCreator();
            Login = new RelayCommand(async () => { await LoginUser(); }, CanLogin);
        }

        private async Task LoginUser()
        {
            try
            {
                await CreateUser();
                _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            }
            catch(ArgumentException)
            {
                ErrorMessage = "Username must be non empty and less than 20 characters";
            }
            catch (InvalidDataException)
            {
                ErrorMessage = "Username is already taken";
            }
            catch (Exception)
            {
                ErrorMessage = "Something went wrong";
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
