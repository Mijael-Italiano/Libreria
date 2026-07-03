using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data;
using Libreria.Entity;

namespace Libreria.Business
{
    public class FacturaBusiness
    {
        private readonly FacturaData facturaData;

        public FacturaBusiness()
        {
            this.facturaData = new FacturaData();
        }

        public void AltaFactura(Factura factura)
        {
            try
            {
                this.Validar(factura);

                if (factura.IdFactura <= 0)
                {
                    factura.IdFactura = this.ObtenerProximoId();
                }

                factura.Estado = string.IsNullOrWhiteSpace(factura.Estado)
                    ? "Emitida"
                    : factura.Estado.Trim();

                this.facturaData.AltaFactura(factura);
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
                if (factura == null || factura.IdFactura <= 0)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                this.Validar(factura);
                factura.Estado = string.IsNullOrWhiteSpace(factura.Estado)
                    ? "Emitida"
                    : factura.Estado.Trim();

                this.facturaData.ModificarFactura(factura);
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
                return this.facturaData.ConsultarFacturas();
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
                return this.facturaData.ObtenerProximoId();
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
                idFactura = idFactura.Trim();
                idCliente = idCliente.Trim();
                documentoCliente = documentoCliente.Trim();
                nombreCliente = nombreCliente.Trim();
                apellidoCliente = apellidoCliente.Trim();

                this.ValidarNumeroOpcional(idFactura, "Debe ingresar un Id de factura valido.");
                this.ValidarNumeroOpcional(idCliente, "Debe ingresar un Id de cliente valido.");
                this.ValidarNumeroOpcional(documentoCliente, "Debe ingresar un DNI valido.");

                if (fechaDesde.HasValue
                    && fechaHasta.HasValue
                    && fechaDesde.Value.Date > fechaHasta.Value.Date)
                {
                    throw new Exception("La fecha desde no puede ser mayor a la fecha hasta.");
                }

                return this.facturaData.BuscarFacturas(
                    idFactura,
                    idCliente,
                    documentoCliente,
                    nombreCliente,
                    apellidoCliente,
                    fechaDesde,
                    fechaHasta
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Validar(Factura factura)
        {
            if (factura == null)
            {
                throw new Exception("Debe informar una factura.");
            }

            if (factura.Cliente == null || factura.Cliente.Id <= 0)
            {
                throw new Exception("Debe informar un cliente valido.");
            }

            if (factura.Usuario == null || factura.Usuario.Id <= 0)
            {
                throw new Exception("Debe informar un usuario valido.");
            }

            if (factura.Total <= 0)
            {
                throw new Exception("El total de la venta debe ser mayor a cero.");
            }
        }

        private void ValidarNumeroOpcional(string valor, string mensajeError)
        {
            if (!string.IsNullOrWhiteSpace(valor)
                && !valor.All(char.IsDigit))
            {
                throw new Exception(mensajeError);
            }
        }
    }
}

