using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace SportsComplex.Utilities
{
    public class EmailHandler
    {
        public static void SendMail(MailMessage message)
        {
            try
            {
                var client = new SmtpClient
                {
                    Host = Settings.EmailHost,
                    Port = Convert.ToInt32(Settings.EmailHostPort),
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(Settings.NetworkEmailId, Settings.NetworkPassword)
                };
                client.Send(message);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }
    }
}
