using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using personalAccounting.Models;

namespace personalAccounting.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool Register(string username, string password, string email)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
                using (var checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@UserName", username);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        return false;
                    }
                }

                string query = "INSERT INTO Users (UserName, Email, PasswordHash, AuthStatus) VALUES (@UserName, @Email, @PasswordHash, 0)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value); 
                    command.Parameters.AddWithValue("@PasswordHash", password); 

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        public User Login(string username, string password)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT UserId, UserName, Email, PasswordHash, AuthStatus FROM Users WHERE UserName = @UserName AND PasswordHash = @PasswordHash";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@PasswordHash", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = (int)reader["UserId"],
                                UserName = reader["UserName"].ToString(),
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                PasswordHash = reader["PasswordHash"].ToString(),
                                AuthStatus = (bool)reader["AuthStatus"]
                            };
                        }
                    }
                }
            }
            return null; 
        }

        public User GetByEmail(string email)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT UserId, UserName, Email, PasswordHash, AuthStatus FROM Users WHERE Email = @Email";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = (int)reader["UserId"],
                                UserName = reader["UserName"].ToString(),
                                Email = reader["Email"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                AuthStatus = (bool)reader["AuthStatus"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Add(User user)
        {
            Register(user.UserName, user.PasswordHash, user.Email);
        }

        public void Delete(int id) { throw new NotImplementedException(); }
        public List<User> GetAll() { throw new NotImplementedException(); }
        public User GetById(int id) { throw new NotImplementedException(); }
        public void Update(User user) { throw new NotImplementedException(); }
    }
}