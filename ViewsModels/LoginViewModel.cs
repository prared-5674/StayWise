using StayWise.Helpers;
using StayWise.Interfaces;
using StayWise.Model;
using StayWise.Views;
using StayWise.ViewsModels;
using System.Net;
using System.Security;
using System.Windows;
using System.Windows.Input;

public class LoginViewModel : MainViewModel
{
    private readonly IUserRepository userRepository;

    public string Username { get; set; }
    public SecureString Password { get; set; }
    public string ErrorMessage { get; set; }
    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        userRepository = new UserRepository();
        LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        System.Diagnostics.Debug.WriteLine("LoginViewModel initialized");
    }

    private bool CanExecuteLogin()
    {
        var canExecute = !string.IsNullOrWhiteSpace(Username) &&
                        Username.Length >= 3 &&
                        Password != null &&
                        Password.Length >= 3;
        System.Diagnostics.Debug.WriteLine($"CanExecuteLogin: {canExecute}");
        return canExecute;
    }

    private void ExecuteLogin()
    {
        System.Diagnostics.Debug.WriteLine("ExecuteLogin called");
        var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));

        if (isValidUser)
        {
            var dashboardView = new DashBoardView();
            dashboardView.Show();
            Application.Current.Windows.OfType<LoginView>().FirstOrDefault()?.Close();
        }
        else
        {
            ErrorMessage = "* Invalid username or password";
        }
    }
}