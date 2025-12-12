using System.Windows;
using personalAccounting.Repositories;
using personalAccounting.Services;

namespace personalAccounting
{
    public partial class LoginWindow : Window
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введіть логін та пароль");
                return;
            }

            var user = _userRepo.Login(username, password);
            if (user != null)
            {
                UserSession.CurrentUserId = user.UserId;
                UserSession.CurrentUserName = user.UserName;

                MainWindow main = new MainWindow();
                main.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль");
            }
        }

        private void OpenRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow regWindow = new RegisterWindow();
            regWindow.Show();
            this.Close(); 
        }
    }
}