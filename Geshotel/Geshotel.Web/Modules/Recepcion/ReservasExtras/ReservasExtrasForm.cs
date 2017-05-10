
namespace Geshotel.Recepcion.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Recepcion.ReservasExtras")]
    [BasedOnRow(typeof(Entities.ReservasServiciosRow))]
    public class ReservasExtrasForm
    {
        [ReadOnly(true)]
        public Int32 ReservaId { get; set; }
        public Int32 ServicioId { get; set; }
        [DefaultValue(1)]
        public Int16 UnidadCalculoId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Decimal Cantidad { get; set; }
        //public Int32 UserId { get; set; }
        //public DateTime FechaModificacion { get; set; }
        [Hidden,DefaultValue(0)]
        public Int16 FlagContrato { get; set; }
        [Hidden]
        public Double PrecioServicio { get; set; }
        [Hidden, DefaultValue(1)]
        public Int16 ServicioExtra { get; set; }
    }
}