using personalAccounting.Models;
using personalAccounting.Repositories;

namespace personalAccounting.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _transactionRepository = new TransactionRepository();
        private readonly AccountRepository _accountRepository = new AccountRepository();

        public bool AddIncome(Transaction transaction, int accountId)
        {
            _transactionRepository.Add(transaction);

            var account = _accountRepository.GetById(accountId);
            if (account != null)
            {
                account.Balance += transaction.Amount;
                _accountRepository.Update(account);
            }

            return true;
        }

        public bool AddExpense(Transaction transaction, int accountId)
        {
            _transactionRepository.Add(transaction);

            var account = _accountRepository.GetById(accountId);
            if (account != null)
            {
                account.Balance -= transaction.Amount;
                _accountRepository.Update(account);
            }

            return true;
        }
    }
}