using System;
using System.Net;
using System.Net.Mail;

namespace CapaSesion
{
    public static class EnviarMail
    {
        public static void sendMail(string to, string asunto, string body)
        {
            string from = "malebagonsaez@gmail.com"; 
            string displayName = "Nueva contraseña VincularAzul"; 
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(from, displayName)
                };
                mail.To.Add(to);

                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(from, "xozc zngh eipt uday"),
                    EnableSsl = true
                };
                client.Send(mail);
            }
            catch 
            {
                throw new Exception("ERROR AL ENVIAR EL MENSAJE. \n \n " +
                    "Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente." );
            }
        }
    }
}
