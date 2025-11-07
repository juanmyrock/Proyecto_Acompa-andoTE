using System;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CapaUtilidades
{
    public static class cls_CrearPDF
    {
        private static string rutaReportes = @"C:\Reportes";
        private static string prefijo = "RT";

        static cls_CrearPDF()
        {
            // Crear directorio si no existe
            if (!Directory.Exists(rutaReportes))
            {
                Directory.CreateDirectory(rutaReportes);
            }
        }

        public static string GenerarPDFConNumeracion(string titulo, string contenido)
        {
            try
            {
                // Obtener el próximo número de secuencia
                string numeroSecuencia = ObtenerProximoNumero();
                string nombreArchivo = $"{prefijo}-{numeroSecuencia}.pdf";
                string rutaCompleta = Path.Combine(rutaReportes, nombreArchivo);

                // Crear el documento PDF
                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);

                    document.Open();

                    // Agregar título
                    Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
                    Paragraph tituloParagraph = new Paragraph(titulo, tituloFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    document.Add(tituloParagraph);

                    // Agregar número de reporte
                    Font numeroFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY);
                    Paragraph numeroParagraph = new Paragraph($"Reporte: {prefijo}-{numeroSecuencia}", numeroFont)
                    {
                        Alignment = Element.ALIGN_RIGHT,
                        SpacingAfter = 10f
                    };
                    document.Add(numeroParagraph);

                    // Agregar fecha
                    Paragraph fechaParagraph = new Paragraph($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}", numeroFont)
                    {
                        Alignment = Element.ALIGN_RIGHT,
                        SpacingAfter = 20f
                    };
                    document.Add(fechaParagraph);

                    // Agregar contenido
                    Font contenidoFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
                    Paragraph contenidoParagraph = new Paragraph(contenido, contenidoFont)
                    {
                        Alignment = Element.ALIGN_JUSTIFIED
                    };
                    document.Add(contenidoParagraph);

                    document.Close();
                }

                return rutaCompleta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar PDF: {ex.Message}");
            }
        }

        private static string ObtenerProximoNumero()
        {
            try
            {
                // Buscar archivos existentes con el patrón RT-001.pdf
                var archivos = Directory.GetFiles(rutaReportes, $"{prefijo}-*.pdf")
                    .Select(Path.GetFileNameWithoutExtension)
                    .Where(name => name.StartsWith($"{prefijo}-"))
                    .ToList();

                if (archivos.Count == 0)
                {
                    return "001"; // Primer reporte
                }

                // Extraer números y encontrar el máximo
                int maxNumero = archivos
                    .Select(name =>
                    {
                        string numeroStr = name.Replace($"{prefijo}-", "");
                        return int.TryParse(numeroStr, out int num) ? num : 0;
                    })
                    .Max();

                // Incrementar y formatear a 3 dígitos
                return (maxNumero + 1).ToString("D3");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener próximo número: {ex.Message}");
            }
        }

        // Método sobrecargado para más personalización
        public static string GenerarPDFConNumeracion(string titulo, string contenido, string contenidoAdicional = "")
        {
            string contenidoCompleto = contenido;

            if (!string.IsNullOrEmpty(contenidoAdicional))
            {
                contenidoCompleto += $"\n\n{contenidoAdicional}";
            }

            return GenerarPDFConNumeracion(titulo, contenidoCompleto);
        }

        // Método para generar PDF con DataTable
        public static string GenerarPDFDesdeDataTable(string titulo, System.Data.DataTable dataTable)
        {
            try
            {
                string numeroSecuencia = ObtenerProximoNumero();
                string nombreArchivo = $"{prefijo}-{numeroSecuencia}.pdf";
                string rutaCompleta = Path.Combine(rutaReportes, nombreArchivo);

                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4.Rotate(), 50, 50, 50, 50); // Horizontal para tablas
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);

                    document.Open();

                    // Título
                    Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
                    document.Add(new Paragraph(titulo, tituloFont) { Alignment = Element.ALIGN_CENTER });
                    document.Add(new Paragraph($" ")); // Espacio

                    // Crear tabla
                    PdfPTable table = new PdfPTable(dataTable.Columns.Count);
                    table.WidthPercentage = 100;

                    // Encabezados de columna
                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
                    foreach (System.Data.DataColumn column in dataTable.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, headerFont))
                        {
                            BackgroundColor = new BaseColor(70, 130, 180), // Azul
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5
                        };
                        table.AddCell(cell);
                    }

                    // Datos
                    Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);
                    foreach (System.Data.DataRow row in dataTable.Rows)
                    {
                        foreach (var cell in row.ItemArray)
                        {
                            table.AddCell(new PdfPCell(new Phrase(cell?.ToString() ?? "", cellFont))
                            {
                                Padding = 4
                            });
                        }
                    }

                    document.Add(table);
                    document.Close();
                }

                return rutaCompleta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar PDF desde DataTable: {ex.Message}");
            }
        }

        // Método para obtener la lista de reportes existentes
        public static string[] ObtenerReportesExistentes()
        {
            return Directory.GetFiles(rutaReportes, $"{prefijo}-*.pdf")
                .OrderBy(f => f)
                .ToArray();
        }
    }
}