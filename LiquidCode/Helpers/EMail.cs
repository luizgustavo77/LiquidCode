using System;
using System.Net;
using System.Net.Mail;

namespace LiquidCode.Helpers
{
    public class EMail
    {
       

        public static void Send(string to, string title, string body)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("");
                    mail.To.Add(to);
                    mail.Subject = title;
                    mail.Body = body;

                    using (SmtpClient smtp = new SmtpClient("", 000))
                    {
                        smtp.Credentials = new NetworkCredential("", new appSettings().Get("emailPassword"));
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}