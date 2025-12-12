using System.Collections.Generic;
using System.Linq;
using personalAccounting.Models;
using personalAccounting.Repositories;

namespace personalAccounting.Services
{
    public class StatisticsService
    {
        private readonly ITransactionRepository _transactionRepository;

        public StatisticsService()
        {
            _transactionRepository = new TransactionRepository();
        }

        public Dictionary<string, decimal> GetExpensesByCategory()
        {
            var transactions = _transactionRepository.GetAll();

            var stats = transactions
                .GroupBy(t => t.Category)
                .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));

            return stats;
        }
    }
}