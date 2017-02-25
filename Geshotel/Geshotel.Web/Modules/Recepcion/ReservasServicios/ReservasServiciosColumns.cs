
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
        public Int32 ReservaId { get; set; }
        public Int32 ServicioId { get; set; }
        public Int16 UnidadCalculoId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Decimal Cantidad { get; set; }
        public Int32 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Int16 FlagContrato { get; set; }
        public Double PrecioServicio { get; set; }
        public Int16 ServicioExtra { get; set; }
    }
}