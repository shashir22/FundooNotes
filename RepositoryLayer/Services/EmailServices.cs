using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmailServices
    {
        public static void SendMail(string email, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;

                client.Credentials = new NetworkCredential("shashirg11@gmail.com", "trs@1234");
                MailMessage msgObj = new MailMessage();
                msgObj.To.Add(email);
                msgObj.From = new MailAddress("shashirg11@gmail.com");
                msgObj.Subject = "Password Reset Link";
                msgObj.Body = $"Hi,Follow The Below Link \n \n www.FundooNotes.com/reset-password\n\n /{token}";
                client.Send(msgObj);
            }
        }
    }
}
