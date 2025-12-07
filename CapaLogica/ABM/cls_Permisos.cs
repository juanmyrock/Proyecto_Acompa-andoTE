using CapaDatos;
using CapaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaLogica.ABM
{
    public class cls_Permisos
    {
        private readonly cls_PermisosQ _permisosQ = new cls_PermisosQ();

        public Tuple<List<cls_PermisoDTO>, List<cls_PermisoDTO>> ObtenerPermisosParaGestionDeRol(int idRol)
        {
            List<cls_PermisoDTO> todosLosPermisos = _permisosQ.ObtenerTodosLosPermisos();
            List<cls_PermisoDTO> permisosAsignadosAlRol = _permisosQ.ObtenerPermisosPorRol(idRol); 
            List<cls_PermisoDTO> permisosDisponibles = todosLosPermisos
                                                        .Where(p => !permisosAsignadosAlRol.Any(pa => pa.IdPermiso == p.IdPermiso))
                                                        .ToList();

            return Tuple.Create(permisosAsignadosAlRol, permisosDisponibles);
        }

        public void CargarPermisosParaRolSeleccionado(int idRolSeleccionado, ListView _listaPermisos, ListView _listaDisponibles)
        {
            ListView ltvPermisosAsignados = _listaPermisos;
            ListView ltvPermisosDisp = _listaDisponibles;
            ltvPermisosAsignados.Items.Clear();
            ltvPermisosDisp.Items.Clear();

            Tuple<List<cls_PermisoDTO>, List<cls_PermisoDTO>> resultado = ObtenerPermisosParaGestionDeRol(idRolSeleccionado);

            List<cls_PermisoDTO> permisosAsignados = resultado.Item1;
            List<cls_PermisoDTO> permisosDisponibles = resultado.Item2;

            foreach (var permiso in permisosAsignados)
            {
                ListViewItem item = new ListViewItem(permiso.NombrePermiso);
                item.SubItems.Add(permiso.Descripcion);
                item.Tag = permiso.IdPermiso;
                ltvPermisosAsignados.Items.Add(item);
            }

            foreach (var permiso in permisosDisponibles)
            {
                ListViewItem item = new ListViewItem(permiso.NombrePermiso);
                item.SubItems.Add(permiso.Descripcion);
                item.Tag = permiso.IdPermiso;
                ltvPermisosDisp.Items.Add(item);
            }
        }

            public void AsignarPermisoARol(int idRol, int idPermiso)
        {
            try
            {
                _permisosQ.AsignarPermisoARol(idRol, idPermiso);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la lógica al asignar permiso {idPermiso} al rol {idRol}: {ex.Message}", ex);
            }
        }

        public void DesasignarPermisoDeRol(int idRol, int idPermiso)
        {
            try
            {
                _permisosQ.DesasignarPermisoDeRol(idRol, idPermiso);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la lógica al desasignar permiso {idPermiso} del rol {idRol}: {ex.Message}", ex);
            }
        }
    }
    
}
