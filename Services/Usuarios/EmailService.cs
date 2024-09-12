using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Fodun.Data;
using Microsoft.Extensions.Options;
using Fodun.Models;

namespace Fodun.Services
{
    public class EmailService
    {
        private readonly ApplicationDbContext _context;
        private readonly SmtpSettings _smtpSettings;

        public EmailService(ApplicationDbContext context, IOptions<SmtpSettings> smtpSettings)
        {
            _context = context;
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            try
            {
                using (var client = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_smtpSettings.Username, "spvm yybk dudp pmjp"); 
                    client.EnableSsl = true;

                    var message = new MailMessage();
                    message.From = new MailAddress(_smtpSettings.Username);
                    message.To.Add(new MailAddress(to));
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = false;

                    await client.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to send email: {ex.Message}");
            }
        }
    }
}
