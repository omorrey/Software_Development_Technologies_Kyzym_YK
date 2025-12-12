using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using personalAccounting.Models;
using personalAccounting.Patterns.Facade;

namespace personalAccounting
{
    public partial class StatisticsWindow : Window
    {
        private readonly AccountingFacade _facade;
        private List<Transaction> _currentList;

        public StatisticsWindow()
        {
            InitializeComponent();
            _facade = new AccountingFacade();
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_facade == null) return;
            LoadData();
        }

        private void LoadData()
        {
            var allTransactions = _facade.GetAllTransactions();

            if (FilterBox.SelectedIndex == 1)
                _currentList = allTransactions.Where(t => t.Type == Transaction.TransactionType.Expense).ToList();
            else if (FilterBox.SelectedIndex == 2)
                _currentList = allTransactions.Where(t => t.Type == Transaction.TransactionType.Income).ToList();
            else
                _currentList = allTransactions;

            StatsGrid.ItemsSource = _currentList;
            UpdateTotalSum();
        }

        private void UpdateTotalSum()
        {
            decimal total = 0;
            foreach (var t in _currentList)
            {
                if (t.Type == Transaction.TransactionType.Income) total += t.Amount;
                else total -= t.Amount;
            }
            TotalText.Text = $"Разом: {total:F2} UAH";
        }

        private void DuplicateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StatsGrid.SelectedItem is Transaction selectedTransaction)
            {
                bool success = _facade.DuplicateTransaction(selectedTransaction);

                if (success)
                {
                    MessageBox.Show("Успішно продубльовано!", "Успіх");
                    LoadData();
                }
            }
        }

        private void ExportCsvBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog { Filter = "Excel (*.xlsx)|*.xlsx", FileName = "Report.xlsx" };
            if (dlg.ShowDialog() == true)
            {
                _facade.ExportReport(_currentList, dlg.FileName, "xlsx");
                MessageBox.Show("Звіт збережено!", "Успіх");
            }
        }

        private void ExportTxtBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog { Filter = "Text (*.txt)|*.txt", FileName = "Report.txt" };
            if (dlg.ShowDialog() == true)
            {
                _facade.ExportReport(_currentList, dlg.FileName, "txt");
                MessageBox.Show("Звіт збережено!", "Успіх");
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e) => Close();
    }
}