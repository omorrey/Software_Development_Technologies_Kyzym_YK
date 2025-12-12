using System;
using Microsoft.Data.SqlClient;

namespace personalAccounting
{
	public static class DatabaseHelper
	{
		private static readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AccountingDB;Trusted_Connection=True;TrustServerCertificate=True;";

		public static SqlConnection GetConnection()
		{
			return new SqlConnection(connectionString);
		}
	}
}