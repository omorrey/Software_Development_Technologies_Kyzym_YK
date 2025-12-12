using personalAccounting.Models;
using System.Collections.Generic;
using System;

namespace personalAccounting.Services
{
    public interface ITransactionService
    {
        bool AddExpense(Transaction transaction, int accountId);
        bool AddIncome(Transaction transaction, int accountId);
    }
}