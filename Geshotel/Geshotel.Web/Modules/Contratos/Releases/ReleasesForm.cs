
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Releases")]
    [BasedOnRow(typeof(Entities.ReleasesRow))]
    public class ReleasesForm
    {
        public Int32 ClienteId { get; set; }
        public Int16 HotelId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public String Observaciones { get; set; }
        public Int16 Dias { get; set; }
    }
}