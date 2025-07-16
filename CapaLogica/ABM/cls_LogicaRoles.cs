using CapaDatos;
using CapaDatos.ABM; // O el namespace donde tengas cls_RolQ
using CapaDTO;
using System.Collections.Generic;

namespace CapaLogica.ABM
{
    public class cls_LogicaRoles
    {
        private readonly cls_RolQ _rolesDatos = new cls_RolQ();

        public List<cls_RolDTO> ObtenerTodos()
        {
            // Simplemente llama al método que ya tienes en tu capa de datos.
            return _rolesDatos.ObtenerTodosLosRoles();
        }
    }
}