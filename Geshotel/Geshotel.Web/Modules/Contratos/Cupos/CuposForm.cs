
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Cupos")]
    [BasedOnRow(typeof(Entities.CuposRow))]
    public class CuposForm
    {
        public Int32 ClienteId { get; set; }
        public Int16 HotelId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Int16 TipoHabitacionId { get; set; }
        public Int16 Cupo { get; set; }
        public Decimal Garantia { get; set; }
        [DefaultValue(0)]
        public Boolean ReservaAutomatica { get; set; }

    }
}