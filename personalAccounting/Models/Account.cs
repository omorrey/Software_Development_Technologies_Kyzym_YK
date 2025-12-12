using personalAccounting.Patterns.Composite;
using System.Collections.Generic;

namespace personalAccounting.Models
{
    public class Account : IFinanceComponent
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }

        public decimal GetTotalBalance()
        {
            return Balance;
        }

        public void Add(IFinanceComponent component) { }
        public void Remove(IFinanceComponent component) { }
        public List<IFinanceComponent> GetChildren()
        {
            return new List<IFinanceComponent>();
        }
    }
}