using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.Data
{
    public class FacturaData
    {
        private readonly ClienteData clienteData;
        private readonly UsuarioData usuarioData;

        public FacturaData()
        {
            this.clienteData = new ClienteData();
            this.usuarioData = new UsuarioData();
        }

        public void AltaFactura(Factura factura)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Facturas.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Facturas.xml no tiene una raiz valida.");

                XElement nuevaFactura = new XElement(
                    "Factura",
                    new XAttribute("Id", factura.IdFactura),
                    new XElement("IdCliente", factura.Cliente.Id),
                    new XElement("IdUsuario", factura.Usuario.Id),
                    new XElement("FechaEmision", factura.FechaEmision),
                    new XElement("Total", factura.Total),
                    new XElement("Estado", factura.Estado)
                );

                raiz.Add(nuevaFactura);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void ModificarFactura(Factura factura)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Facturas.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Facturas.xml no tiene una raiz valida.");

                XElement facturaXml = raiz.Elements("Factura").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay una factura sin Id.")) == factura.IdFactura
                ) ?? throw new Exception("No se encontro la factura indicada.");

                facturaXml.SetElementValue("IdCliente", factura.Cliente.Id);
                facturaXml.SetElementValue("IdUsuario", factura.Usuario.Id);
                facturaXml.SetElementValue("FechaEmision", factura.FechaEmision);
                facturaXml.SetElementValue("Total", factura.Total);
                facturaXml.SetElementValue("Estado", factura.Estado);

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Factura> ConsultarFacturas()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Facturas.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Facturas.xml no tiene una raiz valida.");

                List<Cliente> clientes = this.clienteData.ConsultarClientes();
                List<Usuario> usuarios = this.usuarioData.ConsultarUsuarios();

                var consulta =
                    from factura in raiz.Elements("Factura")
                    let idCliente = int.Parse(ObtenerValor(factura, "IdCliente"))
                    let idUsuario = int.Parse(ObtenerValor(factura, "IdUsuario"))
                    select new Factura
                    {
                        IdFactura = int.Parse(factura.Attribute("Id")?.Value ?? throw new Exception("Hay una factura sin Id.")),
                        Cliente = clientes.FirstOrDefault(cliente => cliente.Id == idCliente)
                            ?? throw new Exception("Hay una factura con un cliente inexistente."),
                        Usuario = usuarios.FirstOrDefault(usuario => usuario.Id == idUsuario)
                            ?? throw new Exception("Hay una factura con un usuario inexistente."),
                        FechaEmision = DateTime.Parse(ObtenerValor(factura, "FechaEmision")),
                        Total = decimal.Parse(ObtenerValor(factura, "Total")),
                        Estado = ObtenerValor(factura, "Estado"),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Factura> BuscarFacturas(
            string idFactura,
            string idCliente,
            string documentoCliente,
            string nombreCliente,
            string apellidoCliente,
            DateTime? fechaDesde,
            DateTime? fechaHasta)
        {
            try
            {
                IEnumerable<Factura> facturas = this.ConsultarFacturas();

                if (!string.IsNullOrWhiteSpace(idFactura))
                {
                    facturas = facturas.Where(factura =>
                        factura.IdFactura.ToString().StartsWith(idFactura.Trim(), StringComparison.Ordinal)
                    );
                }

                if (!string.IsNullOrWhiteSpace(idCliente))
                {
                    facturas = facturas.Where(factura =>
                        factura.Cliente.Id.ToString().StartsWith(idCliente.Trim(), StringComparison.Ordinal)
                    );
                }

                if (!string.IsNullOrWhiteSpace(documentoCliente))
                {
                    facturas = facturas.Where(factura =>
                        factura.Cliente.Documento.ToString().StartsWith(documentoCliente.Trim(), StringComparison.Ordinal)
                    );
                }

                if (!string.IsNullOrWhiteSpace(nombreCliente))
                {
                    facturas = facturas.Where(factura =>
                        factura.Cliente.Nombre.StartsWith(nombreCliente.Trim(), StringComparison.OrdinalIgnoreCase)
                    );
                }

                if (!string.IsNullOrWhiteSpace(apellidoCliente))
                {
                    facturas = facturas.Where(factura =>
                        factura.Cliente.Apellido.StartsWith(apellidoCliente.Trim(), StringComparison.OrdinalIgnoreCase)
                    );
                }

                if (fechaDesde.HasValue)
                {
                    facturas = facturas.Where(factura => factura.FechaEmision.Date >= fechaDesde.Value.Date);
                }

                if (fechaHasta.HasValue)
                {
                    facturas = facturas.Where(factura => factura.FechaEmision.Date <= fechaHasta.Value.Date);
                }

                return facturas.ToList();
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
                List<Factura> facturas = this.ConsultarFacturas();

                if (facturas.Count == 0)
                {
                    return 1;
                }

                return facturas.Max(factura => factura.IdFactura) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay una factura sin {nombre}.");
        }
    }
}

