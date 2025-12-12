using System.Collections.Generic;
using personalAccounting.Models;

namespace personalAccounting.Patterns.Strategy
{
    public interface IReportStrategy
    {
        void SaveReport(List<Transaction> transactions, string filePath);
    }
}