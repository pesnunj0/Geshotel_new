
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.ReservasServicios")]
    [BasedOnRow(typeof(Entities.ReservasServiciosRow))]
    public class ReservasServiciosColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ServicioReservaId { get; set; }
        [Hidden]
        public Int32 ReservaId { get; set; }
        [Width(100)]
        public String ServicioNombreServicio { get; set; }
        [Width(90)]
        public String UnidadCalculo { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Decimal Cantidad { get; set; }

        public Int16 FlagContrato { get; set; }
        public Double PrecioServicio { get; set; }
        public Int16 ServicioExtra { get; set; }
        [Width(100), Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaModificacion { get; set; }
    }
}