
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
        
        [Width(130), QuickFilter,EditLink]
        public String NombreCompleto { get; set; }
        [Width(90), QuickFilter, Hidden]
        public String Nombre { get; set; }
        [Width(100),QuickFilter,Hidden]
        public String Apellidos { get; set; }
        public String Nif { get; set; }
        [DisplayName("Reserva"), Width(45)]
        public Int32 ReservaId { get; set; }

        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        [Hidden]
        public String NumeroHabitacion { get; set; }
        public Int16 Edad { get; set; }
    }
}