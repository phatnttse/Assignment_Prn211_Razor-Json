using Assignment_Services;
using Assignment_Services.Interfaces;
using Assignment_BusinessObjects;
using System.Windows;
using System.Windows.Controls;
using Microsoft.AspNetCore.Identity;


namespace Assignment_WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAuthService _authService;

        public MainWindow()
        {

        }

        public MainWindow(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Gọi phương thức đăng nhập từ dịch vụ
            var result = await _authService.SignIn(username, password);

            if (result.Succeeded)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // Đóng cửa sổ SignIn
            }
            else
            {
                ErrorMessage.Text = "Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin.";
            }
        }
    }
}