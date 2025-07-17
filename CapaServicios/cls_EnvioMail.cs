using System.Net;
using System.Net.Mail;

namespace CapaLogica
{
    public class cls_ServicioEmail
    {
        public void EnviarContraseñaTemporal(string emailDestino, string nombreUsuario, string contraseñaTemporal)
        {
            // La configuración del servidor SMTP (servidor, puerto, usuario, contraseña)
            // tiene que estar en archivo App.config, no en el codigo

            var fromAddress = new MailAddress("no-responder@vincularazul.com", "Sistema VincularAzul");
            var toAddress = new MailAddress(emailDestino);

            // datos servidor de correo
            string fromPassword = "TuContraseñaDeEmail";
            string subject = "Restablecimiento de Contraseña - VincularAzul";
            string body = $"Hola {nombreUsuario},\n\nSe ha solicitado un restablecimiento de contraseña para su cuenta." +
                          $"\n\nSu contraseña temporal es: {contraseñaTemporal}\n\n" +
                          "Por favor, inicie sesión con esta contraseña. Se le pedirá que establezca una nueva contraseña definitiva.\n\n" +
                          "Si usted no solicitó este cambio, por favor contacte a un administrador.\n\n" +
                          "Saludos,\nEl equipo de VincularAzul.";

            var smtp = new SmtpClient
            {
                Host = "smtp.tuproveedor.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {

                //smtp.Send(message); descomentar cuando funque c:


                System.Windows.Forms.MessageBox.Show($"Simulando envío de email a: {emailDestino}\n\nContraseña: {contraseñaTemporal}", "Simulador de Email");
            }
        }
    }
}