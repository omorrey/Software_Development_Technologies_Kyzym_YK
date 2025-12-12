using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personalAccounting.Patterns.Prototype;

namespace personalAccounting.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public enum TransactionType { Income, Expense }
        public TransactionType Type { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public Transaction Clone()
        {
            return new Transaction
            {
                Amount = this.Amount,
                Type = this.Type,
                Category = this.Category,
                Description = this.Description,

                Date = DateTime.Now
            };
        }

        public void ValidateTransaction()
        {
        }
        public void SaveTransaction()
        {
        }
    }
}
