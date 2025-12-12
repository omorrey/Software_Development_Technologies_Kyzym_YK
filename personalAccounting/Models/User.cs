using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalAccounting.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool AuthStatus { get; set; }

        public void Login()
        {

        }
        public void Logout()
        {

        }
        public void Register()
        {

        }
    }
}
