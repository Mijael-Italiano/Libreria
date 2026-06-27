using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data;
using Libreria.Entity;

namespace Libreria.Business
{
    public class ProductoBusiness
    {
        private readonly ProductoData productoData;
        private readonly MarcaData marcaData;
        private readonly CategoriaData categoriaData;
        private readonly ColorData colorData;

        public ProductoBusiness()
        {
            this.productoData = new ProductoData();
            this.marcaData = new MarcaData();
            this.categoriaData = new CategoriaData();
            this.colorData = new ColorData();
        }

        public void AltaProducto(Producto producto)
        {
            try
            {
                this.Validar(producto);

                int id = this.productoData.ObtenerProximoId();
                producto.Descripcion = producto.Descripcion.Trim();
                producto.FechaAlta = DateTime.Now;
                producto.FechaUltimaActualizacion = DateTime.Now;
                this.productoData.AltaProducto(producto, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Producto> ConsultarProductos()
        {
            try
            {
                return this.productoData.ConsultarProductos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarProducto(Producto producto)
        {
            try
            {
                if (producto.IdProducto <= 0)
                {
                    throw new Exception("Debe seleccionar un producto.");
                }

                this.Validar(producto);

                Producto productoActual = this.productoData
                    .ConsultarProductos()
                    .FirstOrDefault(productoExistente => productoExistente.IdProducto == producto.IdProducto)
                    ?? throw new Exception("El producto seleccionado no existe.");

                if (!this.ProductoTieneCambios(productoActual, producto))
                {
                    throw new Exception("No se modifico ningun dato.");
                }

                producto.Descripcion = producto.Descripcion.Trim();
                producto.FechaAlta = productoActual.FechaAlta;
                producto.FechaUltimaActualizacion = DateTime.Now;
                this.productoData.ModificarProducto(producto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarProducto(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un producto.");
                }

                Producto productoActual = this.productoData
                    .ConsultarProductos()
                    .FirstOrDefault(productoExistente => productoExistente.IdProducto == id)
                    ?? throw new Exception("El producto seleccionado no existe.");

                if (!productoActual.Estado)
                {
                    throw new Exception("El producto seleccionado ya esta dado de baja.");
                }

                this.productoData.CambiarEstadoProducto(id, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReactivarProducto(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un producto.");
                }

                Producto productoActual = this.productoData
                    .ConsultarProductos()
                    .FirstOrDefault(productoExistente => productoExistente.IdProducto == id)
                    ?? throw new Exception("El producto seleccionado no existe.");

                if (productoActual.Estado)
                {
                    throw new Exception("El producto seleccionado ya esta activo.");
                }

                this.productoData.CambiarEstadoProducto(id, true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Producto> BuscarProductos(
            string idProducto,
            int? idMarca,
            int? idCategoria,
            int? idColor,
            bool incluirNoActivos)
        {
            try
            {
                idProducto = idProducto.Trim();

                if (!string.IsNullOrWhiteSpace(idProducto)
                    && !idProducto.All(char.IsDigit))
                {
                    throw new Exception("Debe ingresar un id de producto valido.");
                }

                return this.productoData.BuscarProductos(
                    idProducto,
                    idMarca,
                    idCategoria,
                    idColor,
                    incluirNoActivos
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ProductoTieneCambios(Producto productoActual, Producto productoModificado)
        {
            return ObtenerIdMarca(productoActual.Marca) != ObtenerIdMarca(productoModificado.Marca)
                || ObtenerIdCategoria(productoActual.Categoria) != ObtenerIdCategoria(productoModificado.Categoria)
                || ObtenerIdColor(productoActual.Color) != ObtenerIdColor(productoModificado.Color)
                || !productoActual.Descripcion.Equals(productoModificado.Descripcion.Trim(), StringComparison.Ordinal)
                || productoActual.PrecioUnitario != productoModificado.PrecioUnitario
                || productoActual.StockActual != productoModificado.StockActual
                || productoActual.StockMinimo != productoModificado.StockMinimo
                || productoActual.Estado != productoModificado.Estado;
        }

        private static int? ObtenerIdMarca(Marca? marca)
        {
            return marca?.Id;
        }

        private static int? ObtenerIdCategoria(Categoria? categoria)
        {
            return categoria?.Id;
        }

        private static int? ObtenerIdColor(ColorProducto? color)
        {
            return color?.Id;
        }
        private void Validar(Producto producto)
        {
            if (producto == null)
            {
                throw new Exception("Debe informar un producto.");
            }

            if (producto.Color != null && producto.Color.Id <= 0)
            {
                throw new Exception("Debe seleccionar un color valido.");
            }


            if (producto.PrecioUnitario <= 0)
            {
                throw new Exception("Debe ingresar un precio mayor a cero.");
            }

            if (producto.StockActual < 0)
            {
                throw new Exception("El stock actual no puede ser negativo.");
            }

            if (producto.StockMinimo < 0)
            {
                throw new Exception("El stock minimo no puede ser negativo.");
            }

            if (producto.Marca != null)
            {
                bool existeMarca = this.marcaData.ConsultarMarcas().Any(marca =>
                    marca.Id == producto.Marca.Id && marca.Estado
                );

                if (!existeMarca)
                {
                    throw new Exception("La marca seleccionada no existe o esta dada de baja.");
                }
            }

            if (producto.Categoria != null)
            {
                bool existeCategoria = this.categoriaData.ConsultarCategorias().Any(categoria =>
                    categoria.Id == producto.Categoria.Id && categoria.Estado
                );

                if (!existeCategoria)
                {
                    throw new Exception("La categoria seleccionada no existe o esta dada de baja.");
                }
            }

            if (producto.Color != null)
            {
                bool existeColor = this.colorData.ConsultarColores().Any(color =>
                    color.Id == producto.Color.Id && color.Estado
                );

                if (!existeColor)
                {
                    throw new Exception("El color seleccionado no existe o esta dado de baja.");
                }
            }
        }
    }
}