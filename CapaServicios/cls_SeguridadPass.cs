using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace CapaUtilidades
{
    public static class cls_SeguridadPass
    {
        // Métodos para Hashing
        #region Hashing

        public static string GenerarHashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BytesToHexString(bytes);
            }
        }

        public static bool VerificarHashSHA256(string input, string hash)
        {
            string hashOfInput = GenerarHashSHA256(input);
            return hashOfInput.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }

        private static string BytesToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2")); // Formato hexadecimal
            }
            return sb.ToString();
        }
        #endregion

        // Métodos para Dígito Verificador
        #region Dígito Verificador

        public static int CalcularDigitoVerificadorMod11(string cadena)
        {
            int[] factores = { 3, 2, 7, 6, 5, 4, 3, 2 }; // Factores típicos para RUTs/DNIs
            int suma = 0;

            for (int i = 0; i < cadena.Length; i++)
            {
                int digito = int.Parse(cadena[i].ToString());
                suma += digito * factores[i % factores.Length];
            }

            int resto = suma % 11;
            return resto == 0 ? 0 : 11 - resto;
        }

        public static bool ValidarDigitoVerificadorMod11(string cadenaCompleta)
        {
            if (string.IsNullOrEmpty(cadenaCompleta) || cadenaCompleta.Length < 2)
                return false;

            string cuerpo = cadenaCompleta.Substring(0, cadenaCompleta.Length - 1);
            char digitoVerificador = cadenaCompleta.Last();

            int digitoCalculado = CalcularDigitoVerificadorMod11(cuerpo);
            return digitoCalculado.ToString() == digitoVerificador.ToString();
        }

        // Alternativa para códigos de control más simples
        public static char CalcularDigitoVerificadorSimple(string cadena)
        {
            int suma = cadena.Sum(c => (int)c);
            return (char)((suma % 10) + 48); // Retorna un dígito ASCII ('0'-'9')
        }
        #endregion

        // Métodos adicionales útiles
        #region Utilitarios

        public static string GenerarSalt(int length = 32)
        {
            byte[] salt = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public static string HashConSalt(string input, string salt)
        {
            return GenerarHashSHA256(input + salt);
        }
        #endregion
    }
}