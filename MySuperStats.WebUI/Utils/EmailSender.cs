using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace MySuperStats.WebUI.Utils
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("mail.mysuperstats.com") {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential("info@mysuperstats.com", "iu3tZPG5BgDPmQ")
            };
            var mailMessage = new MailMessage {
                From = new MailAddress("mysuperstats-noreply@mysuperstats.com")
            };
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = htmlMessage;
            return client.SendMailAsync(mailMessage);
        }
    }
}