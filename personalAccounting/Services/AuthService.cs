using System;
using personalAccounting.Models;
using personalAccounting.Repositories;

namespace personalAccounting.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService()
        {
            _userRepository = new UserRepository();
        }

        public bool RegisterUser(string name, string email, string password)
        {
            var existingUser = _userRepository.GetByEmail(email);
            if (existingUser != null)
            {
                return false;
            }

            var newUser = new User
            {
                UserName = name,
                Email = email,
                PasswordHash = password, 
                AuthStatus = true
            };

            _userRepository.Add(newUser);
            return true;
        }

        public User LoginUser(string email, string password)
        {
           
            var user = _userRepository.Login(email, password);

            if (user != null)
            {
                return user;
            }

            return null;
        }
    }
}