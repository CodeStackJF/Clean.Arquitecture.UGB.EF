using System.Net.Mail;
using MimeKit;
namespace UGB.Application.DTO
{
    public class EmailDTO
    {
        //public string From { get; set; }
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }       
        public IEnumerable<MimePart> Attachments {get; set;} = new List<MimePart>();
        
    }
}