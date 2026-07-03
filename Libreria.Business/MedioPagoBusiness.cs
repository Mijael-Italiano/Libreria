using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data;
using Libreria.Entity;

namespace Libreria.Business
{
    public class MedioPagoBusiness
    {
        private readonly MedioPagoData medioPagoData;

        public MedioPagoBusiness()
        {
            this.medioPagoData = new MedioPagoData();
        }

        public void AltaMedioPago(MedioPago medioPago)
        {
            try
            {
                this.Validar(medioPago);

                int id = this.medioPagoData.ObtenerProximoId();
                medioPago.Nombre = medioPago.Nombre.Trim();
                medioPago.Estado = true;
                this.medioPagoData.AltaMedioPago(medioPago, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MedioPago> ConsultarMediosPago()
        {
            try
            {
                return this.medioPagoData.ConsultarMediosPago();
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
                if (medioPago.IdMedioPago <= 0)
                {
                    throw new Exception("Debe seleccionar un medio de pago.");
                }

                this.Validar(medioPago, medioPago.IdMedioPago);

                MedioPago medioPagoActual = this.medioPagoData
                    .ConsultarMediosPago()
                    .FirstOrDefault(medioPagoExistente => medioPagoExistente.IdMedioPago == medioPago.IdMedioPago)
                    ?? throw new Exception("El medio de pago seleccionado no existe.");

                if (!this.MedioPagoTieneCambios(medioPagoActual, medioPago))
                {
                    throw new Exception("No se modifico ningun dato.");
                }

                medioPago.Nombre = medioPago.Nombre.Trim();
                this.medioPagoData.ModificarMedioPago(medioPago);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarMedioPago(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un medio de pago.");
                }

                MedioPago medioPagoActual = this.medioPagoData
                    .ConsultarMediosPago()
                    .FirstOrDefault(medioPagoExistente => medioPagoExistente.IdMedioPago == id)
                    ?? throw new Exception("El medio de pago seleccionado no existe.");

                if (!medioPagoActual.Estado)
                {
                    throw new Exception("El medio de pago seleccionado ya esta dado de baja.");
                }

                this.medioPagoData.CambiarEstadoMedioPago(id, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReactivarMedioPago(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un medio de pago.");
                }

                MedioPago medioPagoActual = this.medioPagoData
                    .ConsultarMediosPago()
                    .FirstOrDefault(medioPagoExistente => medioPagoExistente.IdMedioPago == id)
                    ?? throw new Exception("El medio de pago seleccionado no existe.");

                if (medioPagoActual.Estado)
                {
                    throw new Exception("El medio de pago seleccionado ya esta activo.");
                }

                this.medioPagoData.CambiarEstadoMedioPago(id, true);
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
                return this.medioPagoData.BuscarMediosPago(nombre.Trim(), incluirNoActivos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool MedioPagoTieneCambios(MedioPago medioPagoActual, MedioPago medioPagoModificado)
        {
            return !medioPagoActual.Nombre.Equals(medioPagoModificado.Nombre.Trim(), StringComparison.Ordinal)
                || medioPagoActual.Estado != medioPagoModificado.Estado;
        }

        private void Validar(MedioPago medioPago)
        {
            this.Validar(medioPago, 0);
        }

        private void Validar(MedioPago medioPago, int idMedioPagoActual)
        {
            if (medioPago == null)
            {
                throw new Exception("Debe informar un medio de pago.");
            }

            if (string.IsNullOrWhiteSpace(medioPago.Nombre))
            {
                throw new Exception("Debe ingresar un nombre.");
            }

            List<MedioPago> mediosPago = this.medioPagoData.ConsultarMediosPago();

            bool nombreExistente = mediosPago.Any(medioPagoExistente =>
                medioPagoExistente.Nombre.Equals(
                    medioPago.Nombre.Trim(),
                    StringComparison.OrdinalIgnoreCase
                )
                && medioPagoExistente.IdMedioPago != idMedioPagoActual
            );

            if (nombreExistente)
            {
                throw new Exception("Ya existe un medio de pago con ese nombre.");
            }
        }
    }
}