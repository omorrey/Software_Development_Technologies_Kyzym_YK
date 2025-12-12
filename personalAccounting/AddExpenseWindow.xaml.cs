using personalAccounting.Models;
using personalAccounting.Patterns.Facade;
using personalAccounting.Services;
using System.Windows;
using System.Windows.Controls;

namespace personalAccounting
{
    public partial class AddExpenseWindow : Window
    {
        private readonly AccountingFacade _facade;
        private const int CurrentAccountId = 1;

        public AddExpenseWindow()
        {
            InitializeComponent();
            _facade = new AccountingFacade();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            int userId = UserSession.CurrentUserId;

            if (!decimal.TryParse(AmountBox.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Введіть коректну суму.", "Помилка");
                return;
            }

            string category = (CategoryBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string description = DescriptionBox.Text;

            bool success = _facade.AddTransaction(amount, category, description, Transaction.TransactionType.Expense, CurrentAccountId);

            if (success)
            {
                MessageBox.Show("Витрату додано!", "Успіх");
                this.Close();
            }
            else
            {
                MessageBox.Show("Помилка збереження.", "Помилка");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e) => Close();
    }
}