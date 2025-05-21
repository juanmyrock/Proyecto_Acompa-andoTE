using System;
using System.Collections.Generic;
using CapaDTO;

namespace CapaSesion.Login
{
    public sealed class SesionUsuario  // Clase que gestiona la sesión del usuario actual utilizando el patrón Singleton
    {

        private static SesionUsuario _instancia; // almacenará la única instancia de la clase

        private static readonly object _bloqueo = new object();  // Objeto usado para garantizar que la instancia se cree de forma segura en entornos multihilo
        private SesionUsuario() { } // Constructor privado para evitar que se instancien objetos desde fuera de la clase

        
        public static SesionUsuario Instancia // Propiedad pública para acceder a la única instancia de la clase (patrón Singleton)
        {
            get
            {
                if (_instancia == null)  // Verifica si la instancia ya fue creada
                {
                    lock (_bloqueo) // Bloquea el acceso a otros hilos mientras se crea la instancia
                    {
                        if (_instancia == null) // Doble verificación en caso de que otro hilo la haya creado mientras este esperaba
                        {
                            _instancia = new SesionUsuario();
                        }
                    }
                }
                return _instancia;
            }
        }

        // Propiedades públicas con setters privados para almacenar los datos del usuario
        public int IdUsuario { get; private set; }
        public string NombreUsuario { get; private set; }
        public bool EstadoUsuario { get; private set; }
        public int IdRol { get; private set; }
        public string NombreEmpleado { get; private set; }
        public string ApellidoEmpleado { get; private set; }
        public List<string> Permisos { get; private set; } = new List<string>();

       
        public bool EstaSesionIniciada => IdUsuario != 0; // Propiedad calculada para saber si hay una sesión iniciada (basada en IdUsuario distinto de 0)

        // Método que se llama una vez que el login fue exitoso, para cargar los datos del usuario
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

        // Método opcional para "cerrar sesión" (reinicia la instancia)
        public void CerrarSesion()
        {
            _instancia = null;
        }

        // Verifica si el usuario tiene un permiso determinado
        public bool TienePermiso(string permiso)
        {
            return Permisos.Contains(permiso);
        }

        // Verifica si el usuario es administrador (según el IdRol)
        public bool EsAdmin => IdRol == 1;
    }
}

// --- FIN DE LA CLASE ---

/*
 * ------------------------------------------
 * RESUMEN DE LA CLASE SesionUsuario
 * ------------------------------------------
 * 
 * Esta clase implementa el patrón Singleton para garantizar que durante toda la ejecución
 * de la aplicación exista **una única instancia activa** que represente al usuario logueado.
 * 
 * FUNCIONES PRINCIPALES:
 * - Almacena los datos del usuario que inició sesión (Id, nombre, permisos, etc.).
 * - Expone métodos para:
 *     - Inicializar la sesión (IniciarSesion)
 *     - Consultar si la sesión está activa (EstaSesionIniciada)
 *     - Verificar permisos (TienePermiso)
 *     - Determinar si el usuario es administrador (EsAdmin)
 *     - Cerrar sesión y reiniciar la instancia (CerrarSesion)
 * 
 * CLASES RELACIONADAS:
 * - frmLogin (CapaVistas):
 *     - Donde el usuario ingresa credenciales.
 *     - Si es exitoso, se cargan los datos en SesionUsuario.Instancia usando IniciarSesion().
 * 
 * - cls_LogicaLogin (CapaLogica):
 *     - Controla la lógica del login.
 *     - Invoca los métodos de CapaDatos (ValidarUsuario, CargarUsuario).
 *     - Luego pasa los datos a SesionUsuario.
 * 
 * - cls_ConectarUserQ (CapaDatos):
 *     - Ejecuta consultas SQL para validar usuario y recuperar su información.
 * 
 * - frmMenu (CapaVistas):
 *     - Se muestra después del login exitoso.
 *     - Puede usar SesionUsuario.Instancia para mostrar datos del usuario o controlar acceso según rol.
 * 
 * MOTIVO DE USAR SINGLETON:
 * - Garantiza una única referencia global y segura para acceder a los datos del usuario desde cualquier parte de la app.
 * - Facilita la escalabilidad hacia arquitectura cliente-servidor, web o móvil en el futuro.
 * 
 */
