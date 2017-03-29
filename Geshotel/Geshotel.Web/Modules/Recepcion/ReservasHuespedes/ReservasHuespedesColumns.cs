
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.ReservasHuespedes")]
    [BasedOnRow(typeof(Entities.ReservasHuespedesRow))]
    public class ReservasHuespedesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ReservasHuespedesId { get; set; }
        [Hidden,DisplayName("Reserva"),Width(45)]
        public Int32 ReservaId { get; set; }
        [Width(130),QuickFilter]
        public String NombreCompleto { get; set; }
        public String Nif { get; set; }

        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public Int32 HabitacionId { get; set; }
        public Int16 Edad { get; set; }
    }
}