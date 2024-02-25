using G5CarRental.Models;

namespace G5CarRental.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomersModel> GetAll();

        CustomersModel GetCustomerById(int id);

        void Add(CustomersModel customer);

        void Edit(CustomersModel customer);

        void Delete(int id);
    }
}
