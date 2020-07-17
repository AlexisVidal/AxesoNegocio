using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AxesoNegocio.Helpers
{
    public class MailHelper
    {
        public static async Task SendMail(string to, string subject, string body)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(to));
            message.From = new MailAddress(Application.Current.Resources["AdminUser"].ToString());
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = Application.Current.Resources["AdminUser"].ToString(),
                    Password = Application.Current.Resources["AdminPassWord"].ToString()
                };

                try
                {
                    smtp.Credentials = credential;
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = Application.Current.Resources["SMTPName"].ToString();
                    smtp.Port = int.Parse(Application.Current.Resources["SMTPPort"].ToString());
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    var x = 1;
                }
            }
        }
    }
}