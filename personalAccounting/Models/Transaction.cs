using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting
{
    class Transaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public enum TransactionType { Income, Expense }
        public string Category { get; set; }
        public string Description { get; set; }

        public void ValidateTransaction()
        {
        }
        public void SaveTransaction()
        {
        }
    }
}
