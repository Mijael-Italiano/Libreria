using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.Data
{
    public class CategoriaData
    {
        public List<Categoria> ConsultarCategorias()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Categorias.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Categorias.xml no tiene una raiz valida.");

                var consulta =
                    from categoria in raiz.Elements("Categoria")
                    select new Categoria
                    {
                        Id = int.Parse(categoria.Attribute("Id")?.Value ?? throw new Exception("Hay una categoria sin Id.")),
                        Nombre = ObtenerValor(categoria, "Nombre"),
                        Estado = bool.Parse(ObtenerValor(categoria, "Estado")),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaCategoria(Categoria categoria, int id)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Categorias.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Categorias.xml no tiene una raiz valida.");

                XElement nuevaCategoria = new XElement(
                    "Categoria",
                    new XAttribute("Id", id),
                    new XElement("Nombre", categoria.Nombre),
                    new XElement("Estado", categoria.Estado)
                );

                raiz.Add(nuevaCategoria);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarCategoria(Categoria categoria)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Categorias.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Categorias.xml no tiene una raiz valida.");

                XElement categoriaXml = raiz.Elements("Categoria").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay una categoria sin Id.")) == categoria.Id
                ) ?? throw new Exception("No se encontro la categoria indicada.");

                categoriaXml.SetElementValue("Nombre", categoria.Nombre);
                categoriaXml.SetElementValue("Estado", categoria.Estado);

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarEstadoCategoria(int id, bool estado)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Categorias.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Categorias.xml no tiene una raiz valida.");

                XElement categoriaXml = raiz.Elements("Categoria").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay una categoria sin Id.")) == id
                ) ?? throw new Exception("No se encontro la categoria indicada.");

                categoriaXml.SetElementValue("Estado", estado);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Categoria> BuscarCategorias(string nombre, bool incluirNoActivas)
        {
            try
            {
                IEnumerable<Categoria> categorias = this.ConsultarCategorias();

                if (!incluirNoActivas)
                {
                    categorias = categorias.Where(categoria => categoria.Estado);
                }

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    categorias = categorias.Where(categoria =>
                        categoria.Nombre.StartsWith(nombre.Trim(), StringComparison.OrdinalIgnoreCase)
                    );
                }

                return categorias.ToList();
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
                List<Categoria> categorias = this.ConsultarCategorias();

                if (categorias.Count == 0)
                {
                    return 1;
                }

                return categorias.Max(categoria => categoria.Id) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay una categoria sin {nombre}.");
        }
    }
}
