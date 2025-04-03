using FluentValidation;
using UGB.Domain.Entities;

namespace UGB.Application.Validations
{
    public class RaCarrerasValidation : AbstractValidator<ra_car_carreras>
    {
        public RaCarrerasValidation()
        {
            RuleFor(x=>x.car_nombre).NotEmpty().NotNull().WithMessage("El nombre no puede estar vacío.").WithName("Nombre");
            RuleFor(x=>x.car_nombre).MaximumLength(100).WithMessage("El nombre debe tener un máximo de 100 caracteres.");
            RuleFor(x=>x.car_nombre).MinimumLength(5).WithMessage("El nombre debe tener un mínimo de 5 caracteres.");
        }
    }
}