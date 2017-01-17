
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.Naciones")]
    [BasedOnRow(typeof(Entities.NacionesRow))]
    public class NacionesForm
    {
        public String Nacion { get; set; }
        public String DescCorta { get; set; }
        public Int16 MonedaId { get; set; }
        public Int32 IdiomaId { get; set; }
        public Int16 NumeroIne { get; set; }
        public String PaisIsta { get; set; }
        public Int16 Defecto { get; set; }
        public String NombreReal { get; set; }
        public String IdiomaMails { get; set; }
    }
}