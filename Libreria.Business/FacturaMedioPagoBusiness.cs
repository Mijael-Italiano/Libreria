using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data;
using Libreria.Entity;

namespace Libreria.Business
{
    public class FacturaMedioPagoBusiness
    {
        private readonly FacturaMedioPagoData facturaMedioPagoData;

        public FacturaMedioPagoBusiness()
        {
            this.facturaMedioPagoData = new FacturaMedioPagoData();
        }

        public FacturaMedioPago CrearPagoEnMemoria(
            Factura factura,
            MedioPago medioPago,
            decimal monto,
            List<FacturaMedioPago> pagosActuales)
        {
            try
            {
                this.Validar(factura, medioPago, monto);
                this.ValidarMedioPagoNoRepetido(medioPago, pagosActuales);
                this.ValidarTotalNoSuperado(factura, monto, pagosActuales);

                return new FacturaMedioPago(factura, medioPago, monto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarPagoEnMemoria(
            Factura factura,
            FacturaMedioPago pago,
            decimal monto,
            List<FacturaMedioPago> pagosActuales)
        {
            try
            {
                if (pago == null)
                {
                    throw new Exception("Debe seleccionar un pago.");
                }

                this.Validar(factura, pago.MedioPago, monto);

                decimal totalOtrosPagos = pagosActuales
                    .Where(pagoActual => !ReferenceEquals(pagoActual, pago))
                    .Sum(pagoActual => pagoActual.Monto);

                if (totalOtrosPagos + monto > factura.Total)
                {
                    throw new Exception("La suma de los pagos no puede superar el total de la venta.");
                }

                pago.Monto = monto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ValidarPagosCompletos(Factura factura, List<FacturaMedioPago> pagos)
        {
            try
            {
                if (factura == null)
                {
                    throw new Exception("Debe informar una factura.");
                }

                if (pagos == null || pagos.Count == 0)
                {
                    throw new Exception("Debe ingresar al menos un medio de pago.");
                }

                decimal totalPagos = pagos.Sum(pago => pago.Monto);

                if (totalPagos != factura.Total)
                {
                    throw new Exception("La suma de los pagos debe ser igual al total de la venta.");
                }
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
                this.Validar(facturaMedioPago);
                this.facturaMedioPagoData.AltaFacturaMedioPago(facturaMedioPago);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FacturaMedioPago> ConsultarFacturasMediosPago()
        {
            try
            {
                return this.facturaMedioPagoData.ConsultarFacturasMediosPago();
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
                if (idFactura <= 0)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                return this.facturaMedioPagoData.ConsultarPorFactura(idFactura);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void ReemplazarPagosPorFactura(Factura factura, List<FacturaMedioPago> pagos)
        {
            try
            {
                this.ValidarPagosCompletos(factura, pagos);
                this.facturaMedioPagoData.EliminarPorFactura(factura.IdFactura);

                foreach (FacturaMedioPago pago in pagos)
                {
                    pago.Factura = factura;
                    pago.Estado = "Activo";
                    this.Validar(pago);
                    this.facturaMedioPagoData.AltaFacturaMedioPago(pago);
                }
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
                if (idFactura <= 0)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                this.facturaMedioPagoData.AnularPorFactura(idFactura);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Validar(FacturaMedioPago facturaMedioPago)
        {
            if (facturaMedioPago == null)
            {
                throw new Exception("Debe informar un pago.");
            }

            this.Validar(
                facturaMedioPago.Factura,
                facturaMedioPago.MedioPago,
                facturaMedioPago.Monto
            );

            if (string.IsNullOrWhiteSpace(facturaMedioPago.Estado))
            {
                throw new Exception("Debe informar el estado del pago.");
            }
        }

        private void Validar(Factura factura, MedioPago medioPago, decimal monto)
        {
            if (factura == null)
            {
                throw new Exception("Debe informar una factura.");
            }

            if (medioPago == null)
            {
                throw new Exception("Debe seleccionar un medio de pago.");
            }

            if (medioPago.IdMedioPago <= 0)
            {
                throw new Exception("Debe seleccionar un medio de pago valido.");
            }

            if (!medioPago.Estado)
            {
                throw new Exception("El medio de pago seleccionado esta dado de baja.");
            }

            if (monto <= 0)
            {
                throw new Exception("Debe ingresar un monto mayor a cero.");
            }
        }

        private void ValidarMedioPagoNoRepetido(
            MedioPago medioPago,
            List<FacturaMedioPago> pagosActuales)
        {
            if (pagosActuales == null)
            {
                throw new Exception("Debe informar los pagos actuales.");
            }

            bool medioPagoYaAgregado = pagosActuales.Any(pago =>
                pago.MedioPago.IdMedioPago == medioPago.IdMedioPago
            );

            if (medioPagoYaAgregado)
            {
                throw new Exception("El medio de pago ya fue agregado. Modifique el monto del pago existente.");
            }
        }

        private void ValidarTotalNoSuperado(
            Factura factura,
            decimal monto,
            List<FacturaMedioPago> pagosActuales)
        {
            decimal totalPagos = pagosActuales.Sum(pago => pago.Monto) + monto;

            if (totalPagos > factura.Total)
            {
                throw new Exception("La suma de los pagos no puede superar el total de la venta.");
            }
        }
    }
}





