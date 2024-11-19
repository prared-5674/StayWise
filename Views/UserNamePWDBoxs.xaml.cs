using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace StayWise.Views
{
    /// <summary>
    /// Interaction logic for UserNamePWDBoxs.xaml
    /// </summary>
    public partial class UserNamePWDBoxs : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
                    DependencyProperty.Register("Password", typeof(SecureString), typeof(UserNamePWDBoxs));

        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public UserNamePWDBoxs()
        {
            InitializeComponent();
            txtPassword.PasswordChanged += OnPasswordChanged;

        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = txtPassword.SecurePassword;
        }
    }
}
