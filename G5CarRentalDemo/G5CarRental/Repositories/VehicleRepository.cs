using G5CarRental.Data;
using G5CarRental.Models;
using System.Data;
using System.Data.SqlClient;

namespace G5CarRental.Repositories
{
	public class VehicleRepository : IVehicleRepository
	{
		private readonly SqlDataAccess _dbConnection;

		public VehicleRepository(SqlDataAccess dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public IEnumerable<VehiclesModel> GetAll()
		{
			List<VehiclesModel> vehicleList = new List<VehiclesModel>();

			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "SELECT VehicleId, Brand, Model, Year, Type, Availability FROM Vehicles";
					command.CommandType = CommandType.Text;

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							VehiclesModel vehicle = new VehiclesModel();
							vehicle.VehicleID = Convert.ToInt32(reader["VehicleId"]);
							vehicle.Brand = reader["Brand"].ToString();
							vehicle.Model = reader["Model"].ToString();
							vehicle.Year = Convert.ToInt32(reader["Year"]);
							vehicle.Type = reader["Type"].ToString();
							vehicle.Availability = reader["Availability"].ToString();
							vehicleList.Add(vehicle);
						}
					}
				}
			}

			return vehicleList;
		}

		public VehiclesModel? GetVehicleById(int id)
		{
			VehiclesModel vehicle = new VehiclesModel();

			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"SELECT VehicleId, Brand, Model, Year, Type, Availability FROM Vehicles WHERE VehicleId = @VehicleId";
					command.Parameters.AddWithValue("VehicleId", id);
					command.CommandType = CommandType.Text;

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							vehicle.VehicleID = Convert.ToInt32(reader["VehicleId"]);
							vehicle.Brand = reader["Brand"].ToString();
							vehicle.Model = reader["Model"].ToString();
							vehicle.Year = Convert.ToInt32(reader["Year"]);
							vehicle.Type = reader["Type"].ToString();
							vehicle.Availability = reader["Availability"].ToString(); //Debido a problemas de conversión, se dejo en string
						}
					}
				}
			}

			return vehicle;
		}

		public void Add(VehiclesModel vehicle)
		{
			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"INSERT INTO Vehicles(Brand, Model, Year, Type, Availability)
                    VALUES (@Brand, @Model, @Year, @Type, @Availability)";
					command.Parameters.AddWithValue("@Brand", vehicle.Brand);
					command.Parameters.AddWithValue("@Model", vehicle.Model);
					command.Parameters.AddWithValue("@Year", vehicle.Year);
					command.Parameters.AddWithValue("@Type", vehicle.Type);
					command.Parameters.AddWithValue("@Availability", vehicle.Availability);
					command.CommandType = CommandType.Text;
					command.ExecuteNonQuery();
				}
			}
		}
		public void Edit(VehiclesModel vehicle)
		{
			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"UPDATE Vehicles 
											SET 
												Brand = @Brand,
												Model = @Model,
												Year = @Year,
												Type = @Type,
												Availability = @Availability
											WHERE 
												VehicleId = @VehicleId";
					command.Parameters.AddWithValue("@Brand", vehicle.Brand);
					command.Parameters.AddWithValue("@Model", vehicle.Model);
					command.Parameters.AddWithValue("@Year", vehicle.Year);
					command.Parameters.AddWithValue("@Type", vehicle.Type);
					command.Parameters.AddWithValue("@Availability", vehicle.Availability);
                    command.Parameters.AddWithValue("@VehicleId", vehicle.VehicleID);
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
					command.CommandText = @"DELETE FROM Vehicles
											WHERE VehicleId = @VehicleId";
					command.Parameters.AddWithValue("@VehicleId", id);
					command.CommandType = CommandType.Text;
					command.ExecuteNonQuery();
				}
			}
		}
	}
}
