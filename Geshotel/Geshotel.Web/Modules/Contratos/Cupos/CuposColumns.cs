
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
        public String ClienteRazon { get; set; }
        public String  HotelName { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public String TipoHabitacionDescripcion { get; set; }
        public Int16 Cupo { get; set; }
        public Decimal Garantia { get; set; }
        public Boolean ReservaAutomatica { get; set; }
        public String UserName { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}