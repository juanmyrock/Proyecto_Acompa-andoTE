using System;
using System.Collections.Generic;

namespace CapaSesion.Login
{
    // Clase que gestiona la sesión del usuario actual utilizando el patrón Singleton
    public sealed class SesionUsuario
    {
        // Campo estático que almacenará la única instancia de la clase
        private static SesionUsuario _instancia;

        // Objeto usado para garantizar que la instancia se cree de forma segura en entornos multihilo
        private static readonly object _bloqueo = new object();

        // Constructor privado para evitar que se instancien objetos desde fuera de la clase
        private SesionUsuario() { }

        // Propiedad pública para acceder a la única instancia de la clase (patrón Singleton)
        public static SesionUsuario Instancia
        {
            get
            {
                // Verifica si la instancia ya fue creada
                if (_instancia == null)
                {
                    // Bloquea el acceso a otros hilos mientras se crea la instancia
                    lock (_bloqueo)
                    {
                        // Doble verificación en caso de que otro hilo la haya creado mientras este esperaba
                        if (_instancia == null)
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
        public int IdEmpleado { get; private set; }
        public string NombreUsuario { get; private set; }
        public string PasswordUsuario { get; private set; }
        public bool EstadoUsuario { get; private set; }
        public DateTime FechaAlta { get; private set; }
        public int IdRol { get; private set; }
        public string NombreEmpleado { get; private set; }
        public string ApellidoEmpleado { get; private set; }
        public List<string> Permisos { get; private set; } = new List<string>();

        // Propiedad calculada para saber si hay una sesión iniciada (basada en IdUsuario distinto de 0)
        public bool EstaSesionIniciada => IdUsuario != 0;

        // Método que se llama una vez que el login fue exitoso, para cargar los datos del usuario
        public void IniciarSesion(int idUsuario, int idEmpleado, string nombreUsuario, string passwordUsuario,
                                  bool estadoUsuario, DateTime fechaAlta, int idRol,
                                  string nombreEmpleado, string apellidoEmpleado,
                                  List<string> permisos)
        {
            IdUsuario = idUsuario;
            IdEmpleado = idEmpleado;
            NombreUsuario = nombreUsuario;
            PasswordUsuario = passwordUsuario;
            EstadoUsuario = estadoUsuario;
            FechaAlta = fechaAlta;
            IdRol = idRol;
            NombreEmpleado = nombreEmpleado;
            ApellidoEmpleado = apellidoEmpleado;
            Permisos = permisos ?? new List<string>(); // si es null, inicializa con lista vacía
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
