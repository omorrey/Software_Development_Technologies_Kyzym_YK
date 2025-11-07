using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting
{
    class UserFund
    {
        public int UserFundId { get; set; }
        public int UserId { get; set; }
        public int FundId { get; set; }
        public enum Role { Owner, Member }
    }
}
