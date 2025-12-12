using System.Windows;
using personalAccounting.Repositories;

namespace personalAccounting
{
    public partial class RegisterWindow : Window
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = RegUsernameBox.Text;
            string email = RegEmailBox.Text;
            string password = RegPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля!");
                return;
            }

            if (!email.Contains("@") || email.Length < 3)
            {
                MessageBox.Show("Введіть коректний Email.");
                return;
            }

            bool success = _userRepo.Register(username, password, email);

            if (success)
            {
                MessageBox.Show("Акаунт створено успішно! Тепер увійдіть.");

                LoginWindow login = new LoginWindow();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Помилка реєстрації. Можливо, такий Email або Логін вже зайняті.");
            }
        }

        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}