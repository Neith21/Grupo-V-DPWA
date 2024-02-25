using G5CarRental.Models;
using FluentValidation;

namespace G5CarRental.Validations
{
    public class VehicleValidator : AbstractValidator<VehiclesModel>
    {
        public VehicleValidator()
        {
            RuleFor(vehicle => vehicle.Brand)
                .NotNull().WithMessage("Este campo no puede ir vacío.")
                .NotEmpty().WithMessage("Este campo no puede ir vacío.")
                .MaximumLength(75).WithMessage("Maximo de 75 caracteres.");
            RuleFor(vehicle => vehicle.Model)
                .NotNull().WithMessage("Este campo no puede ir vacío.")
                .NotEmpty().WithMessage("Este campo no puede ir vacío.")
                .MaximumLength(75).WithMessage("Maximo de 75 caracteres.");
            RuleFor(vehicle => vehicle.Year)
                .NotNull().WithMessage("Este campo no puede ir vacío.")
                .NotEmpty().WithMessage("Este campo no puede ir vacío.");
            RuleFor(vehicle => vehicle.Type)
                .NotNull().WithMessage("Este campo no puede ir vacío.")
                .NotEmpty().WithMessage("Este campo no puede ir vacío.");
            RuleFor(vehicle => vehicle.Availability)
                .NotNull().WithMessage("Este campo no puede ir vacío.")
                .NotEmpty().WithMessage("Este campo no puede ir vacío.");

        }
    }
}
