
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
        public Int16 EmpresaId { get; set; }
        [LookupEditor(("Portal.Hoteles"), CascadeFrom = "EmpresaId", CascadeField = "EmpresaId")]
        public Int16 HotelId { get; set; }
        [LookupEditor(("Contratos.Habitaciones"), CascadeFrom = "HotelId", CascadeField = "HotelId")]
        public Int16 HabitacionId { get; set; }
        [LookupEditor(("Portal.TiposBloqueo"),FilterField = "Editable", FilterValue = "no")]
        public Int16 TipoBloqueoId { get; set; }
        
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Observaciones { get; set; }
        [ReadOnly(true)]
        public Int32 ReservaId { get; set; }
    }
}