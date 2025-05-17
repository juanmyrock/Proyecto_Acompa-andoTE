using System;
using System.Data;
using CapaDatos.Entidades;

namespace CapaLogicaNegocio.Entidades
{
    public class cls_Usuarios
    {
        private cls_UsuariosQ datos_usuario = new cls_UsuariosQ();

        // Propiedades del usuario
        public int Id_Usuario { get; set; }
        public int Id_Empleado { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public DateTime Fecha_Baja { get; set; }
        public bool Estado { get; set; }
        public string Usuario { get; set; }
        public string Contraseña_Actual { get; set; }
        public DateTime Fecha_Ult_Ingreso { get; set; }
        public string Contraseña_Aleatoria { get; set; }
        public int Id_Pregunta { get; set; }

        // Método para obtener todos los usuarios
        public DataTable ObtenerUsuarios(string datos)
        {
            return datos_usuario.ReadUser(datos);
        }

        // Método para agregar un usuario
        public void AgregarUsuario()
        {
            AsignarPropiedadesAEntidad();
            datos_usuario.CreateUser();
        }

        // Método para modificar un usuario
        public void ModificarUsuario()
        {
            AsignarPropiedadesAEntidad();
            datos_usuario.UpdateUser();
        }

        // Método para eliminar un usuario
        public void EliminarUsuario(int idUsuario)
        {
            datos_usuario.DeleteUser(idUsuario);
        }

        // Método privado para asignar propiedades a la entidad datos_usuario
        private void AsignarPropiedadesAEntidad()
        {
            datos_usuario.Id_Usuario = this.Id_Usuario;
            datos_usuario.Id_Empleado = this.Id_Empleado;
            datos_usuario.Fecha_Alta = this.Fecha_Alta;
            datos_usuario.Fecha_Baja = this.Fecha_Baja;
            datos_usuario.Estado = this.Estado;
            datos_usuario.Usuario = this.Usuario;
            datos_usuario.Contraseña_Actual = this.Contraseña_Actual;
            datos_usuario.Fecha_Ult_Ingreso = this.Fecha_Ult_Ingreso;
            datos_usuario.Contraseña_Aleatoria = this.Contraseña_Aleatoria;
            datos_usuario.Id_Pregunta = this.Id_Pregunta;
        }
    }
}
