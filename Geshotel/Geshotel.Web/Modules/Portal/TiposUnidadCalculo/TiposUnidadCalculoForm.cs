
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposUnidadCalculo")]
    [BasedOnRow(typeof(Entities.TiposUnidadCalculoRow))]
    public class TiposUnidadCalculoForm
    {
        public String Uc { get; set; }
    }
}