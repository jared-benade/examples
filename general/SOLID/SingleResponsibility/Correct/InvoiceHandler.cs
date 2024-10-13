using System;
using SingleResponsibility.Correct.Interfaces;
using SingleResponsibility.Correct.Services;

namespace SingleResponsibility.Correct
{
    public class InvoiceHandler
    {
        private readonly ILogger _fileLogger;
        private readonly IMailSender _emailSender;

        public InvoiceHandler()
        {
            _fileLogger = new Logger();
            _emailSender = new MailSender();
        }

        public int? AddInvoice(double invoiceAmount, DateTime invoiceDate)
        {
            try
            {
                const int newInvoiceId = 1;
                
                _fileLogger.Info($"Created new invoice with ID: {newInvoiceId}");
                SendEmail();

                return newInvoiceId;
            }
            catch (Exception ex)
            {
                _fileLogger.Error(ex);
                return null;
            }
        }

        public void DeleteInvoice(int invoiceId)
        {
            try
            {
                //Here we need to write the Code for Deleting the already generated invoice
                _fileLogger.Info($"Deleted invoice with ID: {invoiceId}");
            }
            catch (Exception ex)
            {
                _fileLogger.Error(ex);
            }
        }

        private void SendEmail()
        {
            const string emailFrom = "emailfrom@xyz.com";
            const string emailTo = "emailto@xyz.com";
            const string emailSubject = "Some email subject";
            const string emailBody = "Some email body";
            _emailSender.SendEmail(emailFrom, emailTo, emailSubject, emailBody);
        }
    }
}