using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.Data
{
    public class FacturaMedioPagoData
    {
        private readonly FacturaData facturaData;
        private readonly MedioPagoData medioPagoData;

        public FacturaMedioPagoData()
        {
            this.facturaData = new FacturaData();
            this.medioPagoData = new MedioPagoData();
        }

        public List<FacturaMedioPago> ConsultarFacturasMediosPago()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturasMediosPago.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturasMediosPago.xml no tiene una raiz valida.");

                List<Factura> facturas = this.facturaData.ConsultarFacturas();
                List<MedioPago> mediosPago = this.medioPagoData.ConsultarMediosPago();

                var consulta =
                    from facturaMedioPago in raiz.Elements("FacturaMedioPago")
                    let idFactura = int.Parse(facturaMedioPago.Attribute("IdFactura")?.Value ?? throw new Exception("Hay una relacion sin IdFactura."))
                    let idMedioPago = int.Parse(facturaMedioPago.Attribute("IdMedioPago")?.Value ?? throw new Exception("Hay una relacion sin IdMedioPago."))
                    select new FacturaMedioPago
                    {
                        Factura = facturas.FirstOrDefault(factura => factura.IdFactura == idFactura)
                            ?? throw new Exception("Hay una relacion con una factura inexistente."),
                        MedioPago = mediosPago.FirstOrDefault(medioPago => medioPago.IdMedioPago == idMedioPago)
                            ?? throw new Exception("Hay una relacion con un medio de pago inexistente."),
                        Monto = decimal.Parse(ObtenerValor(facturaMedioPago, "Monto")),
                        Estado = facturaMedioPago.Element("Estado")?.Value ?? "Activo",
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FacturaMedioPago> ConsultarPorFactura(int idFactura)
        {
            try
            {
                return this.ConsultarFacturasMediosPago()
                    .Where(pago => pago.Factura.IdFactura == idFactura)
                    .Where(pago => pago.Estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaFacturaMedioPago(FacturaMedioPago facturaMedioPago)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturasMediosPago.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturasMediosPago.xml no tiene una raiz valida.");

                XElement nuevoPago = new XElement(
                    "FacturaMedioPago",
                    new XAttribute("IdFactura", facturaMedioPago.Factura.IdFactura),
                    new XAttribute("IdMedioPago", facturaMedioPago.MedioPago.IdMedioPago),
                    new XElement("Monto", facturaMedioPago.Monto),
                    new XElement("Estado", facturaMedioPago.Estado)
                );

                raiz.Add(nuevoPago);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void EliminarPorFactura(int idFactura)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturasMediosPago.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturasMediosPago.xml no tiene una raiz valida.");

                raiz.Elements("FacturaMedioPago")
                    .Where(pago => int.Parse(pago.Attribute("IdFactura")?.Value ?? throw new Exception("Hay una relacion sin IdFactura.")) == idFactura)
                    .Remove();

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AnularPorFactura(int idFactura)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("FacturasMediosPago.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo FacturasMediosPago.xml no tiene una raiz valida.");

                foreach (XElement pago in raiz.Elements("FacturaMedioPago")
                    .Where(pago => int.Parse(pago.Attribute("IdFactura")?.Value ?? throw new Exception("Hay una relacion sin IdFactura.")) == idFactura))
                {
                    XElement? estado = pago.Element("Estado");

                    if (estado == null)
                    {
                        pago.Add(new XElement("Estado", "Anulado"));
                    }
                    else
                    {
                        estado.Value = "Anulado";
                    }
                }

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay una relacion factura-medio de pago sin {nombre}.");
        }
    }
}



