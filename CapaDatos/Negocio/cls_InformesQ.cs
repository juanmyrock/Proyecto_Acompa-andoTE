using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Negocio
{
    public class cls_InformesQ
    {
        private cls_EjecutarQ _ejecutor;
        public cls_InformesQ()
        {
            _ejecutor = new cls_EjecutarQ();
        }


        public List<cls_InformeATDTO> ObtenerInformesPorDNI(int dni)
        {
            string query = @"SELECT 
            p.id_paciente,
            p.dni_paciente,
            p.nombre,
            p.apellido,
            p.cargahoraria_at,
            ac.id_acompanamiento,
            inf.id_informe_at,
            inf.fecha_periodo,
            inf.id_usuario_creador,
            inf.fecha_creacion,
            inf.prestador,
            inf.prestacion,
            inf.ruta
            FROM Pacientes p
            INNER JOIN Acompanamientos ac ON p.id_paciente = ac.id_paciente
            LEFT JOIN Informes_AT inf ON ac.id_acompanamiento = inf.id_acompanamiento
            WHERE p.dni_paciente = @DniPaciente";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@DniPaciente", dni)
            };

            DataTable tabla = _ejecutor.ConsultaRead(query, parametros);
            var listaInformes = new List<cls_InformeATDTO>();


            foreach (DataRow row in tabla.Rows)
            {
                try
                {
                    var informe = new cls_InformeATDTO
                    {
                        id_paciente = Convert.ToInt32(row["id_paciente"]),
                        dni_paciente = Convert.ToInt32(row["dni_paciente"]),
                        nombre_paciente = row["nombre"]?.ToString() ?? string.Empty,
                        apellido_paciente = row["apellido"]?.ToString() ?? string.Empty,
                        cargahoraria_at = Convert.ToDecimal(row["cargahoraria_at"]),
                        id_acompanamiento = Convert.ToInt32(row["id_acompanamiento"]),
                        id_informe_at = row["id_informe_at"] != DBNull.Value ? row["id_informe_at"].ToString() : string.Empty,
                        fecha_periodo = row["fecha_periodo"] != DBNull.Value ? Convert.ToDateTime(row["fecha_periodo"]) : DateTime.MinValue,
                        id_usuario_creador = row["id_usuario_creador"] != DBNull.Value ? Convert.ToInt32(row["id_usuario_creador"]) : 0,
                        fecha_creacion = row["fecha_creacion"] != DBNull.Value ? Convert.ToDateTime(row["fecha_creacion"]) : DateTime.MinValue,
                        prestador = row["prestador"]?.ToString() ?? string.Empty,
                        prestacion = row["prestacion"]?.ToString() ?? string.Empty,
                        ruta = row["ruta"]?.ToString() ?? string.Empty
                    };

                    listaInformes.Add(informe);
                }
                catch (Exception ex)
                {

                }
            }
            return listaInformes;
        }

        public bool ActualizarInforme(cls_InformeATDTO informe)
        {
            string query = @"
        UPDATE Informes_AT 
        SET id_acompanamiento = @IdAcompanamiento,
            fecha_periodo = @FechaPeriodo,
            id_usuario_creador = @IdUsuarioCreador,
            fecha_creacion = @FechaCreacion,
            prestador = @Prestador,
            prestacion = @Prestacion,
            ruta = @Ruta
        WHERE id_informe_at = @IdInformeAT";

            try
            {
                var parametros = new List<SqlParameter>
        {
            new SqlParameter("@IdInformeAT", informe.id_informe_at),
            new SqlParameter("@IdAcompanamiento", informe.id_acompanamiento),
            new SqlParameter("@FechaPeriodo", informe.fecha_periodo),
            new SqlParameter("@IdUsuarioCreador", informe.id_usuario_creador),
            new SqlParameter("@FechaCreacion", informe.fecha_creacion),
            new SqlParameter("@Prestador", informe.prestador ?? (object)DBNull.Value),
            new SqlParameter("@Prestacion", informe.prestacion ?? (object)DBNull.Value),
            new SqlParameter("@Ruta", informe.ruta ?? (object)DBNull.Value)
        };

                int filasAfectadas = _ejecutor.ConsultaCUD(query, parametros);
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar informe: {ex.Message}");
                throw;
            }
        }

        public bool InsertarInforme(cls_InformeATDTO informe)
        {
            Console.WriteLine($"=== DEBUG InsertarInforme INICIO ===");

            // Asegurar que tenga GUID
            if (string.IsNullOrEmpty(informe.id_informe_at))
            {
                informe.id_informe_at = Guid.NewGuid().ToString();
                Console.WriteLine($"GUID generado: {informe.id_informe_at}");
            }

            string query = @"
        INSERT INTO Informes_AT 
        (id_informe_at, id_acompanamiento, fecha_periodo, id_usuario_creador, fecha_creacion, prestador, prestacion, ruta)
        VALUES 
        (@id_informe_at, @IdAcompanamiento, @FechaPeriodo, @IdUsuarioCreador, @FechaCreacion, @Prestador, @Prestacion, @Ruta)";

            Console.WriteLine($"Query: {query}");

            try
            {
                var parametros = new List<SqlParameter>
        {
            new SqlParameter("@id_informe_at", informe.id_informe_at),
            new SqlParameter("@IdAcompanamiento", informe.id_acompanamiento),
            new SqlParameter("@FechaPeriodo", informe.fecha_periodo),
            new SqlParameter("@IdUsuarioCreador", informe.id_usuario_creador),
            new SqlParameter("@FechaCreacion", informe.fecha_creacion),
            new SqlParameter("@Prestador", informe.prestador ?? (object)DBNull.Value),
            new SqlParameter("@Prestacion", informe.prestacion ?? (object)DBNull.Value),
            new SqlParameter("@Ruta", informe.ruta ?? (object)DBNull.Value)
        };

                // DEBUG de parámetros
                foreach (var param in parametros)
                {
                    Console.WriteLine($"Parámetro: {param.ParameterName} = {param.Value} (Tipo: {param.Value?.GetType()})");
                }

                int filasAfectadas = _ejecutor.ConsultaCUD(query, parametros);
                Console.WriteLine($"Filas afectadas: {filasAfectadas}");

                bool resultado = filasAfectadas > 0;
                Console.WriteLine($"=== DEBUG InsertarInforme FIN - Resultado: {resultado} ===");
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR en InsertarInforme: {ex.Message}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
                return false;
            }
        }

        public int ObtenerIdAcompanamiento(int dniPaciente)
        {
            try
            {
                // Consulta para obtener el id_acompanamiento del paciente
                string query = @"
                    SELECT TOP 1 id_acompanamiento 
                    FROM Accompanamientos ac
                    INNER JOIN Pacientes p ON ac.id_paciente = p.id_paciente
                    WHERE p.dni_paciente = @DniPaciente
                    ORDER BY ac.fecha_inicio DESC"; // El acompañamiento más reciente

                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@DniPaciente", dniPaciente)
                };

                // Usar tu ejecutor existente
                DataTable resultado = _ejecutor.ConsultaRead(query, parametros);

                if (resultado.Rows.Count > 0)
                {
                    return Convert.ToInt32(resultado.Rows[0]["id_acompanamiento"]);
                }

                // Si no encuentra acompañamiento, podrías crear uno o lanzar excepción
                throw new Exception("No se encontró un acompañamiento activo para el paciente.");
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public bool GuardarInforme(cls_InformeATDTO informe)
        {
            Console.WriteLine($"=== DEBUG GuardarInforme INICIO ===");
            Console.WriteLine($"id_informe_at: '{informe?.id_informe_at}'");
            Console.WriteLine($"id_acompanamiento: {informe?.id_acompanamiento}");

            // VERIFICAR SI EL INFORME EXISTE EN LA BD
            bool existeEnBD = VerificarSiExisteInforme(informe.id_informe_at);
            Console.WriteLine($"Existe en BD: {existeEnBD}");

            if (!string.IsNullOrEmpty(informe.id_informe_at) && existeEnBD)
            {
                Console.WriteLine("-> Ejecutando ACTUALIZACIÓN");
                bool resultadoActualizar = ActualizarInforme(informe);
                Console.WriteLine($"<- Resultado actualización: {resultadoActualizar}");
                return resultadoActualizar;
            }
            else
            {
                Console.WriteLine("-> Ejecutando INSERCIÓN");
                // Si no existe en BD pero tiene GUID, es un nuevo informe
                if (string.IsNullOrEmpty(informe.id_informe_at))
                {
                    informe.id_informe_at = Guid.NewGuid().ToString();
                    Console.WriteLine($"Nuevo GUID generado: {informe.id_informe_at}");
                }
                bool resultadoInsertar = InsertarInforme(informe);
                Console.WriteLine($"<- Resultado inserción: {resultadoInsertar}");
                return resultadoInsertar;
            }
        }

        private bool VerificarSiExisteInforme(string idInforme)
        {
            if (string.IsNullOrEmpty(idInforme))
                return false;

            string query = "SELECT COUNT(1) FROM Informes_AT WHERE id_informe_at = @IdInforme";

            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@IdInforme", idInforme)
    };

            try
            {
                object resultado = _ejecutor.ExecuteScalar(query, parametros);
                int count = resultado != null && resultado != DBNull.Value ? Convert.ToInt32(resultado) : 0;
                Console.WriteLine($"Verificar existencia - Count: {count}");
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar existencia: {ex.Message}");
                return false;
            }
        }
    }
}
