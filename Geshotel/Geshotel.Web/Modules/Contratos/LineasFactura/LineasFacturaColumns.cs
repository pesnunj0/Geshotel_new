
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.LineasFactura")]
    [BasedOnRow(typeof(Entities.LineasFacturaRow))]
    public class LineasFacturaColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 LineaFacturaId { get; set; }
        [Width(150), QuickFilter, Hidden]
        public String Empresa { get; set; }
        [Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId")]
        public String HotelName { get; set; }
        [Width(70), QuickFilter]
        public DateTime Fecha { get; set; }
        [DisplayName("Factura"),AlignRight]
        public Int32 FacturaId { get; set; }
        [DisplayName("Reserva"),AlignRight]
        public Int32 ReservaId { get; set; }
        [Hidden]
        public Int32 ContratoId { get; set; }
        [EditLink,Hidden]
        public String Descripcion { get; set; }
        [Width(120),QuickFilter]
        public String NombreServicio { get; set; }
        [Width(100),QuickFilter,DisplayName("UC")]
        public String UnidadCalculo { get; set; }
        [Width(80),AlignRight]
        public Decimal Cantidad { get; set; }
        [Width(80), AlignRight]
        public Decimal Precio { get; set; }
        [Width(80), AlignRight]
        public Decimal Importe { get; set; }
        [Hidden]
        public Int16 ImpuestoId { get; set; }
        [Hidden]
        public Decimal PorcImpuesto { get; set; }
        [Hidden]
        public String TipoLineaFactura { get; set; }
        [Hidden,Width(100),AlignRight]
        public Decimal PrecioProduccion { get; set; }
        [Hidden]
        public Int16 PagFactura { get; set; }
        [Hidden]
        public Decimal Costo { get; set; }
        [Width(100), Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaModificacion { get; set; }
        [QuickFilter,Hidden]
        public Boolean SwAjuste { get; set; }
    }
}