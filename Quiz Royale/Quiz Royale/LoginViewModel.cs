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
            Login = new RelayCommand(async () => { await LoginUser(); });
        }

        private async Task LoginUser()
        {
            await CreateUser();
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        private async Task CreateUser()
        {
            TokenCredentials credentials = await _creator.CreateAccount(Username);
            Storage.Settings.Credentials = credentials;
        }
    }
}
