using FluentValidation;
using UGB.Application.DTO;

namespace UGB.Application.Validations
{
    public class EmailValidation : AbstractValidator<EmailDTO>
    {
        public EmailValidation()
        {
            RuleFor(x=>x.To).NotNull().NotEmpty().WithName("To");
            RuleFor(x=>x.Body).NotNull().NotEmpty().WithName("Body");
            RuleFor(x=>x.Subject).NotNull().NotEmpty().WithName("Subject");
        }
    }
}