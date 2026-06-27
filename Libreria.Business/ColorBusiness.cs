using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data;
using Libreria.Entity;

namespace Libreria.Business
{
    public class ColorBusiness
    {
        private readonly ColorData colorData;

        public ColorBusiness()
        {
            this.colorData = new ColorData();
        }

        public void AltaColor(ColorProducto color)
        {
            try
            {
                this.Validar(color);

                int id = this.colorData.ObtenerProximoId();
                color.Nombre = color.Nombre.Trim();
                this.colorData.AltaColor(color, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ColorProducto> ConsultarColores()
        {
            try
            {
                return this.colorData.ConsultarColores();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarColor(ColorProducto color)
        {
            try
            {
                if (color.Id <= 0)
                {
                    throw new Exception("Debe seleccionar un color.");
                }

                this.Validar(color, color.Id);

                ColorProducto colorActual = this.colorData
                    .ConsultarColores()
                    .FirstOrDefault(colorExistente => colorExistente.Id == color.Id)
                    ?? throw new Exception("El color seleccionado no existe.");

                if (!this.ColorTieneCambios(colorActual, color))
                {
                    throw new Exception("No se modifico ningun dato.");
                }

                color.Nombre = color.Nombre.Trim();
                this.colorData.ModificarColor(color);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarColor(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un color.");
                }

                ColorProducto colorActual = this.colorData
                    .ConsultarColores()
                    .FirstOrDefault(colorExistente => colorExistente.Id == id)
                    ?? throw new Exception("El color seleccionado no existe.");

                if (!colorActual.Estado)
                {
                    throw new Exception("El color seleccionado ya esta dado de baja.");
                }

                this.colorData.CambiarEstadoColor(id, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReactivarColor(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un color.");
                }

                ColorProducto colorActual = this.colorData
                    .ConsultarColores()
                    .FirstOrDefault(colorExistente => colorExistente.Id == id)
                    ?? throw new Exception("El color seleccionado no existe.");

                if (colorActual.Estado)
                {
                    throw new Exception("El color seleccionado ya esta activo.");
                }

                this.colorData.CambiarEstadoColor(id, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ColorProducto> BuscarColores(string nombre, bool incluirNoActivos)
        {
            try
            {
                nombre = nombre.Trim();

                return this.colorData.BuscarColores(nombre, incluirNoActivos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ColorTieneCambios(ColorProducto colorActual, ColorProducto colorModificado)
        {
            return !colorActual.Nombre.Equals(colorModificado.Nombre.Trim(), StringComparison.Ordinal)
                || colorActual.Estado != colorModificado.Estado;
        }

        private void Validar(ColorProducto color)
        {
            this.Validar(color, 0);
        }

        private void Validar(ColorProducto color, int idColorActual)
        {
            if (color == null)
            {
                throw new Exception("Debe informar un color.");
            }

            if (string.IsNullOrWhiteSpace(color.Nombre))
            {
                throw new Exception("Debe ingresar un nombre para el color.");
            }

            List<ColorProducto> colores = this.colorData.ConsultarColores();

            bool nombreExistente = colores.Any(colorExistente =>
                colorExistente.Nombre.Equals(
                    color.Nombre.Trim(),
                    StringComparison.OrdinalIgnoreCase
                )
                && colorExistente.Id != idColorActual
            );

            if (nombreExistente)
            {
                throw new Exception("Ya existe un color con ese nombre.");
            }
        }
    }
}
