using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data;
using Libreria.Entity;

namespace Libreria.Business
{
    public class CategoriaBusiness
    {
        private readonly CategoriaData categoriaData;

        public CategoriaBusiness()
        {
            this.categoriaData = new CategoriaData();
        }

        public void AltaCategoria(Categoria categoria)
        {
            try
            {
                this.Validar(categoria);

                int id = this.categoriaData.ObtenerProximoId();
                categoria.Nombre = categoria.Nombre.Trim();
                this.categoriaData.AltaCategoria(categoria, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Categoria> ConsultarCategorias()
        {
            try
            {
                return this.categoriaData.ConsultarCategorias();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarCategoria(Categoria categoria)
        {
            try
            {
                if (categoria.Id <= 0)
                {
                    throw new Exception("Debe seleccionar una categoria.");
                }

                this.Validar(categoria, categoria.Id);

                Categoria categoriaActual = this.categoriaData
                    .ConsultarCategorias()
                    .FirstOrDefault(categoriaExistente => categoriaExistente.Id == categoria.Id)
                    ?? throw new Exception("La categoria seleccionada no existe.");

                if (!this.CategoriaTieneCambios(categoriaActual, categoria))
                {
                    throw new Exception("No se modifico ningun dato.");
                }

                categoria.Nombre = categoria.Nombre.Trim();
                this.categoriaData.ModificarCategoria(categoria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarCategoria(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar una categoria.");
                }

                Categoria categoriaActual = this.categoriaData
                    .ConsultarCategorias()
                    .FirstOrDefault(categoriaExistente => categoriaExistente.Id == id)
                    ?? throw new Exception("La categoria seleccionada no existe.");

                if (!categoriaActual.Estado)
                {
                    throw new Exception("La categoria seleccionada ya esta dada de baja.");
                }

                this.categoriaData.CambiarEstadoCategoria(id, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReactivarCategoria(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar una categoria.");
                }

                Categoria categoriaActual = this.categoriaData
                    .ConsultarCategorias()
                    .FirstOrDefault(categoriaExistente => categoriaExistente.Id == id)
                    ?? throw new Exception("La categoria seleccionada no existe.");

                if (categoriaActual.Estado)
                {
                    throw new Exception("La categoria seleccionada ya esta activa.");
                }

                this.categoriaData.CambiarEstadoCategoria(id, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Categoria> BuscarCategorias(string nombre, bool incluirNoActivas)
        {
            try
            {
                nombre = nombre.Trim();

                return this.categoriaData.BuscarCategorias(nombre, incluirNoActivas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool CategoriaTieneCambios(Categoria categoriaActual, Categoria categoriaModificada)
        {
            return !categoriaActual.Nombre.Equals(categoriaModificada.Nombre.Trim(), StringComparison.Ordinal)
                || categoriaActual.Estado != categoriaModificada.Estado;
        }

        private void Validar(Categoria categoria)
        {
            this.Validar(categoria, 0);
        }

        private void Validar(Categoria categoria, int idCategoriaActual)
        {
            if (categoria == null)
            {
                throw new Exception("Debe informar una categoria.");
            }

            if (string.IsNullOrWhiteSpace(categoria.Nombre))
            {
                throw new Exception("Debe ingresar un nombre para la categoria.");
            }

            List<Categoria> categorias = this.categoriaData.ConsultarCategorias();

            bool nombreExistente = categorias.Any(categoriaExistente =>
                categoriaExistente.Nombre.Equals(
                    categoria.Nombre.Trim(),
                    StringComparison.OrdinalIgnoreCase
                )
                && categoriaExistente.Id != idCategoriaActual
            );

            if (nombreExistente)
            {
                throw new Exception("Ya existe una categoria con ese nombre.");
            }
        }
    }
}
