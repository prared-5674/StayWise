using PropertyChanged;
using StayWise.Helpers;
using StayWise.Interfaces;
using StayWise.Model;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Windows.Input;

namespace StayWise.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : MainViewModel
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;

        private IUserRepository userRepository;

        public string Username { get; set; }

        public SecureString Password { get; set; }

        public string ErrorMessage { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }
    }
}
