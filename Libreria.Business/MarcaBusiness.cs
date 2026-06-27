using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data;
using Libreria.Entity;

namespace Libreria.Business
{
    public class MarcaBusiness
    {
        private readonly MarcaData marcaData;

        public MarcaBusiness()
        {
            this.marcaData = new MarcaData();
        }

        public void AltaMarca(Marca marca)
        {
            try
            {
                this.Validar(marca);

                int id = this.marcaData.ObtenerProximoId();
                marca.Nombre = marca.Nombre.Trim();
                this.marcaData.AltaMarca(marca, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Marca> ConsultarMarcas()
        {
            try
            {
                return this.marcaData.ConsultarMarcas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarMarca(Marca marca)
        {
            try
            {
                if (marca.Id <= 0)
                {
                    throw new Exception("Debe seleccionar una marca.");
                }

                this.Validar(marca, marca.Id);

                Marca marcaActual = this.marcaData
                    .ConsultarMarcas()
                    .FirstOrDefault(marcaExistente => marcaExistente.Id == marca.Id)
                    ?? throw new Exception("La marca seleccionada no existe.");

                if (!this.MarcaTieneCambios(marcaActual, marca))
                {
                    throw new Exception("No se modifico ningun dato.");
                }

                marca.Nombre = marca.Nombre.Trim();
                this.marcaData.ModificarMarca(marca);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarMarca(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar una marca.");
                }

                Marca marcaActual = this.marcaData
                    .ConsultarMarcas()
                    .FirstOrDefault(marcaExistente => marcaExistente.Id == id)
                    ?? throw new Exception("La marca seleccionada no existe.");

                if (!marcaActual.Estado)
                {
                    throw new Exception("La marca seleccionada ya esta dada de baja.");
                }

                this.marcaData.CambiarEstadoMarca(id, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReactivarMarca(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar una marca.");
                }

                Marca marcaActual = this.marcaData
                    .ConsultarMarcas()
                    .FirstOrDefault(marcaExistente => marcaExistente.Id == id)
                    ?? throw new Exception("La marca seleccionada no existe.");

                if (marcaActual.Estado)
                {
                    throw new Exception("La marca seleccionada ya esta activa.");
                }

                this.marcaData.CambiarEstadoMarca(id, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Marca> BuscarMarcas(string nombre, bool incluirNoActivas)
        {
            try
            {
                nombre = nombre.Trim();

                return this.marcaData.BuscarMarcas(nombre, incluirNoActivas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool MarcaTieneCambios(Marca marcaActual, Marca marcaModificada)
        {
            return !marcaActual.Nombre.Equals(marcaModificada.Nombre.Trim(), StringComparison.Ordinal)
                || marcaActual.Estado != marcaModificada.Estado;
        }

        private void Validar(Marca marca)
        {
            this.Validar(marca, 0);
        }

        private void Validar(Marca marca, int idMarcaActual)
        {
            if (marca == null)
            {
                throw new Exception("Debe informar una marca.");
            }

            if (string.IsNullOrWhiteSpace(marca.Nombre))
            {
                throw new Exception("Debe ingresar un nombre para la marca.");
            }

            List<Marca> marcas = this.marcaData.ConsultarMarcas();

            bool nombreExistente = marcas.Any(marcaExistente =>
                marcaExistente.Nombre.Equals(
                    marca.Nombre.Trim(),
                    StringComparison.OrdinalIgnoreCase
                )
                && marcaExistente.Id != idMarcaActual
            );

            if (nombreExistente)
            {
                throw new Exception("Ya existe una marca con ese nombre.");
            }
        }
    }
}
