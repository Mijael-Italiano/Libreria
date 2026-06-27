using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.Data
{
    public class MarcaData
    {
        public List<Marca> ConsultarMarcas()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Marcas.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Marcas.xml no tiene una raiz valida.");

                var consulta =
                    from marca in raiz.Elements("Marca")
                    select new Marca
                    {
                        Id = int.Parse(marca.Attribute("Id")?.Value ?? throw new Exception("Hay una marca sin Id.")),
                        Nombre = ObtenerValor(marca, "Nombre"),
                        Estado = bool.Parse(ObtenerValor(marca, "Estado")),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaMarca(Marca marca, int id)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Marcas.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Marcas.xml no tiene una raiz valida.");

                XElement nuevaMarca = new XElement(
                    "Marca",
                    new XAttribute("Id", id),
                    new XElement("Nombre", marca.Nombre),
                    new XElement("Estado", marca.Estado)
                );

                raiz.Add(nuevaMarca);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarMarca(Marca marca)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Marcas.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Marcas.xml no tiene una raiz valida.");

                XElement marcaXml = raiz.Elements("Marca").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay una marca sin Id.")) == marca.Id
                ) ?? throw new Exception("No se encontro la marca indicada.");

                marcaXml.SetElementValue("Nombre", marca.Nombre);
                marcaXml.SetElementValue("Estado", marca.Estado);

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarEstadoMarca(int id, bool estado)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Marcas.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Marcas.xml no tiene una raiz valida.");

                XElement marcaXml = raiz.Elements("Marca").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay una marca sin Id.")) == id
                ) ?? throw new Exception("No se encontro la marca indicada.");

                marcaXml.SetElementValue("Estado", estado);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Marca> BuscarMarcas(string nombre, bool incluirNoActivas)
        {
            try
            {
                IEnumerable<Marca> marcas = this.ConsultarMarcas();

                if (!incluirNoActivas)
                {
                    marcas = marcas.Where(marca => marca.Estado);
                }

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    marcas = marcas.Where(marca =>
                        marca.Nombre.StartsWith(nombre.Trim(), StringComparison.OrdinalIgnoreCase)
                    );
                }

                return marcas.ToList();
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
                List<Marca> marcas = this.ConsultarMarcas();

                if (marcas.Count == 0)
                {
                    return 1;
                }

                return marcas.Max(marca => marca.Id) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay una marca sin {nombre}.");
        }
    }
}
