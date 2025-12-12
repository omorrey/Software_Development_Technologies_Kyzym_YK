using personalAccounting.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace personalAccounting.Repositories
{
    public class FundRepository
    {
        private SqlConnection GetConnection()
        {
            return DatabaseHelper.GetConnection();
        }

        public Fund GetById(int fundId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM [Fund] WHERE FundId = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", fundId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Fund
                            {
                                FundId = (int)reader["FundId"],
                                FundName = reader["FundName"].ToString(),
                                Balance = (decimal)reader["Balance"],
                                UserId = (int)reader["UserId"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Fund> GetAllByUserId(int userId)
        {
            var funds = new List<Fund>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM [Fund] WHERE UserId = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            funds.Add(new Fund
                            {
                                FundId = (int)reader["FundId"],
                                FundName = reader["FundName"].ToString(),
                                Balance = (decimal)reader["Balance"],
                                UserId = (int)reader["UserId"]
                            });
                        }
                    }
                }
            }
            return funds;
        }

        public void Update(Fund fund)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE [Fund] SET Balance = @balance WHERE FundId = @id", connection))
                {
                    command.Parameters.AddWithValue("@balance", fund.Balance);
                    command.Parameters.AddWithValue("@id", fund.FundId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBalance(int fundId, decimal amount)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "UPDATE [Fund] SET Balance = Balance + @Amount WHERE FundId = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Id", fundId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}