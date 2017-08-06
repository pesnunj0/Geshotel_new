
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Facturas")]
    [BasedOnRow(typeof(Entities.FacturasRow))]
    public class FacturasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 FacturaId { get; set; }
        [EditLink,Width(80)]
        public Int32 NumeroFactura { get; set; }
        [Width(150), QuickFilter, Hidden]
        public String Empresa { get; set; }
        [Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId"), QuickFilterOption("multiple", true), Hidden]
        public String HotelName { get; set; }
        public Int16 SerieId { get; set; }
        public DateTime FechaFactura { get; set; }
        public String Razon { get; set; }
        public Int16 FormaPagoId { get; set; }
        [Width(110),DisplayName("Dirección")]
        public String DireccionFactura { get; set; }
        [Width(110),DisplayName("Población")]
        public String PoblacionFactura { get; set; }
        [Hidden]
        public String Zip { get; set; }
        public Int16 ProvinciaId { get; set; }
        [Width(90),DisplayName("Vto.")]
        public DateTime FechaVencimiento { get; set; }
        [Width(80),DisplayName("Estado")]
        public Int16 EstadoFacturaId { get; set; }
        [Width(120)]
        public String RefFra1 { get; set; }
        [Width(120)]
        public String RefFra2 { get; set; }
        [Hidden]
        public Int32 IdFacturaRectificada { get; set; }
        [Hidden]
        public String MotivoRectificacion { get; set; }

        [Width(80),Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"),Hidden]
        public DateTime FechaModificacion { get; set; }
    }
}