using personalAccounting.Models;
using System.Collections.Generic;

namespace personalAccounting.Patterns.Composite
{
    public interface IFinanceComponent
    {
        decimal GetTotalBalance();
        void Add(IFinanceComponent component);
        void Remove(IFinanceComponent component);
        List<IFinanceComponent> GetChildren();
    }
}