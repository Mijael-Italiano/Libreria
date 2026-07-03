using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data;
using Libreria.Entity;

namespace Libreria.Business
{
    public class FacturaItemBusiness
    {
        private readonly FacturaItemData facturaItemData;

        public FacturaItemBusiness()
        {
            this.facturaItemData = new FacturaItemData();
        }

        public FacturaItem CrearItemEnMemoria(Factura factura, Producto producto, int cantidad)
        {
            try
            {
                this.Validar(factura, producto, cantidad);

                return new FacturaItem
                {
                    Factura = factura,
                    Producto = producto,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.PrecioUnitario,
                    Subtotal = cantidad * producto.PrecioUnitario,
                    Estado = "Emitido"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FacturaItem CrearItemEnMemoria(
            Factura factura,
            Producto producto,
            int cantidad,
            List<FacturaItem> itemsActuales)
        {
            try
            {
                this.ValidarProductoNoRepetido(producto, itemsActuales);
                return this.CrearItemEnMemoria(factura, producto, cantidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarItemEnMemoria(FacturaItem facturaItem, int cantidad)
        {
            try
            {
                if (facturaItem == null)
                {
                    throw new Exception("Debe seleccionar un item.");
                }

                this.Validar(facturaItem.Factura, facturaItem.Producto, cantidad);

                facturaItem.Cantidad = cantidad;
                facturaItem.PrecioUnitario = facturaItem.Producto.PrecioUnitario;
                facturaItem.Subtotal = cantidad * facturaItem.PrecioUnitario;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AltaFacturaItem(FacturaItem facturaItem)
        {
            try
            {
                this.Validar(facturaItem);

                int id = this.facturaItemData.ObtenerProximoId();
                facturaItem.PrecioUnitario = facturaItem.Producto.PrecioUnitario;
                facturaItem.Subtotal = facturaItem.Cantidad * facturaItem.PrecioUnitario;
                facturaItem.Estado = string.IsNullOrWhiteSpace(facturaItem.Estado)
                    ? "Emitido"
                    : facturaItem.Estado.Trim();

                this.facturaItemData.AltaFacturaItem(facturaItem, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FacturaItem> ConsultarFacturaItems()
        {
            try
            {
                return this.facturaItemData.ConsultarFacturaItems();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FacturaItem> ConsultarItemsPorFactura(int idFactura)
        {
            try
            {
                if (idFactura <= 0)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                return this.facturaItemData.ConsultarItemsPorFactura(idFactura);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarFacturaItem(FacturaItem facturaItem)
        {
            try
            {
                if (facturaItem.IdFacturaItem <= 0)
                {
                    throw new Exception("Debe seleccionar un item.");
                }

                this.Validar(facturaItem);
                facturaItem.PrecioUnitario = facturaItem.Producto.PrecioUnitario;
                facturaItem.Subtotal = facturaItem.Cantidad * facturaItem.PrecioUnitario;

                this.facturaItemData.ModificarFacturaItem(facturaItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarFacturaItem(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un item.");
                }

                bool existeItem = this.facturaItemData
                    .ConsultarFacturaItems()
                    .Any(item => item.IdFacturaItem == id);

                if (!existeItem)
                {
                    throw new Exception("El item seleccionado no existe.");
                }

                this.facturaItemData.CambiarEstadoFacturaItem(id, "Anulado");
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void ReemplazarItemsPorFactura(Factura factura, List<FacturaItem> items)
        {
            try
            {
                if (factura == null || factura.IdFactura <= 0)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                if (items == null || items.Count == 0)
                {
                    throw new Exception("Debe ingresar al menos un item.");
                }

                foreach (FacturaItem item in items)
                {
                    if (item.Producto == null || item.Producto.IdProducto <= 0)
                    {
                        throw new Exception("Debe seleccionar un producto valido.");
                    }

                    if (item.Cantidad <= 0)
                    {
                        throw new Exception("Debe ingresar una cantidad mayor a cero.");
                    }

                    if (item.Producto.PrecioUnitario <= 0)
                    {
                        throw new Exception("El producto seleccionado no tiene un precio valido.");
                    }

                    item.Factura = factura;
                    item.Estado = string.IsNullOrWhiteSpace(item.Estado) ? "Emitido" : item.Estado.Trim();
                }

                this.facturaItemData.EliminarItemsPorFactura(factura.IdFactura);

                foreach (FacturaItem item in items)
                {
                    int id = this.facturaItemData.ObtenerProximoId();
                    item.PrecioUnitario = item.Producto.PrecioUnitario;
                    item.Subtotal = item.Cantidad * item.PrecioUnitario;
                    this.facturaItemData.AltaFacturaItem(item, id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ValidarProductoNoRepetido(Producto producto, List<FacturaItem> itemsActuales)
        {
            if (itemsActuales == null)
            {
                throw new Exception("Debe informar los items actuales.");
            }

            bool productoYaAgregado = itemsActuales.Any(item =>
                item.Producto.IdProducto == producto.IdProducto
            );

            if (productoYaAgregado)
            {
                throw new Exception("El producto ya fue agregado. Modifique la cantidad del item existente.");
            }
        }
        private void Validar(FacturaItem facturaItem)
        {
            if (facturaItem == null)
            {
                throw new Exception("Debe informar un item.");
            }

            this.Validar(facturaItem.Factura, facturaItem.Producto, facturaItem.Cantidad);
        }

        private void Validar(Factura factura, Producto producto, int cantidad)
        {
            if (factura == null)
            {
                throw new Exception("Debe informar una factura.");
            }

            if (producto == null)
            {
                throw new Exception("Debe seleccionar un producto.");
            }

            if (producto.IdProducto <= 0)
            {
                throw new Exception("Debe seleccionar un producto valido.");
            }

            if (!producto.Estado)
            {
                throw new Exception("El producto seleccionado esta dado de baja.");
            }

            if (cantidad <= 0)
            {
                throw new Exception("Debe ingresar una cantidad mayor a cero.");
            }

            if (cantidad > producto.StockActual)
            {
                throw new Exception("La cantidad ingresada supera el stock disponible.");
            }

            if (producto.PrecioUnitario <= 0)
            {
                throw new Exception("El producto seleccionado no tiene un precio valido.");
            }
        }
    }
}





