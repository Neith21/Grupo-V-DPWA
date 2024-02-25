using G5CarRental.Data;
using G5CarRental.Models;
using System.Data;
using System.Data.SqlClient;

namespace G5CarRental.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly SqlDataAccess _dbConnection;

		public EmployeeRepository(SqlDataAccess dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public IEnumerable<EmployeeModel> GetAll()
		{
			List<EmployeeModel> employeesList = new List<EmployeeModel>();

			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "SELECT EmployeeID, EmployeeFirstName, EmployeeLastName, Position, Salary, EmployeeEmail, HireDate FROM Employees";
					command.CommandType = CommandType.Text;

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							EmployeeModel employee = new EmployeeModel();
							employee.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
							employee.EmployeeFirstName = reader["EmployeeFirstName"].ToString();
							employee.EmployeeLastName = reader["EmployeeLastName"].ToString();
							employee.Position = reader["Position"].ToString();
							employee.Salary = Convert.ToDouble(reader["Salary"]);
							employee.EmployeeEmail = reader["EmployeeEmail"].ToString();
							employee.HireDate = Convert.ToDateTime(reader["HireDate"]);
							employeesList.Add(employee);
						}
					}
				}
			}

			return employeesList;
		}

		public EmployeeModel? GetEmployeeById(int id)
		{
			EmployeeModel employee = new EmployeeModel();

			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"SELECT EmployeeID, EmployeeFirstName, EmployeeLastName, Position, Salary, EmployeeEmail, HireDate FROM Employees WHERE EmployeeID = @EmployeeID";
					command.Parameters.AddWithValue("EmployeeID", id);
					command.CommandType= CommandType.Text;

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							employee.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
							employee.EmployeeFirstName = reader["EmployeeFirstName"].ToString();
							employee.EmployeeLastName = reader["EmployeeLastName"].ToString();
							employee.Position = reader["Position"].ToString();
							employee.Salary = Convert.ToDouble(reader["Salary"]);
							employee.EmployeeEmail = reader["EmployeeEmail"].ToString();
							employee.HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate")).Date;
						}
					}
				}
			}

			return employee;
		}

		public void Add(EmployeeModel employee)
		{
			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"INSERT INTO Employees(EmployeeFirstName, EmployeeLastName, Position, Salary, EmployeeEmail, HireDate)
											VALUES(@EmployeeFirstName, @EmployeeLastName, @Position, @Salary, @EmployeeEmail, @HireDate)";
					command.Parameters.AddWithValue("@EmployeeFirstName", employee.EmployeeFirstName);
					command.Parameters.AddWithValue("@EmployeeLastName", employee.EmployeeLastName);
					command.Parameters.AddWithValue("@Position", employee.Position);
					command.Parameters.AddWithValue("@Salary", employee.Salary);
					command.Parameters.AddWithValue("@EmployeeEmail", employee.EmployeeEmail);
					command.Parameters.AddWithValue("@HireDate", employee.HireDate);
					command.CommandType = CommandType.Text;
					command.ExecuteNonQuery();
				}
			}
		}
		public void Edit(EmployeeModel employee)
		{
			using ( var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"UPDATE Employees 
											SET 
												EmployeeFirstName = @EmployeeFirstName,
												EmployeeLastName = @EmployeeLastName,
												Position = @Position,
												Salary = @Salary,
												EmployeeEmail = @EmployeeEmail,
												HireDate = @HireDate
											WHERE 
												EmployeeID = @EmployeeID";
					command.Parameters.AddWithValue("@EmployeeFirstName", employee.EmployeeFirstName);
					command.Parameters.AddWithValue("@EmployeeLastName", employee.EmployeeLastName);
					command.Parameters.AddWithValue("@Position", employee.Position);
					command.Parameters.AddWithValue("@Salary", employee.Salary);
					command.Parameters.AddWithValue("@EmployeeEmail", employee.EmployeeEmail);
					command.Parameters.AddWithValue("@HireDate", employee.HireDate);
					command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
					command.CommandType = CommandType.Text;
					command.ExecuteNonQuery();
				}
			}
		}

		public void Delete(int id)
		{
			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"DELETE FROM Employees
											WHERE EmployeeID = @EmployeeID";
					command.Parameters.AddWithValue("@EmployeeID", id);
					command.CommandType = CommandType.Text;
					command.ExecuteNonQuery();
				}
			}
		}

	}
}
