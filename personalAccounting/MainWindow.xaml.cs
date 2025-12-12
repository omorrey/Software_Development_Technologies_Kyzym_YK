using personalAccounting.Patterns.Facade;
using personalAccounting.Repositories;
using personalAccounting.Services;
using System.Windows;

namespace personalAccounting
{
    public partial class MainWindow : Window
    {
        private readonly AccountingFacade _facade;
        private readonly FundRepository _fundRepository;
        private const int CurrentUserId = 1;
        private const int TestAccountId = 1;
        private const int TestFundId = 1;

        public MainWindow()
        {
            InitializeComponent();
            _facade = new AccountingFacade();
            _fundRepository = new FundRepository();

            LoadTotalCapital();
        }

        private void LoadTotalCapital()
        {
            int userId = UserSession.CurrentUserId;
            decimal totalCapital = _facade.GetTotalCapital(userId);
            TotalCapitalText.Text = $"{totalCapital:F2} UAH";

            var fund = _fundRepository.GetById(1);
            if (fund != null)
            {
                FundBalanceText.Text = $"{fund.Balance:F2} UAH";
            }
            else
            {
                FundBalanceText.Text = "Не знайдено";
            }
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            AddExpenseWindow expenseWindow = new AddExpenseWindow();
            expenseWindow.ShowDialog();
            LoadTotalCapital();
        }

        private void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            AddIncomeWindow incomeWindow = new AddIncomeWindow();
            incomeWindow.ShowDialog();
            LoadTotalCapital();
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statsWindow = new StatisticsWindow();
            statsWindow.ShowDialog();
        }

        private void TopUpFund_Click(object sender, RoutedEventArgs e)
        {
            decimal amount = 500.00m;

            bool success = _facade.TransferToFund(TestAccountId, TestFundId, amount);

            if (success)
            {
                MessageBox.Show($"Успішно переказано {amount:F2} UAH у Фонд. Перевірте статистику!", "Успіх");
                LoadTotalCapital();
            }
            else
            {
                MessageBox.Show("Помилка під час переказу.", "Помилка");
            }
        }

        private void OpenBankCalc_Click(object sender, RoutedEventArgs e)
        {
            DepositWindow bankWindow = new DepositWindow();
            bankWindow.Show();
        }
    }
}