using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Libreria.Documentos.Archivos;
using Libreria.Entity;

namespace Libreria.Documentos.Facturas
{
    public class FacturaPdfGenerator
    {
        public string Generar(
            Factura factura,
            List<FacturaItem> items,
            List<FacturaMedioPago> pagos,
            string tipoDocumento)
        {
            this.Validar(factura, items, pagos, tipoDocumento);

            DateTime fechaDocumento = DateTime.Now;
            string rutaPdf = RutaFacturasPdf.ObtenerRutaFactura(factura, tipoDocumento, fechaDocumento);

            using FileStream stream = new FileStream(rutaPdf, FileMode.CreateNew, FileAccess.Write);
            using Document documento = new Document(PageSize.A4, 36, 36, 36, 36);
            PdfWriter.GetInstance(documento, stream);
            documento.Open();

            Font titulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
            Font subtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);
            Font normal = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);
            Font chica = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.DARK_GRAY);

            documento.Add(new Paragraph($"Factura {factura.IdFactura:000000} - {tipoDocumento}", titulo));
            documento.Add(new Paragraph($"Generado: {fechaDocumento:dd/MM/yyyy HH:mm:ss}", chica));
            documento.Add(Chunk.NEWLINE);

            documento.Add(new Paragraph("Datos de factura", subtitulo));
            documento.Add(new Paragraph($"Fecha emision: {factura.FechaEmision:dd/MM/yyyy HH:mm:ss}", normal));
            documento.Add(new Paragraph($"Estado: {factura.Estado}", normal));
            documento.Add(new Paragraph($"Usuario: {factura.Usuario?.NombreUsuario}", normal));
            documento.Add(Chunk.NEWLINE);

            documento.Add(new Paragraph("Cliente", subtitulo));
            documento.Add(new Paragraph($"Id: {factura.Cliente?.Id}", normal));
            documento.Add(new Paragraph($"Nombre: {factura.Cliente?.Apellido}, {factura.Cliente?.Nombre}", normal));
            documento.Add(new Paragraph($"Documento: {factura.Cliente?.Documento}", normal));
            documento.Add(new Paragraph($"Mail: {ValorOpcional(factura.Cliente?.Mail)}", normal));
            documento.Add(new Paragraph($"Telefono: {ValorOpcional(factura.Cliente?.Telefono)}", normal));
            documento.Add(Chunk.NEWLINE);

            documento.Add(CrearSubtituloTabla("Items", subtitulo));
            documento.Add(this.CrearTablaItems(items, normal));
            documento.Add(Chunk.NEWLINE);

            documento.Add(CrearSubtituloTabla("Medios de pago", subtitulo));
            documento.Add(this.CrearTablaPagos(pagos, normal));
            documento.Add(Chunk.NEWLINE);

            Paragraph total = new Paragraph($"Total: ${factura.Total:0.00}", subtitulo)
            {
                Alignment = Element.ALIGN_RIGHT
            };
            documento.Add(total);

            documento.Close();
            return rutaPdf;
        }


        private static Paragraph CrearSubtituloTabla(string texto, Font fuente)
        {
            return new Paragraph(texto, fuente)
            {
                SpacingAfter = 4f
            };
        }
        private PdfPTable CrearTablaItems(List<FacturaItem> items, Font fuente)
        {
            PdfPTable tabla = new PdfPTable(6) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 12, 38, 12, 16, 16, 16 });

            this.AgregarEncabezado(tabla, "Codigo", fuente);
            this.AgregarEncabezado(tabla, "Producto", fuente);
            this.AgregarEncabezado(tabla, "Cantidad", fuente);
            this.AgregarEncabezado(tabla, "Precio", fuente);
            this.AgregarEncabezado(tabla, "Subtotal", fuente);
            this.AgregarEncabezado(tabla, "Estado", fuente);

            foreach (FacturaItem item in items)
            {
                this.AgregarCelda(tabla, item.Producto.IdProducto.ToString(), fuente);
                this.AgregarCelda(tabla, item.Producto.Descripcion, fuente);
                this.AgregarCelda(tabla, item.Cantidad.ToString(), fuente);
                this.AgregarCelda(tabla, item.PrecioUnitario.ToString("0.00"), fuente);
                this.AgregarCelda(tabla, item.Subtotal.ToString("0.00"), fuente);
                this.AgregarCelda(tabla, item.Estado, fuente);
            }

            return tabla;
        }

        private PdfPTable CrearTablaPagos(List<FacturaMedioPago> pagos, Font fuente)
        {
            PdfPTable tabla = new PdfPTable(4) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 16, 42, 22, 20 });

            this.AgregarEncabezado(tabla, "Codigo", fuente);
            this.AgregarEncabezado(tabla, "Medio", fuente);
            this.AgregarEncabezado(tabla, "Monto", fuente);
            this.AgregarEncabezado(tabla, "Estado", fuente);

            foreach (FacturaMedioPago pago in pagos)
            {
                this.AgregarCelda(tabla, pago.MedioPago.IdMedioPago.ToString(), fuente);
                this.AgregarCelda(tabla, pago.MedioPago.Nombre, fuente);
                this.AgregarCelda(tabla, pago.Monto.ToString("0.00"), fuente);
                this.AgregarCelda(tabla, pago.Estado, fuente);
            }

            return tabla;
        }

        private void AgregarEncabezado(PdfPTable tabla, string texto, Font fuente)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, fuente))
            {
                BackgroundColor = new BaseColor(230, 230, 230),
                Padding = 4,
                BorderWidth = 0.5f
            };
            tabla.AddCell(celda);
        }

        private void AgregarCelda(PdfPTable tabla, string texto, Font fuente)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto ?? string.Empty, fuente))
            {
                Padding = 4,
                BorderWidth = 0.5f
            };
            tabla.AddCell(celda);
        }

        private void Validar(
            Factura factura,
            List<FacturaItem> items,
            List<FacturaMedioPago> pagos,
            string tipoDocumento)
        {
            if (factura == null)
            {
                throw new ArgumentNullException(nameof(factura));
            }

            if (items == null || items.Count == 0)
            {
                throw new ArgumentException("Debe informar al menos un item.", nameof(items));
            }

            if (pagos == null)
            {
                throw new ArgumentNullException(nameof(pagos));
            }

            if (string.IsNullOrWhiteSpace(tipoDocumento))
            {
                throw new ArgumentException("Debe informar el tipo de documento.", nameof(tipoDocumento));
            }
        }

        private static string ValorOpcional(string? valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? "-" : valor;
        }
    }
}

