using System;
using System.IO;
using System.Net.Mail;

namespace SingleResponsibility.Incorrect
{
    public class InvoiceHandler
    {
        private const string ErrorLogPath = "C:\\Logs\\ErrorLog.txt";
        private const string InfoLogPath = "C:\\Logs\\InfoLog.txt";

        public int? AddInvoice(double invoiceAmount, DateTime invoiceDate)
        {
            try
            {
                const int newInvoiceId = 1;

                File.WriteAllText(InfoLogPath, $"Created new invoice with ID: {newInvoiceId}");
                SendInvoiceEmail();

                return newInvoiceId;
            }
            catch (Exception ex)
            {
                File.WriteAllText(ErrorLogPath, ex.ToString());
                return null;
            }
        }

        public void DeleteInvoice(int invoiceId)
        {
            try
            {
                File.WriteAllText(InfoLogPath, $"Deleted invoice with ID: {invoiceId}");
            }
            catch (Exception ex)
            {
                File.WriteAllText(ErrorLogPath, ex.ToString());
            }
        }

        private static void SendInvoiceEmail()
        {
            try
            {
                var mailMessage = new MailMessage("EmailFrom", "EmailTo", "EmailSubject", "EmailBody");
                // Send email message
            }
            catch (Exception ex)
            {
                File.WriteAllText(ErrorLogPath, ex.ToString());
            }
        }
    }
}