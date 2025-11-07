using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting.Repositories
{
    class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
