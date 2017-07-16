
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
        
        [Width(150), QuickFilter,Hidden]
        public String Empresa { get; set; }
        [Width(150), Hidden, QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId")]
        public String HotelName { get; set; }
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 HabitacionBloqueoId { get; set; }
        [Width(80),DisplayName("Nº Habit.")]
        public String HabitacionNumeroHabitacion { get; set; }
        [Width(80),DisplayName("Tipo")]
        public String TipoBloqueo { get; set; }
        [Width(80),DisplayName("Editable"),Hidden]
        public Boolean Editable { get; set; }
        [Width(100),DisplayName("Desde"),QuickFilter]
        public DateTime FechaDesde { get; set; }
        [Width(100), DisplayName("Hasta"), QuickFilter]
        public DateTime FechaHasta { get; set; }
        [EditLink]
        public String Observaciones { get; set; }
        [Hidden]
        public Int32 ReservaId { get; set; }
        [Width(100), Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaModificacion { get; set; }
    }
}