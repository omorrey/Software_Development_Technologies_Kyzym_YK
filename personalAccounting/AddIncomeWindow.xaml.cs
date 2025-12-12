using System.Windows;
using System.Windows.Controls;
using personalAccounting.Models;
using personalAccounting.Patterns.Facade;

namespace personalAccounting
{
    public partial class AddIncomeWindow : Window
    {
        private readonly AccountingFacade _facade;
        private const int CurrentAccountId = 1;
        public AddIncomeWindow()
        {
            InitializeComponent();
            _facade = new AccountingFacade();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(AmountBox.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Будь ласка, введіть коректну суму.", "Помилка");
                return;
            }

            string category = (CategoryBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string description = DescriptionBox.Text;

            bool success = _facade.AddTransaction(amount, category, description, Transaction.TransactionType.Income, CurrentAccountId);

            if (success)
            {
                MessageBox.Show("Дохід успішно додано!", "Успіх");
                this.Close();
            }
            else
            {
                MessageBox.Show("Помилка при збереженні.", "Помилка");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}