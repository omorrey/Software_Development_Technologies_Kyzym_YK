using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting.Repositories
{
    interface ITransactionRepository
    {
        List<Transaction> GetAll();
        Transaction GetById(int id);
        void Add(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(int id);
    }
}
