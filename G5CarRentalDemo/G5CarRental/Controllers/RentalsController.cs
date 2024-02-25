using G5CarRental.Models;
using G5CarRental.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace G5CarRental.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalsRepository _rentalsRepository;

        public RentalsController(IRentalsRepository rentalsRepository)
        {
            _rentalsRepository = rentalsRepository;
        }

        public IActionResult Index()
        {
            return View(_rentalsRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var customers = _rentalsRepository.GetAllCustomers();
            ViewBag.Customers = new SelectList(customers, nameof(CustomersModel.CustomerID), nameof(CustomersModel.CustomerFirstName));

            var vehicles = _rentalsRepository.GetAllVehicles();
            ViewBag.Vehicles = new SelectList(vehicles, nameof(VehiclesModel.VehicleID), nameof(VehiclesModel.Model));

            var employees = _rentalsRepository.GetAllEmployees();
            ViewBag.Employees = new SelectList(employees, nameof(EmployeeModel.EmployeeID), nameof(EmployeeModel.EmployeeFirstName));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RentalsModel rentals)
        {
            try
            {
                _rentalsRepository.Add(rentals);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(rentals);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var rentals = _rentalsRepository.GetRentalsById(id);
            var customers = _rentalsRepository.GetAllCustomers();
            var vehicles = _rentalsRepository.GetAllVehicles();
            var employees = _rentalsRepository.GetAllEmployees();

            if (rentals == null)
            {
                return NotFound();
            }

            ViewBag.Customers = new SelectList(customers, nameof(CustomersModel.CustomerID), nameof(CustomersModel.CustomerFirstName), rentals?.CustomerID);
            ViewBag.Vehicles = new SelectList(vehicles, nameof(VehiclesModel.VehicleID), nameof(VehiclesModel.Model), rentals?.VehicleID);
            ViewBag.Employees = new SelectList(employees, nameof(EmployeeModel.EmployeeID), nameof(EmployeeModel.EmployeeFirstName), rentals?.EmployeeID);

            return View(rentals);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RentalsModel rentals)
        {
            try
            {
                _rentalsRepository.Edit(rentals);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(rentals);

            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var rentals = _rentalsRepository.GetRentalsById(id);

            if (rentals == null)
            {
                return NotFound();
            }

            return View(rentals);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(RentalsModel rentals)
        {
            try
            {
                _rentalsRepository.Delete(rentals.RentID);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(rentals);

            }
        }
    }
}
