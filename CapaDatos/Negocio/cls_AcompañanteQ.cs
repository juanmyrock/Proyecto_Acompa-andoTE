using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Negocio
{
    public class cls_AcompañanteQ
    {
        private readonly cls_EjecutarQ _ejecutarQ = new cls_EjecutarQ();

        public List<cls_AcompañanteDTO> ObtenerAcompañantes()
        {
            string sp = "SELECT * FROM Acompañantes";

            DataTable tb = _ejecutarQ.ConsultaRead(sp, null);

            List<cls_AcompañanteDTO> listaAcompañantes = new List<cls_AcompañanteDTO>();

            foreach (DataRow row in tb.Rows)
            {
                listaAcompañantes.Add(new cls_AcompañanteDTO
                {
                    id_profesional = Convert.ToInt32(row["id_profesional"]),
                    id_tipo_dni = Convert.ToInt32(row["id_tipo_dni"]),
                    dni = Convert.ToInt32(row["dni"]),
                    nombre = row["nombre"].ToString(),
                    apellido = row["apellido"].ToString(),
                    id_sexo = Convert.ToInt32(row["id_sexo"]),
                    telefono = Convert.ToInt32(row["telefono"]),
                    num_matricula = row["num_matricula"].ToString(),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    email = row["email"].ToString()

                });

            }
            return listaAcompañantes;
        }
    }
}
        
