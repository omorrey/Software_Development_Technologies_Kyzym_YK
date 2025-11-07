using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting.Repositories
{
    interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        User GetByEmail(string email);
        bool Login(string email, string passwordHash);

    }
}
