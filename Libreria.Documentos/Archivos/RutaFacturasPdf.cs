using System;
using System.IO;
using System.Linq;
using System.Text;
using Libreria.Entity;

namespace Libreria.Documentos.Archivos
{
    public static class RutaFacturasPdf
    {
        private const string CarpetaRaiz = "PDFs";

        public static string ObtenerRutaFactura(Factura factura, string tipoDocumento, DateTime fechaDocumento)
        {
            if (factura == null)
            {
                throw new ArgumentNullException(nameof(factura));
            }

            string carpetaFactura = ObtenerCarpetaFactura(factura, fechaDocumento);
            string nombreArchivo = $"{NormalizarSegmento(tipoDocumento)}_{fechaDocumento:yyyyMMdd_HHmmss}.pdf";
            return ObtenerRutaDisponible(Path.Combine(carpetaFactura, nombreArchivo));
        }


        private static string ObtenerCarpetaFactura(Factura factura, DateTime fecha)
        {
            string carpetaDia = ObtenerCarpetaDia(fecha);
            string nombreCarpeta = $"Factura_{factura.IdFactura:000000}";
            string carpetaFactura = Path.Combine(carpetaDia, nombreCarpeta);

            Directory.CreateDirectory(carpetaFactura);
            return carpetaFactura;
        }
        private static string ObtenerCarpetaDia(DateTime fecha)
        {
            string carpeta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                CarpetaRaiz,
                fecha.ToString("yyyy-MM-dd")
            );

            Directory.CreateDirectory(carpeta);
            return carpeta;
        }

        private static string ObtenerNombreCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                return "Cliente";
            }

            string nombre = $"{cliente.Apellido}_{cliente.Nombre}";
            return NormalizarSegmento(nombre);
        }

        private static string NormalizarSegmento(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return "Documento";
            }

            char[] invalidos = Path.GetInvalidFileNameChars();
            StringBuilder resultado = new StringBuilder();

            foreach (char caracter in valor.Trim())
            {
                if (invalidos.Contains(caracter))
                {
                    continue;
                }

                if (char.IsWhiteSpace(caracter))
                {
                    resultado.Append('_');
                    continue;
                }

                resultado.Append(caracter);
            }

            string segmento = resultado.ToString().Trim('_');
            return string.IsNullOrWhiteSpace(segmento) ? "Documento" : segmento;
        }

        private static string ObtenerRutaDisponible(string ruta)
        {
            if (!File.Exists(ruta))
            {
                return ruta;
            }

            string carpeta = Path.GetDirectoryName(ruta) ?? AppDomain.CurrentDomain.BaseDirectory;
            string nombre = Path.GetFileNameWithoutExtension(ruta);
            string extension = Path.GetExtension(ruta);
            int contador = 1;

            string rutaCandidata;
            do
            {
                rutaCandidata = Path.Combine(carpeta, $"{nombre}_{contador}{extension}");
                contador++;
            }
            while (File.Exists(rutaCandidata));

            return rutaCandidata;
        }
    }
}


