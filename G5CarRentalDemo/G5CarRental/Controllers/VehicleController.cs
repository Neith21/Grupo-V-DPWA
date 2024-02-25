using FluentValidation;
using FluentValidation.Results;
using G5CarRental.Models;
using G5CarRental.Repositories;
using G5CarRental.Validations;
using Microsoft.AspNetCore.Mvc;

namespace G5CarRental.Controllers
{
	public class VehicleController : Controller
	{
		private readonly IVehicleRepository _vehicleRepository;
		private IValidator<VehiclesModel> _vehicleValidator;

		public VehicleController(IVehicleRepository vehicleRepository, IValidator<VehiclesModel> vehicleValidator)
		{
			_vehicleRepository = vehicleRepository;
			_vehicleValidator = vehicleValidator;
		}

		public ActionResult Index()
		{
			return View(_vehicleRepository.GetAll());
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(VehiclesModel vehicle)
		{
			ValidationResult validationResult = _vehicleValidator.Validate(vehicle);

			try
			{
                _vehicleRepository.Add(vehicle);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;

				validationResult.AddToModelState(this.ModelState);

				return View(vehicle);
			}
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			try
			{
				VehiclesModel vehicle = _vehicleRepository.GetVehicleById(id);

				if (vehicle == null)
				{
					return NotFound();
				}

				return View(vehicle);
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View("Error");
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(VehiclesModel vehicle)
		{
			ValidationResult validationResult = _vehicleValidator.Validate(vehicle);

			try
			{
				if (ModelState.IsValid)
				{
					_vehicleRepository.Edit(vehicle);

					return RedirectToAction(nameof(Index));
				}

				return View(vehicle);
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				validationResult.AddToModelState(this.ModelState);
				return View(vehicle);
			}
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			try
			{
                VehiclesModel vehicle = _vehicleRepository.GetVehicleById(id);

				if (vehicle == null)
				{
					return NotFound();
				}

				return View(vehicle);
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View("Error");
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(VehiclesModel vehicle)
		{
			try
			{
				_vehicleRepository.Delete(vehicle.VehicleID);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View("Error");
			}
		}
	}
}
