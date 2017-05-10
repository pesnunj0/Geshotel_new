
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.ReservasExtras")]
    [BasedOnRow(typeof(Entities.ReservasServiciosRow))]
    public class ReservasExtrasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ServicioReservaId { get; set; }
        [Hidden]
        public Int32 ReservaId { get; set; }
        [Width(120)]
        public String ServicioNombreServicio { get; set; }
        [Width(100)]
        public String UnidadCalculo { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        [Width(80), AlignRight, DisplayFormat("#,##0.0")]
        public Decimal Cantidad { get; set; }
        [Hidden]
        public Int16 FlagContrato { get; set; }
        // public Double PrecioServicio { get; set; }
        [Hidden]
        public Int16 ServicioExtra { get; set; }
        [Width(100), Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaModificacion { get; set; }
    }
}