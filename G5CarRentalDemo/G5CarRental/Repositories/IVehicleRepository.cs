using G5CarRental.Models;

namespace G5CarRental.Repositories
{
	public interface IVehicleRepository
	{
		IEnumerable<VehiclesModel> GetAll();

		VehiclesModel GetVehicleById(int id);

		void Add(VehiclesModel vehicle);

		void Edit(VehiclesModel vehicle);

		void Delete(int id);
	}
}
