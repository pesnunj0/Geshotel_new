
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Temporadas")]
    [BasedOnRow(typeof(Entities.TemporadasRow))]
    public class TemporadasForm
    {
        public String Temporada { get; set; }
        public Int16 HotelId { get; set; }
        public Int16 Ano { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
    }
}