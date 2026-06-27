using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.Data
{
    public class ColorData
    {
        public List<ColorProducto> ConsultarColores()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Colores.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Colores.xml no tiene una raiz valida.");

                var consulta =
                    from color in raiz.Elements("Color")
                    select new ColorProducto
                    {
                        Id = int.Parse(color.Attribute("Id")?.Value ?? throw new Exception("Hay un color sin Id.")),
                        Nombre = ObtenerValor(color, "Nombre"),
                        Estado = bool.Parse(ObtenerValor(color, "Estado")),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaColor(ColorProducto color, int id)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Colores.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Colores.xml no tiene una raiz valida.");

                XElement nuevoColor = new XElement(
                    "Color",
                    new XAttribute("Id", id),
                    new XElement("Nombre", color.Nombre),
                    new XElement("Estado", color.Estado)
                );

                raiz.Add(nuevoColor);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarColor(ColorProducto color)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Colores.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Colores.xml no tiene una raiz valida.");

                XElement colorXml = raiz.Elements("Color").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un color sin Id.")) == color.Id
                ) ?? throw new Exception("No se encontro el color indicado.");

                colorXml.SetElementValue("Nombre", color.Nombre);
                colorXml.SetElementValue("Estado", color.Estado);

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarEstadoColor(int id, bool estado)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Colores.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Colores.xml no tiene una raiz valida.");

                XElement colorXml = raiz.Elements("Color").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un color sin Id.")) == id
                ) ?? throw new Exception("No se encontro el color indicado.");

                colorXml.SetElementValue("Estado", estado);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ColorProducto> BuscarColores(string nombre, bool incluirNoActivos)
        {
            try
            {
                IEnumerable<ColorProducto> colores = this.ConsultarColores();

                if (!incluirNoActivos)
                {
                    colores = colores.Where(color => color.Estado);
                }

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    colores = colores.Where(color =>
                        color.Nombre.StartsWith(nombre.Trim(), StringComparison.OrdinalIgnoreCase)
                    );
                }

                return colores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ObtenerProximoId()
        {
            try
            {
                List<ColorProducto> colores = this.ConsultarColores();

                if (colores.Count == 0)
                {
                    return 1;
                }

                return colores.Max(color => color.Id) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay un color sin {nombre}.");
        }
    }
}
