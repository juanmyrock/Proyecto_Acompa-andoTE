using System;
using System.Windows.Forms;
using CapaLogica.ABM;
using CapaLogica.Login;
using CapaDTO;
using System.Collections.Generic;

namespace CapaVistas.Forms_Menu
{
    public partial class frmGestionarUsuario : Form
    {
        // DTO con los datos iniciales que recibe del formulario padre
        private readonly cls_DatosParaGestionUsuarioDTO _datosIniciales;

        // Instancias de las capas de lógica que usaremos
        private readonly cls_LogicaGestionarUsuarios _logicaGestion = new cls_LogicaGestionarUsuarios();
        private readonly cls_LogicaContraseña _logicaContraseña = new cls_LogicaContraseña();

        // DTO para almacenar los datos del usuario cuando se está modificando
        private cls_UsuarioGestionDTO _usuarioActual;

        public frmGestionarUsuario(cls_DatosParaGestionUsuarioDTO datosParaGestion)
        {
            InitializeComponent();
            _datosIniciales = datosParaGestion;
        }

        private void frmGestionarUsuario_Load(object sender, EventArgs e)
        {
            // Mostramos el nombre del empleado en el título
            lblNombreEmpleado.Text = _datosIniciales.NombreCompletoEmpleado;
            CargarRoles(); // Cargamos los roles en el ComboBox

            // --- Lógica para configurar el formulario en modo CREAR o MODIFICAR ---
            if (_datosIniciales.UsuarioYaExiste)
            {
                // MODO MODIFICAR: El usuario ya existe, cargamos sus datos.
                this.Text = "Modificar Usuario Existente";
                btnGuardarRol.Text = "Actualizar Rol";
                CargarDatosUsuarioExistente();
            }
            else
            {
                // MODO CREAR: El empleado no tiene un usuario asociado.
                this.Text = "Crear Nuevo Usuario";
                lblEstadoActual.Text = "NO CREADO";
                lblEstadoActual.ForeColor = System.Drawing.Color.DodgerBlue;
                txtUsername.ReadOnly = false; // Permitimos escribir el nombre de usuario
                txtUsername.Text = "";
                btnGuardarRol.Text = "Crear Usuario y Enviar Email";

                // Deshabilitamos las acciones administrativas que no aplican a un usuario no creado.
                groupAccionesAdmin.Enabled = false;
            }
        }

        /// <summary>
        /// Obtiene y muestra los datos del usuario existente en los controles del formulario.
        /// Este método solo se llama en modo MODIFICAR.
        /// </summary>
        private void CargarDatosUsuarioExistente()
        {
            try
            {
                _usuarioActual = _logicaGestion.ObtenerUsuarioParaGestion(_datosIniciales.IdEmpleado);

                if (_usuarioActual == null)
                {
                    MessageBox.Show("No se pudo cargar la información del usuario.", "Error");
                    this.Close();
                    return;
                }

                txtUsername.Text = _usuarioActual.Username;
                cmbRoles.SelectedValue = _usuarioActual.IdRol ?? -1;

                // Lógica para mostrar el estado y habilitar/deshabilitar botones
                if (_usuarioActual.EstaBloqueado)
                {
                    lblEstadoActual.Text = "BLOQUEADO";
                    lblEstadoActual.ForeColor = System.Drawing.Color.OrangeRed;
                    btnDesbloquear.Enabled = true;
                    btnActivarDesactivar.Enabled = false; // No se puede activar/desactivar si está bloqueado
                }
                else if (_usuarioActual.EsActivo)
                {
                    lblEstadoActual.Text = "ACTIVO";
                    lblEstadoActual.ForeColor = System.Drawing.Color.LimeGreen;
                    btnDesbloquear.Enabled = false;
                    btnActivarDesactivar.Enabled = true;
                    btnActivarDesactivar.Text = "Desactivar";
                }
                else
                {
                    lblEstadoActual.Text = "INACTIVO";
                    lblEstadoActual.ForeColor = System.Drawing.Color.Gray;
                    btnDesbloquear.Enabled = false;
                    btnActivarDesactivar.Enabled = true;
                    btnActivarDesactivar.Text = "Activar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRoles()
        {
            try
            {
                // 1. Llamamos a nuestra nueva capa de lógica para obtener los roles.
                var logicaRoles = new CapaLogica.ABM.cls_Rol();
                List<cls_RolDTO> listaDeRoles = logicaRoles.ObtenerRoles();

                // 2. Usamos nuestro helper reutilizable para cargar el ComboBox.
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbRoles, listaDeRoles, "NombreRol", "IdRol");

                // 3. Volvemos a establecer el valor que tenía el usuario, si es que lo tenía.
                if (_usuarioActual != null)
                {
                    cmbRoles.SelectedValue = _usuarioActual.IdRol ?? -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRoles.Enabled = false;
            }
        }

        // --- Lógica de los Botones ---

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un rol.", "Dato Requerido");
                return;
            }

            if (_datosIniciales.UsuarioYaExiste)
            {
                // Lógica para MODIFICAR ROL
                try
                {
                    int nuevoIdRol = Convert.ToInt32(cmbRoles.SelectedValue);
                    _logicaGestion.ActualizarRolUsuario(_datosIniciales.IdEmpleado, nuevoIdRol);
                    MessageBox.Show("Rol actualizado correctamente.", "Éxito");
                    CargarDatosUsuarioExistente(); // Recargamos para ver el cambio
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el rol: " + ex.Message, "Error");
                }
            }
            else
            {
                // Lógica para CREAR USUARIO
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || cmbRoles.SelectedValue == null)
                {
                    MessageBox.Show("Debe ingresar un nombre de usuario y seleccionar un rol.", "Datos Incompletos");
                    return;
                }

                try
                {
                    int idRol = Convert.ToInt32(cmbRoles.SelectedValue);

                    // Llamamos al método de la lógica, que ahora contiene toda la validación y la transacción.
                    _logicaGestion.CrearUsuarioYEnviarContraseña(
                        _datosIniciales.IdEmpleado,
                        txtUsername.Text,
                        idRol,
                        _datosIniciales.Email,
                        _datosIniciales.NombreCompletoEmpleado);

                    MessageBox.Show("Usuario creado y contraseña temporal enviada con éxito.", "Éxito");
                    this.Close();
                }
                catch (Exception ex)
                {
                    // La lógica ahora nos devolverá un error claro si el email es nulo
                    // o si ocurre cualquier otro problema.
                    MessageBox.Show("Error al crear el usuario: " + ex.Message, "Error");
                }
            }
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea desbloquear a este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _logicaGestion.DesbloquearUsuario(_datosIniciales.IdEmpleado);
                MessageBox.Show("Usuario desbloqueado.", "Éxito");
                CargarDatosUsuarioExistente(); // Recargamos para ver el nuevo estado
            }
        }

        private void btnActivarDesactivar_Click(object sender, EventArgs e)
        {
            bool nuevoEstado = !_usuarioActual.EsActivo;
            string accion = nuevoEstado ? "activar" : "desactivar";
            if (MessageBox.Show($"¿Está seguro de que desea {accion} a este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _logicaGestion.CambiarEstadoUsuario(_datosIniciales.IdEmpleado, nuevoEstado);
                MessageBox.Show($"Usuario {accion} con éxito.", "Éxito");
                CargarDatosUsuarioExistente(); // Recargamos para ver el nuevo estado
            }
        }

        private void btnResetearPass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se enviará una contraseña temporal al correo del usuario. ¿Continuar?", "Resetear Contraseña", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Reutilizamos la lógica del flujo "Olvidé mi contraseña"
                    _logicaContraseña.GenerarYEnviarContraseñaTemporal(_usuarioActual.IdUsuario, _usuarioActual.Email, _usuarioActual.Username);
                    MessageBox.Show("Contraseña temporal enviada con éxito.", "Éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al resetear la contraseña: " + ex.Message);
                }
            }
        }

        private void btnGestionPermisos_Click(object sender, EventArgs e)
        {
            var frmPermisos = new frmPermisos();
            frmPermisos.ShowDialog();
        }
    }
}
