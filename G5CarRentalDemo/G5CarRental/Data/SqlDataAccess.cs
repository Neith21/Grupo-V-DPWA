using System.Data.SqlClient;

namespace G5CarRental.Data
{
	public class SqlDataAccess
	{
		private readonly IConfiguration _configuration;

		private readonly string _connectionString;

		public SqlDataAccess(IConfiguration configuration)
		{
			_configuration = configuration;

			_connectionString = _configuration.GetConnectionString("default");
		}

		public SqlConnection GetConnection() => new SqlConnection(_connectionString);
	}
}
