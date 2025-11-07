using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting
{
    class RecurringPayment
    {
        public int RecurringId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public enum Frequency { Daily, Weekly, Monthly, Yearly }
        protected bool IsActive { get; set; }

        public void GenerateTransaction()
        {
        }

        public void ValidateSchedule()
        {
        }
    }
}
