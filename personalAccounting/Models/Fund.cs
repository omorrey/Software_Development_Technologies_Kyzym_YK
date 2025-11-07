using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting
{
    class Fund
    {
        public string FundId { get; set; }
        public string FundName { get; set; }
        public decimal GoalAmount { get; set; }
        public enum Type { Personal, Family };

        public void AddMember()
        {
        }

        public void AddTransaction()
        {
        }
    }
}
