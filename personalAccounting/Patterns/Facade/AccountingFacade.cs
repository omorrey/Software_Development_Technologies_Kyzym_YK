using Microsoft.Identity.Client;
using personalAccounting.Models;
using personalAccounting.Patterns.FactoryMethod;
using personalAccounting.Patterns.Strategy;
using personalAccounting.Repositories;
using personalAccounting.Services;
using System;
using System.Collections.Generic;

namespace personalAccounting.Patterns.Facade
{
    public class AccountingFacade
    {
        private readonly TransactionService _transactionService;
        private readonly TransactionRepository _transactionRepository;
        private readonly ReportContext _reportContext;
        private readonly FundRepository _fundRepository;
        private readonly AccountRepository _accountRepository;

        public AccountingFacade()
        {
            _transactionService = new TransactionService();
            _transactionRepository = new TransactionRepository();
            _reportContext = new ReportContext();
            _fundRepository = new FundRepository();
            _accountRepository = new AccountRepository();
        }

        public bool AddTransaction(decimal amount, string category, string description, Transaction.TransactionType type, int accountId)
        {
            TransactionCreator creator;

            if (type == Transaction.TransactionType.Income)
            {
                creator = new IncomeCreator();
            }
            else
            {
                creator = new ExpenseCreator();
            }

            Transaction transaction = creator.Create(amount, category, description, DateTime.Now);

            if (type == Transaction.TransactionType.Income)
            {
                return _transactionService.AddIncome(transaction, accountId);
            }
            else
            {
                return _transactionService.AddExpense(transaction, accountId);
            }
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAll();
        }

        public bool DuplicateTransaction(Transaction original)
        {
            Transaction clone = original.Clone();

            if (clone.Type == Transaction.TransactionType.Income)
                return _transactionService.AddIncome(clone, 1);
            else
                return _transactionService.AddExpense(clone, 1);
        }

        public void ExportReport(List<Transaction> data, string filePath, string format)
        {
            if (format == "xlsx")
            {
                _reportContext.SetStrategy(new XLSXReportStrategy());
            }
            else
            {
                _reportContext.SetStrategy(new TxtReportStrategy());
            }

            _reportContext.CreateReport(data, filePath);
        }

        public decimal GetTotalCapital(int userId)
        {
            var userAssets = new UserAssets { UserName = $"Assets for User {userId}" };

            var accounts = _accountRepository.GetAllByUserId(userId);
            foreach (var acc in accounts)
            {
                userAssets.Add(acc);
            }

            var funds = _fundRepository.GetAllByUserId(userId);
            foreach (var fund in funds)
            {
                userAssets.Add(fund);
            }

            return userAssets.GetTotalBalance();
        }

        public bool TransferToFund(int sourceAccountId, int fundId, decimal amount)
        {
            bool transactionSuccess = AddTransaction(
                amount,
                "Переказ у Фонд",
                "Переказ у фонд",
                Transaction.TransactionType.Expense,
                sourceAccountId);

            if (!transactionSuccess) return false;

            try
            {
                _fundRepository.UpdateBalance(fundId, amount);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}