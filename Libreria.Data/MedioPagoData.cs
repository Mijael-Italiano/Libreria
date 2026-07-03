using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.Data
{
    public class MedioPagoData
    {
        public List<MedioPago> ConsultarMediosPago()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("MediosPago.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo MediosPago.xml no tiene una raiz valida.");

                var consulta =
                    from medioPago in raiz.Elements("MedioPago")
                    select new MedioPago
                    {
                        IdMedioPago = int.Parse(medioPago.Attribute("Id")?.Value ?? throw new Exception("Hay un medio de pago sin Id.")),
                        Nombre = ObtenerValor(medioPago, "Nombre"),
                        Estado = bool.Parse(ObtenerValor(medioPago, "Estado")),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaMedioPago(MedioPago medioPago, int id)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("MediosPago.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo MediosPago.xml no tiene una raiz valida.");

                XElement nuevoMedioPago = new XElement(
                    "MedioPago",
                    new XAttribute("Id", id),
                    new XElement("Nombre", medioPago.Nombre),
                    new XElement("Estado", medioPago.Estado)
                );

                raiz.Add(nuevoMedioPago);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarMedioPago(MedioPago medioPago)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("MediosPago.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo MediosPago.xml no tiene una raiz valida.");

                XElement medioPagoXml = raiz.Elements("MedioPago").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un medio de pago sin Id.")) == medioPago.IdMedioPago
                ) ?? throw new Exception("No se encontro el medio de pago indicado.");

                medioPagoXml.SetElementValue("Nombre", medioPago.Nombre);
                medioPagoXml.SetElementValue("Estado", medioPago.Estado);

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarEstadoMedioPago(int id, bool estado)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("MediosPago.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo MediosPago.xml no tiene una raiz valida.");

                XElement medioPagoXml = raiz.Elements("MedioPago").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un medio de pago sin Id.")) == id
                ) ?? throw new Exception("No se encontro el medio de pago indicado.");

                medioPagoXml.SetElementValue("Estado", estado);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MedioPago> BuscarMediosPago(string nombre, bool incluirNoActivos)
        {
            try
            {
                IEnumerable<MedioPago> mediosPago = this.ConsultarMediosPago();

                if (!incluirNoActivos)
                {
                    mediosPago = mediosPago.Where(medioPago => medioPago.Estado);
                }

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    mediosPago = mediosPago.Where(medioPago =>
                        medioPago.Nombre.StartsWith(nombre.Trim(), StringComparison.OrdinalIgnoreCase)
                    );
                }

                return mediosPago.ToList();
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
                List<MedioPago> mediosPago = this.ConsultarMediosPago();

                if (mediosPago.Count == 0)
                {
                    return 1;
                }

                return mediosPago.Max(medioPago => medioPago.IdMedioPago) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay un medio de pago sin {nombre}.");
        }
    }
}