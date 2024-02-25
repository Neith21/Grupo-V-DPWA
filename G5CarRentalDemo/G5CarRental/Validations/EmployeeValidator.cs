using FluentValidation;
using G5CarRental.Models;

namespace G5CarRental.Validations
{
	public class EmployeeValidator : AbstractValidator<EmployeeModel>
	{
        public EmployeeValidator()
        {
			RuleFor(employee => employee.EmployeeFirstName)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
                .NotEmpty().WithMessage("Este campo no puede ir vacío.")
				.MaximumLength(75).WithMessage("Maximo de 75 caracteres.");
			RuleFor(employee => employee.EmployeeLastName)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.")
				.MaximumLength(75).WithMessage("Maximo de 75 caracteres.");
			RuleFor(employee => employee.Position)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.")
				.MaximumLength(100).WithMessage("Maximo de 100 caracteres.");
			RuleFor(employee => employee.Salary)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.");
			RuleFor(employee => employee.EmployeeEmail)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.")
				.MaximumLength(75).WithMessage("Maximo de 75 caracteres.");
			RuleFor(employee => employee.HireDate)
				.NotNull().WithMessage("Este campo no puede ir vacío.")
				.NotEmpty().WithMessage("Este campo no puede ir vacío.");
		}
    }
}
