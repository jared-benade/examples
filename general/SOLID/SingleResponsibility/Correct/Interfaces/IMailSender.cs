namespace SingleResponsibility.Correct.Interfaces
{
    public interface IMailSender
    {
        void SendEmail(string emailFrom, string emailTo, string emailSubject, string emailBody);
    }
}