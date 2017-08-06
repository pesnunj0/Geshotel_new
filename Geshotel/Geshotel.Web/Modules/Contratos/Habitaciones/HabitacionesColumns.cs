
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
        [Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId"),Hidden]
        public String HotelName { get; set; }
        [EditLink,DisplayName("Número"),Width(60)]
        public String NumeroHabitacion { get; set; }
        [DisplayName("Tipo Habitación"),Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "HotelId")]
        public String TipoHabitacionName { get; set; }
        [Width(70),DisplayName("Extensión")]
        public Int16 Extension { get; set; }
        [Width(150)]
        public String Observaciones { get; set; }
        [Hidden]
        public Int16 SituacionId { get; set; }
        [Hidden,Width(80),DisplayName("Fec. Inicio")]
        public DateTime FechaInicio { get; set; }
        [Hidden]
        public Int16 EstadoTelefono { get; set; }
        [Hidden]
        public Int16 EstadoProcesado { get; set; }
        [Hidden]
        public String HabitacionIsta { get; set; }
        [DisplayName("Zona Limpieza"),Width(100)]
        public String ZonaLimpiezaNombreZona { get; set; }
        [Hidden]
        public Decimal Lat { get; set; }
        [Hidden]
        public Decimal Lng { get; set; }
        [Hidden]
        public String PrimaryImage { get; set; }
        [Hidden]
        public String Galleryimages { get; set; }
        [Width(70),Hidden]
        public Int16 Planta { get; set; }
        [Width(100), Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaModificacion { get; set; }
    }
}