using System.Net;
using System.Net.Mail;

namespace HIT.REST.Infrastructure.Network;

public static class EmailDispatcher
{
    public static void SendEmail(string recipient, string body)
    {
        MailMessage message = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        message.From = new MailAddress("idjazh@hotmail.com");
        message.To.Add(new MailAddress(recipient));
        message.Subject = "Change in phase";
        message.IsBodyHtml = true;
        message.Body = body;
        smtp.Port = 587;
        smtp.Host = "smtp-mail.outlook.com";
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("idjazh@hotmail.com", "idjaz@saro.com");
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Send(message);
    }
}