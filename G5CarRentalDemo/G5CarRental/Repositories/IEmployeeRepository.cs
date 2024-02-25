using G5CarRental.Models;

namespace G5CarRental.Repositories
{
	public interface IEmployeeRepository
	{
		IEnumerable<EmployeeModel> GetAll();

		EmployeeModel GetEmployeeById(int id);

		void Add(EmployeeModel employee);

		void Edit(EmployeeModel employee);

		void Delete(int id);
	}
}
