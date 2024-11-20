using FontAwesome.Sharp;
using PropertyChanged;
using StayWise.Helpers;
using StayWise.Interfaces;
using StayWise.Model;
using StayWise.Views;
using System.Windows.Input;

namespace StayWise.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        private UserAccountModel _currentUserAccount;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount { get; set; }

        public string Caption { get; set; }

        public IconChar Icon { get; set; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername("admin");
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
            }
        }
    }
}
