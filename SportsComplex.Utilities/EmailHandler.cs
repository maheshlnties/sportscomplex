using System.Net;
using System.Net.Mail;

namespace SportsComplex.Utilities
{
    public class EmailHandler
    {
        public static void SendMail(MailMessage message)
        {
            var client = new SmtpClient
            {
                Host = "smtp.googlemail.com",
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Credentials = new NetworkCredential("sportscomplexuser@gmail.com", "testuser@123")
            };
            client.Send(message);
        }
    }
}
