
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
        [Width(150), QuickFilter, Hidden]
        public String Empresa { get; set; }
        [Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId")]
        public String HotelName { get; set; }
        [EditLink]
        public String NumeroHabitacion { get; set; }
        [Width(120), QuickFilter, QuickFilterOption("CascadeFrom", "HotelId")]
        public String TipoHabitacionName { get; set; }
        public Int16 Extension { get; set; }
        public String Observaciones { get; set; }
        public Int16 SituacionId { get; set; }
        [Hidden,Width(80)]
        public DateTime FechaInicio { get; set; }
        public Int16 EstadoTelefono { get; set; }
        public Int16 EstadoProcesado { get; set; }
        public String HabitacionIsta { get; set; }
        public String ZonaLimpiezaNombreZona { get; set; }
        public Decimal Lat { get; set; }
        public Decimal Lng { get; set; }
        public String PrimaryImage { get; set; }
        public String Galleryimages { get; set; }
        public Int16 Planta { get; set; }
        [Width(100), Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaModificacion { get; set; }
    }
}