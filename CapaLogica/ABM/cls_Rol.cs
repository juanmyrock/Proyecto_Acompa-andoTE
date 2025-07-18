using CapaDatos;
using CapaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.ABM
{
    public class cls_Rol
    {
        private cls_RolQ _rolQ;

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
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

    }
}
