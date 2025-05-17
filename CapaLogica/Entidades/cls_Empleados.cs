using CapaDatos.Entidades;
using System;
using System.Data;

namespace CapaLogicaNegocio.Entidades
{
    public class cls_Empleados
    {
        cls_EmpleadosQ datos_emp = new cls_EmpleadosQ();

        public int Id_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Id_Sexo { get; set; }
        public int Id_Tipodni { get; set; }
        public int Dni { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int Id_Localidad { get; set; }
        public string Calle { get; set; }
        public int Numero_Calle { get; set; }
        public int Id_Cargo { get; set; }
        public bool Estado { get; set; }

        public DataTable VerEmpleados(string datos = "")
        {
            return datos_emp.ObtenerEmpleados(datos);
        }

        public void AgregarEmpleado()
        {
            datos_emp.Nombre = Nombre;
            datos_emp.Apellido = Apellido;
            datos_emp.Id_Sexo = Id_Sexo;
            datos_emp.Id_Tipodni = Id_Tipodni;
            datos_emp.Dni = Dni;
            datos_emp.Fecha_Nac = Fecha_Nac;
            datos_emp.Email = Email;
            datos_emp.Telefono = Telefono;
            datos_emp.Id_Localidad = Id_Localidad;
            datos_emp.Calle = Calle;
            datos_emp.Numero_Calle = Numero_Calle;
            datos_emp.Id_Cargo = Id_Cargo;
            datos_emp.Estado = Estado;

            datos_emp.AgregarEmp();
        }

        public void ModificarEmpleado()
        {
            datos_emp.Id_Empleado = Id_Empleado;
            datos_emp.Nombre = Nombre;
            datos_emp.Apellido = Apellido;
            datos_emp.Id_Sexo = Id_Sexo;
            datos_emp.Id_Tipodni = Id_Tipodni;
            datos_emp.Dni = Dni;
            datos_emp.Fecha_Nac = Fecha_Nac;
            datos_emp.Email = Email;
            datos_emp.Telefono = Telefono;
            datos_emp.Id_Localidad = Id_Localidad;
            datos_emp.Calle = Calle;
            datos_emp.Numero_Calle = Numero_Calle;
            datos_emp.Id_Cargo = Id_Cargo;
            datos_emp.Estado = Estado; 

            datos_emp.ModificarEmp();
        }
        public void EliminarEmpleado(int idEmpleado)
        {
            datos_emp.EliminarEmp(idEmpleado);
        }



    }
}