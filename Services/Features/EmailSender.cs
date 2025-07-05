using Microsoft.Extensions.Configuration;
using Services.Contracts.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.Features
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var senderEmail = _configuration["EmailSettings:Sender"];
            var senderName = _configuration["EmailSettings:SenderName"];
            var client = new SmtpClient(_configuration["EmailSettings:MailServer"],
           int.Parse(_configuration["EmailSettings:MailPort"]))
            {
                Credentials = new NetworkCredential(senderEmail, _configuration["EmailSettings:Password"]),
                EnableSsl = true,
                UseDefaultCredentials = false
            };

            //return client.SendMailAsync(
            //    new MailMessage(_configuration["EmailSettings:Sender"], email, subject, message) { IsBodyHtml = true }
            //);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail, senderName), // Set the display name here
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            return client.SendMailAsync(mailMessage);
        }
    }
}
