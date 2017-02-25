
namespace Geshotel.Recepcion.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Recepcion.ReservasHuespedes")]
    [BasedOnRow(typeof(Entities.ReservasHuespedesRow))]
    public class ReservasHuespedesForm
    {
        public Int32 ReservaId { get; set; }
        public Int32 ClienteId { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public Int32 HabitacionId { get; set; }
        public Int16 TipoHuespedId { get; set; }
        public Int16 Edad { get; set; }
    }
}