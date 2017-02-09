
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposDeImputacion")]
    [BasedOnRow(typeof(Entities.TiposDeImputacionRow))]
    public class TiposDeImputacionForm
    {
        public String Imputacion { get; set; }
    }
}