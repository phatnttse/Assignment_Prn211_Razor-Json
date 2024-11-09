using Assignment_Services.Interfaces;
using System.Windows;

namespace Assignment_WPFApp
{
    public partial class SignUp : Window
    {
        private readonly IAuthService _authService;

        public SignUp(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var name = NameInput.Text;
            var email = EmailInput.Text;
            var password = PasswordInput.Password;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ErrorMessage.Text = "All fields are required!";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            var result = await _authService.SignUp(name, email, password);

            if (result.Succeeded)
            {
                MessageBox.Show("Sign up successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); 
            }
            else
            {
                ErrorMessage.Text = result.Message;
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
