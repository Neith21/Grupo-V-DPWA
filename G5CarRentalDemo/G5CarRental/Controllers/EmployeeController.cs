using FluentValidation;
using FluentValidation.Results;
using G5CarRental.Models;
using G5CarRental.Repositories;
using G5CarRental.Validations;
using Microsoft.AspNetCore.Mvc;

namespace G5CarRental.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeRepository _employeeRepository;
		private IValidator<EmployeeModel> _employeeValidator;

		public EmployeeController(IEmployeeRepository employeeRepository, IValidator<EmployeeModel> employeeValidator)
		{
			_employeeRepository = employeeRepository;
			_employeeValidator = employeeValidator;
		}

		public ActionResult Index()
		{
			return View(_employeeRepository.GetAll());
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(EmployeeModel employee)
		{
			ValidationResult validationResult = _employeeValidator.Validate(employee);

			try
			{
				_employeeRepository.Add(employee);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;

				validationResult.AddToModelState(this.ModelState);

				return View(employee);
			}
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			try
			{
				// Obtener el empleado que se va a editar desde el repositorio
				EmployeeModel employee = _employeeRepository.GetEmployeeById(id);

				// Verificar si el empleado existe
				if (employee == null)
				{
					return NotFound(); // Devolver un error 404 si el empleado no se encuentra
				}

				return View(employee);
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View("Error"); // Mostrar una vista de error si ocurre una excepción
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(EmployeeModel employee)
		{
			ValidationResult validationResult = _employeeValidator.Validate(employee);

			try
			{
				if (ModelState.IsValid)
				{
					// Actualizar el empleado en el repositorio
					_employeeRepository.Edit(employee);

					return RedirectToAction(nameof(Index)); // Redirigir a la acción Index si la actualización fue exitosa
				}

				return View(employee); // Devolver la vista de edición con el modelo de empleado si hay errores de validación
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				validationResult.AddToModelState(this.ModelState);
				return View(employee); // Devolver la vista de edición con el modelo de empleado si ocurre una excepción
			}
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			try
			{
				// Obtener el empleado que se va a eliminar desde el repositorio
				EmployeeModel employee = _employeeRepository.GetEmployeeById(id);

				// Verificar si el empleado existe
				if (employee == null)
				{
					return NotFound(); // Devolver un error 404 si el empleado no se encuentra
				}

				return View(employee);
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View("Error"); // Mostrar una vista de error si ocurre una excepción
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(EmployeeModel employee)
		{
			try
			{
				// Eliminar el empleado del repositorio
				_employeeRepository.Delete(employee.EmployeeID);

				return RedirectToAction(nameof(Index)); // Redirigir a la acción Index si la eliminación fue exitosa
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View("Error"); // Mostrar una vista de error si ocurre una excepción
			}
		}

	}
}
