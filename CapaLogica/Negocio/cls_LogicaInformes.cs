using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.Negocio;

namespace CapaLogica.Negocio
{
    public class cls_LogicaInformes
    {

        private readonly string _clave;
        private string rutaArchivoGuardado = string.Empty;
        private string guidArchivo = string.Empty;
        cls_InformesQ _informesQ = new cls_InformesQ();

        public cls_LogicaInformes(string clave)
        {
            _clave = clave ?? throw new ArgumentNullException(nameof(clave));
        }

        public void CargarInforme(TextBox Informe, string TextoInforme, cls_LogicaInformes gestor)
        {
            if (string.IsNullOrWhiteSpace(guidArchivo))
            {
                MessageBox.Show("El paciente no posee un informe generado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Informe.Clear();
                return;
            }

            string ruta = Path.Combine(rutaArchivoGuardado, guidArchivo);

            try
            {
                string contenido = gestor.CargarOCrearArchivo(ruta);
                TextoInforme = contenido;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer o crear el archivo:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string CargarOCrearArchivo(string rutaBase, string contenidoInicial = "")
        {
            string rutaArchivo = $"{rutaBase}.dat";

            if (File.Exists(rutaArchivo))
            {
                return LeerYDesencriptarArchivo(rutaArchivo);
            }
            else
            {
                CrearYGuardarArchivo(rutaArchivo, contenidoInicial);
                return contenidoInicial;
            }
        }

        public void GuardarArchivo(string rutaBase, string contenido)
        {
            string rutaArchivo = $"{rutaBase}.dat";
            CrearYGuardarArchivo(rutaArchivo, contenido);
        }

        private void CrearYGuardarArchivo(string ruta, string contenidoPlano)
        {
            string textoEncriptado = Encriptar(contenidoPlano, _clave);
            File.WriteAllText(ruta, textoEncriptado);
        }

        private string LeerYDesencriptarArchivo(string ruta)
        {
            string textoEncriptado = File.ReadAllText(ruta);
            return Desencriptar(textoEncriptado, _clave);
        }

        private static string Encriptar(string texto, string clave)
        {
            if (string.IsNullOrEmpty(texto)) return string.Empty;

            using (Aes aes = Aes.Create())
            {
                byte[] claveBytes = ObtenerClave(clave, aes.KeySize / 8);
                aes.Key = claveBytes;
                aes.GenerateIV();

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
                    byte[] cifrado = encryptor.TransformFinalBlock(textoBytes, 0, textoBytes.Length);

                    string ivBase64 = Convert.ToBase64String(aes.IV);
                    string dataBase64 = Convert.ToBase64String(cifrado);
                    return $"{ivBase64}:{dataBase64}";
                }
            }
        }

        private static string Desencriptar(string textoEncriptado, string clave)
        {
            if (string.IsNullOrEmpty(textoEncriptado)) return string.Empty;

            string[] partes = textoEncriptado.Split(':');
            if (partes.Length != 2)
                throw new FormatException("Formato de archivo inválido o incompatible.");

            byte[] iv = Convert.FromBase64String(partes[0]);
            byte[] cifradoBytes = Convert.FromBase64String(partes[1]);

            using (Aes aes = Aes.Create())
            {
                byte[] claveBytes = ObtenerClave(clave, aes.KeySize / 8);
                aes.Key = claveBytes;
                aes.IV = iv;
                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    byte[] descifrado = decryptor.TransformFinalBlock(cifradoBytes, 0, cifradoBytes.Length);
                    return Encoding.UTF8.GetString(descifrado);
                }
            }
        }

        private static byte[] ObtenerClave(string clave, int tamaño)
        {
            using (var sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(clave));
                Array.Resize(ref hash, tamaño);
                return hash;
            }
        }

        public List<cls_InformeATDTO> ObtenerInformesPorDni(int dni)
        {
            return _informesQ.ObtenerInformesPorDNI(dni);
        }

        public int ObtenerIdAcompanamiento(int dniPaciente)
        {
            return _informesQ.ObtenerIdAcompanamiento(dniPaciente);
        }

        public bool GuardarInforme(cls_InformeATDTO informe)
        {
            try
            {
                
                if (informe == null)
                    throw new ArgumentNullException("El informe no puede ser nulo");

                if (informe.id_acompanamiento <= 0)
                    throw new Exception("Debe especificar un acompañamiento válido");


                return _informesQ.GuardarInforme(informe);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en lógica al guardar informe: {ex.Message}");
                throw; 
            }

        }

        public bool ActualizarInforme(cls_InformeATDTO informe)
        {
            try
            {
                // Validaciones de negocio
                if (informe == null)
                    throw new ArgumentNullException("El informe no puede ser nulo");

                if (string.IsNullOrEmpty(informe.id_informe_at))
                    throw new Exception("No se puede actualizar un informe sin ID");

                return _informesQ.ActualizarInforme(informe);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en lógica al actualizar informe: {ex.Message}");
                throw;
            }
        }
    }
}

