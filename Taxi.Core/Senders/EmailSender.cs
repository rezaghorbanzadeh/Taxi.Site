using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Mail;


namespace Taxi.Core.Senders
{
    static class EmailSender
    {

        public static void SendGmail(string toUser , string subject , string bodyEmail)
        {
            var password = "";
            var myMail = "";
            var mail = new MailMessage();
            var smtpServer = new SmtpClient("");

            mail.From = new MailAddress(myMail, "تاکسی");
            mail.To.Add(toUser);
            mail.Subject = subject;
            mail.Body = bodyEmail;
            mail.IsBodyHtml = true;
            smtpServer.Port = 0;
            smtpServer.Credentials = new NetworkCredential(myMail , password);
            smtpServer.EnableSsl = false;

            try
            {
                smtpServer.Send(mail);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("خطا در ارسال ایمیل: " + ex.Message);
            }
            
        }
    }
}
