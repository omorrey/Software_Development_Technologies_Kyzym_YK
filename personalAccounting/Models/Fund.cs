using personalAccounting.Patterns.Composite;
using System.Collections.Generic;

namespace personalAccounting.Models
{
    public class Fund : IFinanceComponent
    {
        public int FundId { get; set; }
        public string FundName { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }

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