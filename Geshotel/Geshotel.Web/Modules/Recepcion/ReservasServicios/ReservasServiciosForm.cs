
namespace Geshotel.Recepcion.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Recepcion.ReservasServicios")]
    [BasedOnRow(typeof(Entities.ReservasServiciosRow))]
    public class ReservasServiciosForm
    {
        public Int32 ReservaId { get; set; }
        public Int32 ServicioId { get; set; }
        public Int16 UnidadCalculoId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Decimal Cantidad { get; set; }
        public Int32 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Int16 FlagContrato { get; set; }
        public Double PrecioServicio { get; set; }
        public Int16 ServicioExtra { get; set; }
    }
}