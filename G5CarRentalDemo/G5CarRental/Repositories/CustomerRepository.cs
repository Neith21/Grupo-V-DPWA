using G5CarRental.Data;
using G5CarRental.Models;
using System.Data;
using System.Data.SqlClient;

namespace G5CarRental.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public CustomerRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<CustomersModel> GetAll()
        {
            List<CustomersModel> customersList = new List<CustomersModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT CustomerID, CustomerFirstName, CustomerLastName, UID, Address, Phone, CustomerEmail, License FROM Customers";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomersModel customer = new CustomersModel();
                            customer.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                            customer.CustomerFirstName = reader["CustomerFirstName"].ToString();
                            customer.CustomerLastName = reader["CustomerLastName"].ToString();
                            customer.UID = reader["UID"].ToString();
                            customer.Address = reader["Address"].ToString();
                            customer.Phone = reader["Phone"].ToString();
                            customer.CustomerEmail = reader["CustomerEmail"].ToString();
                            customer.License = reader["License"].ToString();
                            customersList.Add(customer);
                        }
                    }
                }
            }

            return customersList;
        }

        public CustomersModel? GetCustomerById(int id)
        {
            CustomersModel customer = new CustomersModel();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT CustomerID, CustomerFirstName, CustomerLastName, UID, Address, Phone, CustomerEmail, License FROM Customers WHERE CustomerID = @CustomerID";
                    command.Parameters.AddWithValue("CustomerID", id);
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                            customer.CustomerFirstName = reader["CustomerFirstName"].ToString();
                            customer.CustomerLastName = reader["CustomerLastName"].ToString();
                            customer.UID = reader["UID"].ToString();
                            customer.Address = reader["Address"].ToString();
                            customer.Phone = reader["Phone"].ToString();
                            customer.CustomerEmail = reader["CustomerEmail"].ToString();
                            customer.License = reader["License"].ToString();
                        }
                    }
                }
            }

            return customer;
        }

        public void Add(CustomersModel customer)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Customers(CustomerFirstName, CustomerLastName, UID, Address, Phone, CustomerEmail, License)
                    VALUES (@CustomerFirstName, @CustomerLastName, @UID, @Address, @Phone, @CustomerEmail, @License)";
                    command.Parameters.AddWithValue("@CustomerFirstName", customer.CustomerFirstName);
                    command.Parameters.AddWithValue("@CustomerLastName", customer.CustomerLastName);
                    command.Parameters.AddWithValue("@UID", customer.UID);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);
                    command.Parameters.AddWithValue("@License", customer.License);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Edit(CustomersModel customer)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Customers 
											SET 
												CustomerFirstName = @CustomerFirstName,
												CustomerLastName = @CustomerLastName,
												UID = @UID,
												Address = @Address,
												Phone = @Phone,
												CustomerEmail = @CustomerEmail,
                                                License = @License
											WHERE 
												CustomerID = @CustomerID";
                    command.Parameters.AddWithValue("@CustomerFirstName", customer.CustomerFirstName);
                    command.Parameters.AddWithValue("@CustomerLastName", customer.CustomerLastName);
                    command.Parameters.AddWithValue("@UID", customer.UID);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);
                    command.Parameters.AddWithValue("@License", customer.License);
                    command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
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
                    command.CommandText = @"DELETE FROM Customers
											WHERE CustomerID = @CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
