using G5CarRental.Models;

namespace G5CarRental.Repositories
{
    public interface IRentalsRepository
    {
        IEnumerable<RentalsModel> GetAll();
        RentalsModel GetRentalsById(int id);

        void Add(RentalsModel rentals);
        void Edit(RentalsModel rentals);
        void Delete(int id);


        IEnumerable<CustomersModel> GetAllCustomers();
        IEnumerable<VehiclesModel> GetAllVehicles();
        IEnumerable<EmployeeModel> GetAllEmployees();
    }
}
