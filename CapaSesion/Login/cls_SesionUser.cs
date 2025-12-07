using System;
using System.Collections.Generic;
using CapaDTO;

namespace CapaSesion.Login
{
    public sealed class SesionUsuario 
    {

        private static SesionUsuario _instancia; 

        private static readonly object _bloqueo = new object();
        private SesionUsuario() { } 
        
        public static SesionUsuario Instancia 
        {
            get
            {
                if (_instancia == null) 
                {
                    lock (_bloqueo) 
                    {
                        if (_instancia == null) 
                        {
                            _instancia = new SesionUsuario();
                        }
                    }
                }
                return _instancia;
            }
        }
        public int IdUsuario { get; private set; }
        public string NombreUsuario { get; private set; }
        public bool EstadoUsuario { get; private set; }
        public int IdRol { get; private set; }
        public string NombreEmpleado { get; private set; }
        public string ApellidoEmpleado { get; private set; }
        public List<string> Permisos { get; private set; } = new List<string>();

       
        public bool EstaSesionIniciada => IdUsuario != 0; 

        public void IniciarSesion(cls_UsuarioDTO usuario, List<string> permisos)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            IdUsuario = usuario.IdUsuario;
            NombreUsuario = usuario.Username;
            EstadoUsuario = usuario.EsActivo ?? false;
            IdRol = usuario.IdRol ?? 0;
            NombreEmpleado = usuario.NombreEmpleado;
            ApellidoEmpleado = usuario.ApellidoEmpleado;
            Permisos = permisos ?? new List<string>();
        }

        public void CerrarSesion()
        {
            _instancia = null;
        }

        public bool TienePermiso(string permiso)
        {
            return Permisos.Contains(permiso);
        }

        public bool EsAdmin => IdRol == 1;
    }
}
