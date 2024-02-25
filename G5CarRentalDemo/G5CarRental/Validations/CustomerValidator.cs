using G5CarRental.Models;
using FluentValidation;

namespace G5CarRental.Validations
{
	public class CustomerValidator : AbstractValidator<CustomersModel>
	{
		public CustomerValidator()
		{
			RuleFor(customer => customer.CustomerFirstName)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.")
				.MaximumLength(75).WithMessage("Maximo de 75 caracteres.");
			RuleFor(customer => customer.CustomerLastName)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.")
				.MaximumLength(75).WithMessage("Maximo de 75 caracteres.");
			RuleFor(customer => customer.UID)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.")
				.MaximumLength(100).WithMessage("Maximo de 25 caracteres.");
			RuleFor(customer => customer.Address)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.");
			RuleFor(customer => customer.Phone)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.")
				.MaximumLength(75).WithMessage("Maximo de 35 caracteres.");
			RuleFor(customer => customer.CustomerEmail)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.");
			RuleFor(customer => customer.License)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.");
		}
	}
}
