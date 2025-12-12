using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using personalAccounting.Models;

namespace personalAccounting.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetById(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Account WHERE AccountId = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Account
                            {
                                AccountId = (int)reader["AccountId"],
                                AccountName = reader["AccountName"].ToString(),
                                Balance = (decimal)reader["Balance"],
                                Currency = reader["Currency"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }



        public void Update(Account account)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Account SET Balance = @Balance WHERE AccountId = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Balance", account.Balance);
                    command.Parameters.AddWithValue("@Id", account.AccountId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Add(Account account)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Account (AccountName, Balance, Currency, UserId) VALUES (@Name, @Balance, @Currency, @UserId)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", account.AccountName);
                    command.Parameters.AddWithValue("@Balance", account.Balance);
                    command.Parameters.AddWithValue("@Currency", account.Currency);
                    command.Parameters.AddWithValue("@UserId", 1);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id) { throw new NotImplementedException(); }
        public List<Account> GetAll()
        {
            var list = new List<Account>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Account";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Account
                        {
                            AccountId = (int)reader["AccountId"],
                            AccountName = reader["AccountName"].ToString(),
                            Balance = (decimal)reader["Balance"],
                            Currency = reader["Currency"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        
        public List<Account> GetAllByUserId(int userId)
        {
            var accounts = new List<Account>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = @"
                SELECT A.* FROM [Account] AS A
                JOIN [UserAccount] AS UA ON A.AccountId = UA.AccountId
                WHERE UA.UserId = @userId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(new Account
                            {
                                AccountId = (int)reader["AccountId"],
                                AccountName = reader["AccountName"].ToString(),
                                Balance = (decimal)reader["Balance"],
                                Currency = reader["Currency"].ToString()
                            });
                        }
                    }
                }
            }
            return accounts;
        }
    }
}