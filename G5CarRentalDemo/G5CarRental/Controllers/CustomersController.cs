using FluentValidation;
using FluentValidation.Results;
using G5CarRental.Models;
using G5CarRental.Repositories;
using G5CarRental.Validations;
using Microsoft.AspNetCore.Mvc;

namespace G5CarRental.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private IValidator<CustomersModel> _customersValidator;

        public CustomersController(ICustomerRepository customerRepository, IValidator<CustomersModel> customerValidator)
        {
            _customerRepository = customerRepository;
            _customersValidator = customerValidator;
        }

        public ActionResult Index()
        {
            return View(_customerRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersModel customer)
        {
            ValidationResult validationResult = _customersValidator.Validate(customer);

            try
            {
                _customerRepository.Add(customer);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                validationResult.AddToModelState(this.ModelState);

                return View(customer);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                CustomersModel customer = _customerRepository.GetCustomerById(id);

                if (customer == null)
                {
                    return NotFound();
                }

                return View(customer);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersModel customer)
        {
            ValidationResult validationResult = _customersValidator.Validate(customer);

            try
            {
                if (ModelState.IsValid)
                {
                    _customerRepository.Edit(customer);

                    return RedirectToAction(nameof(Index));
                }

                return View(customer); 
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                validationResult.AddToModelState(this.ModelState);
                return View(customer);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                CustomersModel customer = _customerRepository.GetCustomerById(id);

                if (customer == null)
                {
                    return NotFound(); 
                }

                return View(customer);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomersModel customer)
        {
            try
            {
                _customerRepository.Delete(customer.CustomerID);

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
