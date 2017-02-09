
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.FrecuenciaFacturacion")]
    [BasedOnRow(typeof(Entities.FrecuenciaFacturacionRow))]
    public class FrecuenciaFacturacionForm
    {
        public String DescripcionCorta { get; set; }
        public String Descripcion { get; set; }
    }
}