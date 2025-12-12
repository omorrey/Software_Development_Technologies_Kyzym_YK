using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personalAccounting.Models;

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
        bool Register(string username, string password, string email);
        User Login(string username, string password);

    }
}
