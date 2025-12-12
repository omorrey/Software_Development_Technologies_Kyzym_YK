using System.Collections.Generic;
using personalAccounting.Models;

namespace personalAccounting.Patterns.Strategy
{
    public class ReportContext
    {
        private IReportStrategy _strategy;

        public void SetStrategy(IReportStrategy strategy)
        {
            _strategy = strategy;
        }

        public void CreateReport(List<Transaction> transactions, string filePath)
        {
            if (_strategy == null)
            {
                _strategy = new TxtReportStrategy();
            }

            _strategy.SaveReport(transactions, filePath);
        }
    }
}