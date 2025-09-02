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

        /// Item1: List<cls_PermisoDTO> - Permisos asignados al rol.
        /// Item2: List<cls_PermisoDTO> - Permisos disponibles (no asignados) para el rol.
        public Tuple<List<cls_PermisoDTO>, List<cls_PermisoDTO>> ObtenerPermisosParaGestionDeRol(int idRol)
        {
            // Obtener todos los permisos existentes en el sistema
            List<cls_PermisoDTO> todosLosPermisos = _permisosQ.ObtenerTodosLosPermisos(); // Necesitarás un nuevo método en cls_PermisosQ

            // Obtener los permisos actualmente asignados al rol
            List<cls_PermisoDTO> permisosAsignadosAlRol = _permisosQ.ObtenerPermisosPorRol(idRol); // Necesitarás un nuevo método en cls_PermisosQ

            // Calcular los permisos disponibles (todos los permisos menos los asignados)
            List<cls_PermisoDTO> permisosDisponibles = todosLosPermisos
                                                        .Where(p => !permisosAsignadosAlRol.Any(pa => pa.IdPermiso == p.IdPermiso))
                                                        .ToList();

            return Tuple.Create(permisosAsignadosAlRol, permisosDisponibles);
        }

        public void CargarPermisosParaRolSeleccionado(int idRolSeleccionado, ListView _listaPermisos, ListView _listaDisponibles)
        {
            ListView ltvPermisosAsignados = _listaPermisos;
            ListView ltvPermisosDisp = _listaDisponibles;
            // Limpiar los ListViews antes de cargar nuevos datos
            ltvPermisosAsignados.Items.Clear();
            ltvPermisosDisp.Items.Clear();

            // Usa la instancia ya creada
            Tuple<List<cls_PermisoDTO>, List<cls_PermisoDTO>> resultado = ObtenerPermisosParaGestionDeRol(idRolSeleccionado);

            List<cls_PermisoDTO> permisosAsignados = resultado.Item1;
            List<cls_PermisoDTO> permisosDisponibles = resultado.Item2;

            // Llenar ltvPermisosAsignados
            foreach (var permiso in permisosAsignados)
            {
                ListViewItem item = new ListViewItem(permiso.NombrePermiso);
                item.SubItems.Add(permiso.Descripcion);
                item.Tag = permiso.IdPermiso; // Almacena el ID para futuras operaciones
                ltvPermisosAsignados.Items.Add(item);
            }

            // Llenar ltvPermisosDisp
            foreach (var permiso in permisosDisponibles)
            {
                ListViewItem item = new ListViewItem(permiso.NombrePermiso);
                item.SubItems.Add(permiso.Descripcion);
                item.Tag = permiso.IdPermiso; // Almacena el ID para futuras operaciones
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
                // Aquí podrías loggear el error o lanzar una excepción personalizada
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
                // Aquí podrías loggear el error o lanzar una excepción personalizada
                throw new Exception($"Error en la lógica al desasignar permiso {idPermiso} del rol {idRol}: {ex.Message}", ex);
            }
        }
    }
    
}
