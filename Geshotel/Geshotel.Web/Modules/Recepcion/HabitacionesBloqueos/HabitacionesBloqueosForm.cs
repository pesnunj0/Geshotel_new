
namespace Geshotel.Recepcion.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Recepcion.HabitacionesBloqueos")]
    [BasedOnRow(typeof(Entities.HabitacionesBloqueosRow))]
    public class HabitacionesBloqueosForm
    {
        public Int16 HabitacionId { get; set; }
       
        public Int16 TipoBloqueoId { get; set; }
        
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Observaciones { get; set; }
        public Int32 ReservaId { get; set; }
    }
}