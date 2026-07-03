using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.Data
{
    public class ClienteData
    {
        public List<Cliente> ConsultarClientes()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Clientes.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Clientes.xml no tiene una raiz valida.");

                var consulta =
                    from cliente in raiz.Elements("Cliente")
                    select new Cliente
                    {
                        Id = int.Parse(cliente.Attribute("Id")?.Value ?? throw new Exception("Hay un cliente sin Id.")),
                        Documento = int.Parse(ObtenerValor(cliente, "Documento")),
                        Nombre = ObtenerValor(cliente, "Nombre"),
                        Apellido = ObtenerValor(cliente, "Apellido"),
                        Telefono = ObtenerValorOpcional(cliente, "Telefono"),
                        Mail = ObtenerValorOpcional(cliente, "Mail"),
                        Direccion = ObtenerValorOpcional(cliente, "Direccion"),
                        Departamento = ObtenerValorOpcional(cliente, "Departamento"),
                        FechaNacimiento = ObtenerFechaOpcional(cliente, "FechaNacimiento"),
                        Estado = bool.Parse(ObtenerValor(cliente, "Estado")),
                        FechaAlta = DateTime.Parse(ObtenerValor(cliente, "FechaAlta")),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaCliente(Cliente cliente, int id)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Clientes.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Clientes.xml no tiene una raiz valida.");

                XElement nuevoCliente = new XElement(
                    "Cliente",
                    new XAttribute("Id", id),
                    new XElement("Documento", cliente.Documento),
                    new XElement("Nombre", cliente.Nombre),
                    new XElement("Apellido", cliente.Apellido),
                    new XElement("Telefono", cliente.Telefono ?? string.Empty),
                    new XElement("Mail", cliente.Mail ?? string.Empty),
                    new XElement("Direccion", cliente.Direccion ?? string.Empty),
                    new XElement("Departamento", cliente.Departamento ?? string.Empty),
                    new XElement("FechaNacimiento", cliente.FechaNacimiento?.ToString("yyyy-MM-dd") ?? string.Empty),
                    new XElement("Estado", cliente.Estado),
                    new XElement("FechaAlta", cliente.FechaAlta)
                );

                raiz.Add(nuevoCliente);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarCliente(Cliente cliente)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Clientes.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Clientes.xml no tiene una raiz valida.");

                XElement clienteXml = raiz.Elements("Cliente").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un cliente sin Id.")) == cliente.Id
                ) ?? throw new Exception("No se encontro el cliente indicado.");

                clienteXml.SetElementValue("Documento", cliente.Documento);
                clienteXml.SetElementValue("Nombre", cliente.Nombre);
                clienteXml.SetElementValue("Apellido", cliente.Apellido);
                clienteXml.SetElementValue("Telefono", cliente.Telefono ?? string.Empty);
                clienteXml.SetElementValue("Mail", cliente.Mail ?? string.Empty);
                clienteXml.SetElementValue("Direccion", cliente.Direccion ?? string.Empty);
                clienteXml.SetElementValue("Departamento", cliente.Departamento ?? string.Empty);
                clienteXml.SetElementValue("FechaNacimiento", cliente.FechaNacimiento?.ToString("yyyy-MM-dd") ?? string.Empty);
                clienteXml.SetElementValue("Estado", cliente.Estado);
                clienteXml.SetElementValue("FechaAlta", cliente.FechaAlta);

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarEstadoCliente(int id, bool estado)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Clientes.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Clientes.xml no tiene una raiz valida.");

                XElement clienteXml = raiz.Elements("Cliente").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un cliente sin Id.")) == id
                ) ?? throw new Exception("No se encontro el cliente indicado.");

                clienteXml.SetElementValue("Estado", estado);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cliente> BuscarClientes(
            string nombre,
            string apellido,
            string documento,
            bool incluirNoActivos)
        {
            try
            {
                IEnumerable<Cliente> clientes = this.ConsultarClientes();

                if (!incluirNoActivos)
                {
                    clientes = clientes.Where(cliente => cliente.Estado);
                }

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    clientes = clientes.Where(cliente =>
                        cliente.Nombre.StartsWith(nombre.Trim(), StringComparison.OrdinalIgnoreCase)
                    );
                }

                if (!string.IsNullOrWhiteSpace(apellido))
                {
                    clientes = clientes.Where(cliente =>
                        cliente.Apellido.StartsWith(apellido.Trim(), StringComparison.OrdinalIgnoreCase)
                    );
                }

                if (!string.IsNullOrWhiteSpace(documento))
                {
                    clientes = clientes.Where(cliente =>
                        cliente.Documento.ToString().StartsWith(documento.Trim(), StringComparison.Ordinal)
                    );
                }

                return clientes.ToList();
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
                List<Cliente> clientes = this.ConsultarClientes();

                if (clientes.Count == 0)
                {
                    return 1;
                }

                return clientes.Max(cliente => cliente.Id) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay un cliente sin {nombre}.");
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

        private static DateTime? ObtenerFechaOpcional(XElement elemento, string nombre)
        {
            string? valor = ObtenerValorOpcional(elemento, nombre);

            if (valor == null)
            {
                return null;
            }

            return DateTime.Parse(valor);
        }
    }
}