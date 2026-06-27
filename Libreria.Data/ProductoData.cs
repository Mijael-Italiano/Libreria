using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.Data
{
    public class ProductoData
    {
        private readonly MarcaData marcaData;
        private readonly CategoriaData categoriaData;
        private readonly ColorData colorData;

        public ProductoData()
        {
            this.marcaData = new MarcaData();
            this.categoriaData = new CategoriaData();
            this.colorData = new ColorData();
        }

        public List<Producto> ConsultarProductos()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Productos.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Productos.xml no tiene una raiz valida.");

                List<Marca> marcas = this.marcaData.ConsultarMarcas();
                List<Categoria> categorias = this.categoriaData.ConsultarCategorias();
                List<ColorProducto> colores = this.colorData.ConsultarColores();

                var consulta =
                    from producto in raiz.Elements("Producto")
                    let idMarca = ObtenerIdOpcional(producto, "IdMarca")
                    let idCategoria = ObtenerIdOpcional(producto, "IdCategoria")
                    let idColor = ObtenerIdColor(producto)
                    select new Producto
                    {
                        IdProducto = int.Parse(producto.Attribute("Id")?.Value ?? throw new Exception("Hay un producto sin Id.")),
                        Marca = idMarca.HasValue
                            ? marcas.FirstOrDefault(marca => marca.Id == idMarca.Value)
                                ?? throw new Exception("Hay un producto con una marca inexistente.")
                            : null,
                        Categoria = idCategoria.HasValue
                            ? categorias.FirstOrDefault(categoria => categoria.Id == idCategoria.Value)
                                ?? throw new Exception("Hay un producto con una categoria inexistente.")
                            : null,
                        Color = idColor.HasValue
                            ? colores.FirstOrDefault(color => color.Id == idColor.Value)
                                ?? throw new Exception("Hay un producto con un color inexistente.")
                            : null,
                        Descripcion = ObtenerValor(producto, "Descripcion"),
                        PrecioUnitario = decimal.Parse(ObtenerValor(producto, "PrecioUnitario")),
                        StockActual = int.Parse(ObtenerValor(producto, "StockActual")),
                        StockMinimo = int.Parse(ObtenerValor(producto, "StockMinimo")),
                        FechaAlta = DateTime.Parse(ObtenerValorOpcional(producto, "FechaAlta") ?? ObtenerValor(producto, "FechaUltimaActualizacion")),
                        FechaUltimaActualizacion = DateTime.Parse(ObtenerValor(producto, "FechaUltimaActualizacion")),
                        Estado = bool.Parse(ObtenerValor(producto, "Estado")),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaProducto(Producto producto, int id)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Productos.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Productos.xml no tiene una raiz valida.");

                XElement nuevoProducto = new XElement(
                    "Producto",
                    new XAttribute("Id", id),
                    new XElement("IdMarca", producto.Marca?.Id.ToString() ?? string.Empty),
                    new XElement("IdCategoria", producto.Categoria?.Id.ToString() ?? string.Empty),
                    new XElement("IdColor", producto.Color?.Id.ToString() ?? string.Empty),
                    new XElement("Descripcion", producto.Descripcion),
                    new XElement("PrecioUnitario", producto.PrecioUnitario),
                    new XElement("StockActual", producto.StockActual),
                    new XElement("StockMinimo", producto.StockMinimo),
                    new XElement("FechaAlta", producto.FechaAlta),
                    new XElement("FechaUltimaActualizacion", producto.FechaUltimaActualizacion),
                    new XElement("Estado", producto.Estado)
                );

                raiz.Add(nuevoProducto);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarProducto(Producto producto)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Productos.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Productos.xml no tiene una raiz valida.");

                XElement productoXml = raiz.Elements("Producto").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un producto sin Id.")) == producto.IdProducto
                ) ?? throw new Exception("No se encontro el producto indicado.");

                productoXml.SetElementValue("IdMarca", producto.Marca?.Id.ToString() ?? string.Empty);
                productoXml.SetElementValue("IdCategoria", producto.Categoria?.Id.ToString() ?? string.Empty);
                productoXml.SetElementValue("IdColor", producto.Color?.Id.ToString() ?? string.Empty);
                productoXml.SetElementValue("Descripcion", producto.Descripcion);
                productoXml.SetElementValue("PrecioUnitario", producto.PrecioUnitario);
                productoXml.SetElementValue("StockActual", producto.StockActual);
                productoXml.SetElementValue("StockMinimo", producto.StockMinimo);
                productoXml.SetElementValue("FechaAlta", producto.FechaAlta);
                productoXml.SetElementValue("FechaUltimaActualizacion", producto.FechaUltimaActualizacion);
                productoXml.SetElementValue("Estado", producto.Estado);

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarEstadoProducto(int id, bool estado)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Productos.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Productos.xml no tiene una raiz valida.");

                XElement productoXml = raiz.Elements("Producto").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un producto sin Id.")) == id
                ) ?? throw new Exception("No se encontro el producto indicado.");

                productoXml.SetElementValue("Estado", estado);
                productoXml.SetElementValue("FechaUltimaActualizacion", DateTime.Now);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Producto> BuscarProductos(
            string idProducto,
            int? idMarca,
            int? idCategoria,
            int? idColor,
            bool incluirNoActivos)
        {
            try
            {
                IEnumerable<Producto> productos = this.ConsultarProductos();

                if (!incluirNoActivos)
                {
                    productos = productos.Where(producto => producto.Estado);
                }

                if (!string.IsNullOrWhiteSpace(idProducto))
                {
                    productos = productos.Where(producto =>
                        producto.IdProducto.ToString().StartsWith(idProducto.Trim(), StringComparison.Ordinal)
                    );
                }

                if (idMarca.HasValue)
                {
                    productos = productos.Where(producto => producto.Marca?.Id == idMarca.Value);
                }

                if (idCategoria.HasValue)
                {
                    productos = productos.Where(producto => producto.Categoria?.Id == idCategoria.Value);
                }

                if (idColor.HasValue)
                {
                    productos = productos.Where(producto => producto.Color?.Id == idColor.Value);
                }

                return productos.ToList();
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
                List<Producto> productos = this.ConsultarProductos();

                if (productos.Count == 0)
                {
                    return 1;
                }

                return productos.Max(producto => producto.IdProducto) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay un producto sin {nombre}.");
        }

        private static string? ObtenerValorOpcional(XElement elemento, string nombre)
        {
            string? valor = elemento.Element(nombre)?.Value;

            if (string.IsNullOrWhiteSpace(valor))
            {
                return null;
            }

            return valor;
        }

        private static int? ObtenerIdOpcional(XElement producto, string nombre)
        {
            string valor = producto.Element(nombre)?.Value ?? string.Empty;

            if (string.IsNullOrWhiteSpace(valor))
            {
                return null;
            }

            return int.Parse(valor);
        }

        private static int? ObtenerIdColor(XElement producto)
        {
            string valor = producto.Element("IdColor")?.Value ?? string.Empty;

            if (string.IsNullOrWhiteSpace(valor))
            {
                return null;
            }

            return int.Parse(valor);
        }
    }
}