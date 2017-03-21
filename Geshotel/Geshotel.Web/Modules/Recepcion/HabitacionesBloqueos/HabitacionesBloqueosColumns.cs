
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.HabitacionesBloqueos")]
    [BasedOnRow(typeof(Entities.HabitacionesBloqueosRow))]
    public class HabitacionesBloqueosColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 HabitacionBloqueoId { get; set; }
        public Int16 HabitacionId { get; set; }
        public Int16 TipoBloqueoId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        [EditLink]
        public String Observaciones { get; set; }
        public Int32 ReservaId { get; set; }
        public Int32 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}