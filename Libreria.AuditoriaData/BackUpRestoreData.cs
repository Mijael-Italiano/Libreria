using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Libreria.AuditoriaData.BaseDeDatos;

namespace Libreria.AuditoriaData
{
    public class BackUpRestoreData
    {
        public string CrearBackUp()
        {
            try
            {
                string carpetaBaseDeDatos = ObtenerCarpetaBaseDeDatosPrincipal();
                this.ValidarCarpetaBaseDeDatosPrincipal(carpetaBaseDeDatos);

                string nombreBackUp = this.GenerarNombreBackUp();
                string carpetaDestino = Path.Combine(RutaBaseDeDatosAuditoria.ObtenerCarpetaBackUps(), nombreBackUp);

                Directory.CreateDirectory(carpetaDestino);
                this.CopiarArchivosXml(carpetaBaseDeDatos, carpetaDestino);

                return nombreBackUp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RestaurarBackUp(string nombreBackUp)
        {
            try
            {
                string carpetaBackUp = this.ObtenerCarpetaBackUpSegura(nombreBackUp);

                if (!Directory.Exists(carpetaBackUp))
                {
                    throw new Exception("No se encontro el back up seleccionado.");
                }

                string carpetaBaseDeDatos = ObtenerCarpetaBaseDeDatosPrincipal();
                Directory.CreateDirectory(carpetaBaseDeDatos);
                this.CopiarArchivosXml(carpetaBackUp, carpetaBaseDeDatos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> ListarBackUps()
        {
            try
            {
                string carpetaBackUps = RutaBaseDeDatosAuditoria.ObtenerCarpetaBackUps();

                return Directory.GetDirectories(carpetaBackUps)
                    .Select(ruta => new DirectoryInfo(ruta))
                    .OrderByDescending(directorio => directorio.CreationTime)
                    .Select(directorio => directorio.Name)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerCarpetaBaseDeDatosPrincipal()
        {
            return Path.Combine(AppContext.BaseDirectory, "BaseDeDatos");
        }

        private void ValidarCarpetaBaseDeDatosPrincipal(string carpetaBaseDeDatos)
        {
            if (!Directory.Exists(carpetaBaseDeDatos))
            {
                throw new Exception("No se encontro la base de datos principal.");
            }

            if (!Directory.GetFiles(carpetaBaseDeDatos, "*.xml").Any())
            {
                throw new Exception("No hay archivos XML en la base de datos principal.");
            }
        }

        private void CopiarArchivosXml(string carpetaOrigen, string carpetaDestino)
        {
            string[] archivosXml = Directory.GetFiles(carpetaOrigen, "*.xml");

            if (archivosXml.Length == 0)
            {
                throw new Exception("No hay archivos XML para copiar.");
            }

            foreach (string archivoOrigen in archivosXml)
            {
                string archivoDestino = Path.Combine(carpetaDestino, Path.GetFileName(archivoOrigen));
                File.Copy(archivoOrigen, archivoDestino, true);
            }
        }

        private string GenerarNombreBackUp()
        {
            string carpetaBackUps = RutaBaseDeDatosAuditoria.ObtenerCarpetaBackUps();
            string nombreBackUp = $"BackUp_{DateTime.Now:yyyyMMdd_HHmmss}";
            string rutaBackUp = Path.Combine(carpetaBackUps, nombreBackUp);

            if (!Directory.Exists(rutaBackUp))
            {
                return nombreBackUp;
            }

            return $"BackUp_{DateTime.Now:yyyyMMdd_HHmmss_fff}";
        }

        private string ObtenerCarpetaBackUpSegura(string nombreBackUp)
        {
            string carpetaBackUps = Path.GetFullPath(RutaBaseDeDatosAuditoria.ObtenerCarpetaBackUps());
            string carpetaBackUp = Path.GetFullPath(Path.Combine(carpetaBackUps, nombreBackUp));

            if (!carpetaBackUp.StartsWith(carpetaBackUps, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("El nombre del back up no es valido.");
            }

            return carpetaBackUp;
        }
    }
}
