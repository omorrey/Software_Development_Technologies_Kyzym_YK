using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace personalAccounting
{
    class Account
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }

        public string AccountName { get; set; }
        public string Currency { get; set; }

        public void AddTransaction()
        { 
        
        }

        public void UpdateBalance()
        {

        }
    }
}
