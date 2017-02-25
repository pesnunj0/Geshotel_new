
namespace Geshotel.Recepcion.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Recepcion.ReservasDescuentos")]
    [BasedOnRow(typeof(Entities.ReservasDescuentosRow))]
    public class ReservasDescuentosForm
    {
        public Int32 ReservaId { get; set; }
        public Int32 ServicioId { get; set; }
        public Int16 TipoDescuentoId { get; set; }
        public String Tipo { get; set; }
        public Decimal Descuento { get; set; }
        public Int32 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}