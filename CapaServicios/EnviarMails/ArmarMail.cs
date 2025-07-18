using System.ComponentModel;
using System.Security.Cryptography;

namespace CapaSesion
{
    public static class ArmarMail
    {
        public static string DireccionCorreo { get; set; }
        public static string Asunto { get; set; }
        public static string NuevaContraseña { get; set; }
        public static string body { get; set; }

        public static void Preparar(string DireccionCorreo, string asunto, string NuevaContraseña, string usuario)
        {
            body = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h2>Hola " + usuario + @".</h2>
                            <h2>Se ha solicitado un restablecimiento de contraseña para su cuenta.<br></h2>
                            <h1> Contraseña de ingreso: </h1>
                            <h2> " + NuevaContraseña + "</h2>" + 
                            "<h2>Por favor, inicie sesión con esta contraseña.<br>Se le pedirá que establezca una nueva contraseña definitiva.<br>Si usted no solicitó este cambio, por favor contacte a un administrador.<br>Saludos, el equipo de VincularAzul. </h2>";
            EnviarMail.sendMail(DireccionCorreo, asunto, body);
        }
    }
}
