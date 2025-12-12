using System;
using personalAccounting.Models;

namespace personalAccounting.Patterns.FactoryMethod
{
    public class IncomeCreator : TransactionCreator
    {
        public override Transaction Create(decimal amount, string category, string description, DateTime date)
        {
            return new Transaction
            {
                Amount = amount,
                Category = category,
                Description = description,
                Date = date,
                Type = Transaction.TransactionType.Income
            };
        }
    }
}