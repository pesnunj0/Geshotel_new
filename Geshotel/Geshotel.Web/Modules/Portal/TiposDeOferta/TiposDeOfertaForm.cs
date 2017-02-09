
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposDeOferta")]
    [BasedOnRow(typeof(Entities.TiposDeOfertaRow))]
    public class TiposDeOfertaForm
    {
        public String Oferta { get; set; }
        public Int16 PermitirMMayorQueN { get; set; }
        public Int16 Rejilla { get; set; }
        public String Observaciones { get; set; }
        public Int16 OrdenAplicacion { get; set; }
    }
}