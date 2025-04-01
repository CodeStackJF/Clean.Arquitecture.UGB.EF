using FluentValidation;
using UGB.Application.DTO;
using UGB.Domain.Entities;

namespace UGB.Application.Validations
{
    public class UsersValidation : AbstractValidator<UserDTO>
    {
        public UsersValidation()
        {
            RuleFor(x=>x.username).NotEmpty().WithMessage("Ingrese el usuario.");
            RuleFor(x=>x.username).MinimumLength(5).WithMessage("El usuario debe ser de al menos 5 caracteres.");
            RuleFor(x=>x.password).NotEmpty().WithMessage("Ingrese la contraseña.");
            RuleFor(x=>x.password).MinimumLength(5).WithMessage("La contraseña debe ser de al menos 5 caracteres.");
        }
    }
}