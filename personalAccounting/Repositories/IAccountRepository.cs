using personalAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting.Repositories
{
    interface IAccountRepository
    {
        List<Account> GetAll();
        Account GetById(int id);
        void Add(Account account);
        void Update(Account account);
        void Delete(int id);
        List<Account> GetAllByUserId(int userId);
    }
}
