using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UGB.Application.DTO;
using UGB.Application.Exceptions;
using UGB.Application.Validations;
using UGB.Services.Interfaces;

namespace UGB.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController:ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IValidator<EmailDTO> _emailValidation;
        public EmailController(IEmailService emailService, IValidator<EmailDTO> emailValidation)
        {
            _emailService = emailService;
            _emailValidation = emailValidation;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail([FromBody] EmailDTO emailDTO)
        {
            var validation = _emailValidation.Validate(emailDTO);
            if(!validation.IsValid)
            {
                throw new CustomValidationException(validation.Errors);
            }
            await _emailService.SendMail(emailDTO);
            return NoContent();
        }
    }
}