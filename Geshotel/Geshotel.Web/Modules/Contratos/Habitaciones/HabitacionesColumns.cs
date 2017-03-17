
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Habitaciones")]
    [BasedOnRow(typeof(Entities.HabitacionesRow))]
    public class HabitacionesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 HabitacionId { get; set; }
        public Int16 HotelId { get; set; }
        [EditLink]
        public String NumeroHabitacion { get; set; }
        public Int16 TipoHabitacionId { get; set; }
        public Int16 Extension { get; set; }
        public String Observaciones { get; set; }
        public Int16 SituacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public Int16 EstadoTelefono { get; set; }
        public Int16 EstadoProcesado { get; set; }
        public String HabitacionIsta { get; set; }
        public Int16 ZonaLimpiezaId { get; set; }
        public Decimal Lat { get; set; }
        public Decimal Lng { get; set; }
        public String PrimaryImage { get; set; }
        public String Galleryimages { get; set; }
        public Int16 Planta { get; set; }
        public Int32 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}