using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace personalAccounting
{
    public partial class DepositWindow : Window
    {
        private const int SERVER_PORT = 8888;
        private const string SERVER_IP = "127.0.0.1";

        public DepositWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(AmountBox.Text) ||
                    string.IsNullOrWhiteSpace(RateBox.Text) ||
                    string.IsNullOrWhiteSpace(MonthsBox.Text))
                {
                    MessageBox.Show("Заповніть всі поля!", "Помилка");
                    return;
                }

                string message = $"{AmountBox.Text}|{RateBox.Text}|{MonthsBox.Text}";

                using (TcpClient client = new TcpClient(SERVER_IP, SERVER_PORT))
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    byte[] responseData = new byte[256];
                    int bytes = stream.Read(responseData, 0, responseData.Length);
                    string response = Encoding.UTF8.GetString(responseData, 0, bytes);

                    ResultText.Text = $"{response} UAH";
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("Не вдалося підключитися до Банківського сервера.\nПереконайтеся, що програма 'BankServer' запущена!", "Помилка мережі");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка");
            }
        }
    }
}