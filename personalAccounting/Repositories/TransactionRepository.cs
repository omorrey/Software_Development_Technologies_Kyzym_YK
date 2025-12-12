using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using personalAccounting.Models;

namespace personalAccounting.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        public void Add(Transaction transaction)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO [Transaction] (Amount, Date, TransactionType, Category, Description, UserId) " +
                               "VALUES (@Amount, @Date, @Type, @Category, @Desc, @UserId)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.Parameters.AddWithValue("@Date", transaction.Date);
                    command.Parameters.AddWithValue("@Type", transaction.Type.ToString());
                    command.Parameters.AddWithValue("@Category", transaction.Category);
                    command.Parameters.AddWithValue("@Desc", transaction.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@UserId", 1);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id) { throw new NotImplementedException(); }
        public List<Transaction> GetAll()
        {
            var transactions = new List<Transaction>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM [Transaction]", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var transaction = new Transaction
                            {
                                TransactionId = (int)reader["TransactionId"],
                                Amount = (decimal)reader["Amount"],
                                Date = (DateTime)reader["Date"],
                                Category = reader["Category"].ToString(),
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "",
                                Type = (Transaction.TransactionType)Enum.Parse(typeof(Transaction.TransactionType), reader["TransactionType"].ToString())
                            };
                            transactions.Add(transaction);
                        }
                    }
                }
            }
            return transactions;
        }
        public Transaction GetById(int id) { throw new NotImplementedException(); }
        public void Update(Transaction transaction) { throw new NotImplementedException(); }
    }
}