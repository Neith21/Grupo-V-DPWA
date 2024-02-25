using G5CarRental.Data;
using G5CarRental.Models;
using System.Data.SqlClient;
using System.Data;

namespace G5CarRental.Repositories
{
    public class RentalsRepository : IRentalsRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public RentalsRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<RentalsModel> GetAll()
        {
            List<RentalsModel> rentalsList = new List<RentalsModel>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT Rentals.RentID, Rentals.CustomerID, Customers.CustomerFirstName, 
                                            Vehicles.Model, Rentals.EmployeeID, Employees.EmployeeFirstName, 
                                            Rentals.StartDate, Rentals.EndDate, Rentals.AmountPaid
                                            FROM Rentals INNER JOIN Customers ON Customers.CustomerID = Rentals.CustomerID
                                            INNER JOIN Vehicles ON Vehicles.VehicleID = Rentals.VehicleID
                                            INNER JOIN Employees ON Employees.EmployeeID = Rentals.EmployeeID";

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RentalsModel rentals = new RentalsModel();
                            //Capturando ID de la renta
                            rentals.RentID = Convert.ToInt32(reader["RentID"]);

                            //Capturando atributos de empleado, cliente y vehículo
                            rentals.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                            rentals.CustomerFirstName = reader["CustomerFirstName"].ToString();
                            rentals.Model = reader["Model"].ToString();
                            rentals.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                            rentals.EmployeeFirstName = reader["EmployeeFirstName"].ToString();

                            //Capturando fecha de inicio, fin y monto pagado
                            rentals.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            rentals.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            rentals.AmountPaid = Convert.ToDouble(reader["AmountPaid"]);

                            rentalsList.Add(rentals);
                        }
                    }
                }
            }
            return rentalsList;
        }

        public IEnumerable<CustomersModel> GetAllCustomers()
        {
            List<CustomersModel> customersList = new List<CustomersModel>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT CustomerID, CustomerFirstName FROM Customers;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomersModel customers = new CustomersModel();
                            customers.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                            customers.CustomerFirstName = reader["CustomerFirstName"].ToString();

                            customersList.Add(customers);
                        }
                    }
                }
            }
            return customersList;
        }

        public IEnumerable<VehiclesModel> GetAllVehicles()
        {
            List<VehiclesModel> vehiclesList = new List<VehiclesModel>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT VehicleID, Model FROM Vehicles;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VehiclesModel vehicles = new VehiclesModel();
                            vehicles.VehicleID = Convert.ToInt32(reader["VehicleID"]);
                            vehicles.Model = reader["Model"].ToString();

                            vehiclesList.Add(vehicles);
                        }
                    }
                }
            }
            return vehiclesList;
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employeesList = new List<EmployeeModel>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT EmployeeID, EmployeeFirstName FROM Employees;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeModel employees = new EmployeeModel();
                            employees.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                            employees.EmployeeFirstName = reader["EmployeeFirstName"].ToString();

                            employeesList.Add(employees);
                        }
                    }
                }
            }
            return employeesList;
        }

        public void Add(RentalsModel rentals)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Rentals 
                                            VALUES (@CustomerID, @VehicleID, @EmployeeID, @StartDate, @EndDate, @AmountPaid)";

                    command.Parameters.AddWithValue("@CustomerID", rentals.CustomerID);
                    command.Parameters.AddWithValue("@VehicleID", rentals.VehicleID);
                    command.Parameters.AddWithValue("@EmployeeID", rentals.EmployeeID);
                    command.Parameters.AddWithValue("@StartDate", rentals.StartDate);
                    command.Parameters.AddWithValue("@EndDate", rentals.EndDate);
                    command.Parameters.AddWithValue("@AmountPaid", rentals.AmountPaid);

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(RentalsModel rentals)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Rentals SET CustomerID = @CustomerID,
                                            VehicleID = @VehicleID, EmployeeID = @EmployeeID,
                                            StartDate = @StarDate, EndDate = @EndDate,
                                            AmountPaid = @AmountPaid WHERE RentID = @RentID";

                    command.Parameters.AddWithValue("@CustomerID", rentals.CustomerID);
                    command.Parameters.AddWithValue("@VehicleID", rentals.VehicleID);
                    command.Parameters.AddWithValue("@EmployeeID", rentals.EmployeeID);
                    command.Parameters.AddWithValue("@StarDate", rentals.StartDate);
                    command.Parameters.AddWithValue("@EndDate", rentals.EndDate);
                    command.Parameters.AddWithValue("@AmountPaid", rentals.AmountPaid);
                    command.Parameters.AddWithValue("@RentID", rentals.RentID);

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
                    command.CommandText = @"DELETE FROM Rentals WHERE RentID = @RentID;";
                    command.Parameters.AddWithValue("@RentID", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public RentalsModel? GetRentalsById(int id)
        {
            RentalsModel rentals = new RentalsModel();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT RentID, CustomerID, VehicleID, EmployeeID, StartDate, EndDate, AmountPaid
                                            FROM Rentals WHERE RentID = @RentID";

                    command.Parameters.AddWithValue("@RentID", id);
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rentals.RentID = Convert.ToInt32(reader["RentID"]);
                            rentals.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                            rentals.VehicleID = Convert.ToInt32(reader["VehicleID"]);
                            rentals.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                            rentals.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            rentals.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            rentals.AmountPaid = Convert.ToDouble(reader["AmountPaid"]);

                        }
                    }
                }
            }
            return rentals;
        }
    }
}
