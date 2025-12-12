using personalAccounting.Patterns.Composite;
using System.Collections.Generic;
using System.Linq;

namespace personalAccounting.Models
{
    public class UserAssets : IFinanceComponent
    {
        private List<IFinanceComponent> _children = new List<IFinanceComponent>();

        public string UserName { get; set; }

        public decimal GetTotalBalance()
        {
            return _children.Sum(c => c.GetTotalBalance());
        }

        public void Add(IFinanceComponent component)
        {
            _children.Add(component);
        }

        public void Remove(IFinanceComponent component)
        {
            _children.Remove(component);
        }

        public List<IFinanceComponent> GetChildren()
        {
            return _children;
        }
    }
}