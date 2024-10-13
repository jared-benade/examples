using System.Net.Mail;
using SingleResponsibility.Correct.Interfaces;

namespace SingleResponsibility.Correct.Services
{
    public class MailSender : IMailSender
    {
        public void SendEmail(string emailFrom, string emailTo, string emailSubject, string emailBody)
        {
            var mailMessage = new MailMessage(emailFrom, emailTo, emailSubject, emailBody);
            // Send email message
        }
    }
}