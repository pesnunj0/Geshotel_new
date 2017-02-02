
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Cupos")]
    [BasedOnRow(typeof(Entities.CuposRow))]
    public class CuposColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 CupoId { get; set; }
        public Int32 ClienteId { get; set; }
        public Int16 HotelId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Int16 TipoHabitacionId { get; set; }
        public Decimal Garantia { get; set; }
        public byte[] ReservaAutomatica { get; set; }
        public Int16 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}