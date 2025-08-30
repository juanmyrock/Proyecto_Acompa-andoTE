using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDTO;

namespace CapaLogica.Login
{
    public class cls_ParametrosContraseña
    {
        
            private cls_ParamContraseñaQ parametrosContraQ;

            public cls_ParametrosContraseña()
            {
                parametrosContraQ = new cls_ParamContraseñaQ();
             
            }

            public cls_ParamContraseñaDTO ObtenerParametros()
            {
                try
                {
                    return parametrosContraQ.ObtenerParametro();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en la capa lógica al obtener parámetros: {ex.Message}");
                    return null;
                }
            }

            public bool ModificarParametros(cls_ParamContraseñaDTO parametros)
        {
            try
            {
                return parametrosContraQ.ModificarParametros(parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al modificar parámetros de contraseña: {ex.Message}");
                return false; 
            }
        }
    }
}
