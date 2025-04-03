using Microsoft.Extensions.Options;
using UGB.Application.DTO;

namespace UGB.Services.Helper
{
    public class MailSettings : IConfigureOptions<MailSettingsDTO>
    {
        private readonly IConfiguration conf;
        public MailSettings(IConfiguration _conf)
        {
            conf = _conf;
        }

        public void Configure(MailSettingsDTO options)
        {
            conf.GetSection("MailSettings").Bind(options);
        }
    }
}