using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting
{
    class Statistics
    {
        public int Period { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalIncome { get; set; }
        public Dictionary<string, decimal> CategoryBreakdown { get; set; }


        public void GenerateReport()
        {
        }
        public void ExportToExcel()
        {
        }
        public void ImportFromExcel()
        {
        }
    }
}
