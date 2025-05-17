using System;
using System.Collections.Generic;

namespace CapaSesion
{
    public static class cls_UserCache
    {
        public static int IdUsuario { get; set; }
        public static int IdEmpleado { get; set; }
        public static string NombreUsuario { get; set; }
        public static string PasswordUsuario { get; set; }

        //public static bool RandomPassword { get; set; }
        public static bool EstadoUsuario { get; set; }
        public static DateTime FechaAlta { get; set; }

        //public static DateTime FechaBaja { get; set; }

        //public static DateTime FechaVencePassword { get; set; }

        //public static DateTime FechaUltIngreso { get; set; }
        public static int IdFamilia { get; set; }
        public static string NombreEmpleado { get; set; }
        public static string ApellidoEmpleado { get; set; }


        public static List<string> PermisosUsuario { get; set; } = new List<string>();
    }
}
