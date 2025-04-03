using UGB.Application.DTO;

namespace UGB.Services.Interfaces
{
    public interface IEmailService
    {
         Task<bool> SendMail(EmailDTO emailDTO);
    }
}