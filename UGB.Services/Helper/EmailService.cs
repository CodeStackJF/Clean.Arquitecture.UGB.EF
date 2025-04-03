using System.Net.Mail;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using UGB.Application.DTO;
using MailKit.Security;
using UGB.Domain.Entities;
using UGB.Services.Interfaces;
namespace UGB.Services.Helper
{
    public class EmailService : IEmailService
    {
        private readonly MailSettingsDTO mailSettings;
        public EmailService(IOptions<MailSettingsDTO> _mailSettings)
        {
            mailSettings = _mailSettings.Value;
        }

        public async Task<bool> SendMail(EmailDTO emailDTO)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);

            email.To.Add(MailboxAddress.Parse(emailDTO.To));
            email.From.Add(MailboxAddress.Parse(mailSettings.Mail));

            email.Subject = emailDTO.Subject;

            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = emailDTO.Body;
            
            foreach(MimePart attachment in emailDTO.Attachments)
            {
                builder.Attachments.Add(attachment.FileName, attachment.Content.Stream, attachment.ContentType);
            }

            email.Body = builder.ToMessageBody();
            using(var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(mailSettings.SMTP, mailSettings.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(mailSettings.Mail, mailSettings.Password, new CancellationToken());
                if(client.IsAuthenticated)
                {
                    await client.SendAsync(email);
                    return true;
                }
                return false;
            }
            
        }

    }
}