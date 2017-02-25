
namespace Geshotel.Recepcion.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Recepcion.ReservasOfertas")]
    [BasedOnRow(typeof(Entities.ReservasOfertasRow))]
    public class ReservasOfertasForm
    {
        public Int32 ReservaId { get; set; }
        public Int32 OfertaId { get; set; }
        public String Tipo { get; set; }
        public Int16 Activa { get; set; }
        public Int16 OfertaUsada { get; set; }
    }
}