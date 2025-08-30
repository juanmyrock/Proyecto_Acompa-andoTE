using CapaDatos;
using CapaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaLogica.ABM
{
    public class cls_Rol
    {
        private cls_RolQ _rolQ;
        private cls_Rol _rol;

        public cls_Rol()
        {
            _rolQ = new cls_RolQ();
        }

        public List<cls_RolDTO> ObtenerRoles()
        { 
            List<cls_RolDTO> listaRoles = new List<cls_RolDTO>();
            
            try
            {
                DataTable dtRol = _rolQ.ObtenerTodosLosRoles();

                foreach (DataRow row in dtRol.Rows)
                {
                    listaRoles.Add(new cls_RolDTO
                 
                    {
                        IdRol = Convert.ToInt32(row["id_rol"]),
                        NombreRol = row["nombre_rol"].ToString(),
                        Descripcion = row["descripcion"]?.ToString()
                    }
                    );
                    
                }
            }
            catch (Exception)
            {
                return null;
            }
            return listaRoles;
        }

        public void InsertarRol(cls_RolDTO rol)
        {
            try
            {
                _rolQ.InsertarRol(rol);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el rol: " + ex.Message);
            }
        }

        public void ActualizarRol(cls_RolDTO rol)
        {
            try
            {
                _rolQ.ActualizarRol(rol);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el rol: " + ex.Message);
            }
        }

        public void EliminarRol(int idRol)
        {
            try
            {
                _rolQ.EliminarRol(idRol);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el rol: " + ex.Message);
            }
        }
        public void CargarRolesEnDataGridView(DataGridView listaRoles)
        {
            _rol = new cls_Rol();
            try
            {
                List<cls_RolDTO> listaRol = _rol.ObtenerRoles();
                listaRoles.DataSource = listaRol;

                listaRoles.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                listaRoles.ReadOnly = true;
                listaRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                listaRoles.AllowUserToAddRows = false;
                //listaRoles.Columns["IdRol"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles en la vista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
