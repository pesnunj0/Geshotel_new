
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.Monedas")]
    [BasedOnRow(typeof(Entities.MonedasRow))]
    public class MonedasForm
    {
        public String Descripcion { get; set; }
        public String DescCorta { get; set; }
        public Double Cambio { get; set; }
    }
}