
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
        
        [Width(170), QuickFilter,EditLink]
        public String NombreCompleto { get; set; }
        [Width(90), QuickFilter, Hidden]
        public String Nombre { get; set; }
        [Width(100),QuickFilter,Hidden]
        public String Apellidos { get; set; }
        [Width(85)]
        public String Nif { get; set; }
        [DisplayName("Reserva"), Width(45),Hidden]
        public Int32 ReservaId { get; set; }
        [DisplayName("Llegada"),Width(110)]
        public DateTime FechaLlegada { get; set; }
        [DisplayName("Salida"), Width(110)]
        public DateTime FechaSalida { get; set; }
        [Hidden,DisplayName("Habitación"),Width(80)]
        public String NumeroHabitacion { get; set; }
        [Width(45)]
        public Int16 Edad { get; set; }
    }
}