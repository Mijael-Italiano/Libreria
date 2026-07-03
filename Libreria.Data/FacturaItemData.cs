using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.Data
{
    public class FacturaItemData
    {
        private readonly FacturaData facturaData;
        private readonly ProductoData productoData;

        public FacturaItemData()
        {
            this.facturaData = new FacturaData();
            this.productoData = new ProductoData();
        }

        public List<FacturaItem> ConsultarFacturaItems()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturaItems.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturaItems.xml no tiene una raiz valida.");

                List<Factura> facturas = this.facturaData.ConsultarFacturas();
                List<Producto> productos = this.productoData.ConsultarProductos();

                var consulta =
                    from item in raiz.Elements("FacturaItem")
                    let idFactura = int.Parse(ObtenerValor(item, "IdFactura"))
                    let idProducto = int.Parse(ObtenerValor(item, "IdProducto"))
                    select new FacturaItem
                    {
                        IdFacturaItem = int.Parse(item.Attribute("Id")?.Value ?? throw new Exception("Hay un item de factura sin Id.")),
                        Factura = facturas.FirstOrDefault(factura => factura.IdFactura == idFactura)
                            ?? throw new Exception("Hay un item con una factura inexistente."),
                        Producto = productos.FirstOrDefault(producto => producto.IdProducto == idProducto)
                            ?? throw new Exception("Hay un item con un producto inexistente."),
                        Cantidad = int.Parse(ObtenerValor(item, "Cantidad")),
                        PrecioUnitario = decimal.Parse(ObtenerValor(item, "PrecioUnitario")),
                        Subtotal = decimal.Parse(ObtenerValor(item, "Subtotal")),
                        Estado = ObtenerValor(item, "Estado"),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FacturaItem> ConsultarItemsPorFactura(int idFactura)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturaItems.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturaItems.xml no tiene una raiz valida.");

                Factura factura = this.facturaData.ConsultarFacturas()
                    .FirstOrDefault(facturaExistente => facturaExistente.IdFactura == idFactura)
                    ?? throw new Exception("La factura indicada no existe.");

                List<Producto> productos = this.productoData.ConsultarProductos();

                var consulta =
                    from item in raiz.Elements("FacturaItem")
                    let idFacturaItem = int.Parse(ObtenerValor(item, "IdFactura"))
                    where idFacturaItem == idFactura
                    let idProducto = int.Parse(ObtenerValor(item, "IdProducto"))
                    select new FacturaItem
                    {
                        IdFacturaItem = int.Parse(item.Attribute("Id")?.Value ?? throw new Exception("Hay un item de factura sin Id.")),
                        Factura = factura,
                        Producto = productos.FirstOrDefault(producto => producto.IdProducto == idProducto)
                            ?? throw new Exception("Hay un item con un producto inexistente."),
                        Cantidad = int.Parse(ObtenerValor(item, "Cantidad")),
                        PrecioUnitario = decimal.Parse(ObtenerValor(item, "PrecioUnitario")),
                        Subtotal = decimal.Parse(ObtenerValor(item, "Subtotal")),
                        Estado = ObtenerValor(item, "Estado"),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaFacturaItem(FacturaItem facturaItem, int id)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturaItems.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturaItems.xml no tiene una raiz valida.");

                XElement nuevoItem = new XElement(
                    "FacturaItem",
                    new XAttribute("Id", id),
                    new XElement("IdFactura", facturaItem.Factura.IdFactura),
                    new XElement("IdProducto", facturaItem.Producto.IdProducto),
                    new XElement("Cantidad", facturaItem.Cantidad),
                    new XElement("PrecioUnitario", facturaItem.PrecioUnitario),
                    new XElement("Subtotal", facturaItem.Subtotal),
                    new XElement("Estado", facturaItem.Estado)
                );

                raiz.Add(nuevoItem);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarFacturaItem(FacturaItem facturaItem)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturaItems.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturaItems.xml no tiene una raiz valida.");

                XElement itemXml = raiz.Elements("FacturaItem").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un item de factura sin Id.")) == facturaItem.IdFacturaItem
                ) ?? throw new Exception("No se encontro el item indicado.");

                itemXml.SetElementValue("IdFactura", facturaItem.Factura.IdFactura);
                itemXml.SetElementValue("IdProducto", facturaItem.Producto.IdProducto);
                itemXml.SetElementValue("Cantidad", facturaItem.Cantidad);
                itemXml.SetElementValue("PrecioUnitario", facturaItem.PrecioUnitario);
                itemXml.SetElementValue("Subtotal", facturaItem.Subtotal);
                itemXml.SetElementValue("Estado", facturaItem.Estado);

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarEstadoFacturaItem(int id, string estado)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturaItems.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturaItems.xml no tiene una raiz valida.");

                XElement itemXml = raiz.Elements("FacturaItem").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un item de factura sin Id.")) == id
                ) ?? throw new Exception("No se encontro el item indicado.");

                itemXml.SetElementValue("Estado", estado);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void EliminarItemsPorFactura(int idFactura)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturaItems.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturaItems.xml no tiene una raiz valida.");

                raiz.Elements("FacturaItem")
                    .Where(item => int.Parse(ObtenerValor(item, "IdFactura")) == idFactura)
                    .Remove();

                documento.Save(ruta);
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
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturaItems.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturaItems.xml no tiene una raiz valida.");

                List<int> ids = raiz.Elements("FacturaItem")
                    .Select(item => int.Parse(item.Attribute("Id")?.Value ?? throw new Exception("Hay un item de factura sin Id.")))
                    .ToList();

                if (ids.Count == 0)
                {
                    return 1;
                }

                return ids.Max() + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay un item de factura sin {nombre}.");
        }
    }
}


