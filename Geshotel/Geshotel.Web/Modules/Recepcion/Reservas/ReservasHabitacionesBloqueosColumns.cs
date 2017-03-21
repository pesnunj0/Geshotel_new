
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.ReservasHabitacionesBloqueos")]
    [BasedOnRow(typeof(Entities.HabitacionesBloqueosRow))]
    public class ReservasHabitacionesBloqueosColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 HabitacionBloqueoId { get; set; }
        [EditLink,Width(80),DisplayName("Habitacion")]
        public String HabitacionNumeroHabitacion { get; set; }
        [Width(90), DisplayName("Tipo Hab")]
        public String DescCorta { get; set; }
        [Width(100),DisplayName("Desde")]
        public DateTime FechaDesde { get; set; }
        [Width(100), DisplayName("Hasta")]
        public DateTime FechaHasta { get; set; }
        [Width(130)]
        public String Observaciones { get; set; }
        [Hidden,Width(100)]
        public String UserName { get; set; }
        [Hidden, Width(110),DisplayFormat("g")]
        public DateTime FechaModificacion { get; set; }
    }
}