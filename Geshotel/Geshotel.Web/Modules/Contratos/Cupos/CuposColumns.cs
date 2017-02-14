
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
        //public String ClienteRazon { get; set; }
        //public String  HotelName { get; set; }
        [EditLink,QuickFilter,Width(100)]
        public String TipoHabitacionDescripcion { get; set; }
        [QuickFilter]
        public DateTime FechaDesde { get; set; }
        [QuickFilter]
        public DateTime FechaHasta { get; set; }
        
        public Int16 Cupo { get; set; }
        public Decimal Garantia { get; set; }
        [Width(80),AlignCenter]
        public Boolean ReservaAutomatica { get; set; }
        [Width(80)]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g")]
        public DateTime FechaModificacion { get; set; }
    }
}