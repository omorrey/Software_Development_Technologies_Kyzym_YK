using System;
using personalAccounting.Models;

namespace personalAccounting.Patterns.FactoryMethod
{
    public abstract class TransactionCreator
    {
        public abstract Transaction Create(decimal amount, string category, string description, DateTime date);
    }
}