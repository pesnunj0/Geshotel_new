
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TipoAplicacionOferta")]
    [BasedOnRow(typeof(Entities.TipoAplicacionOfertaRow))]
    public class TipoAplicacionOfertaForm
    {
        public String AplicableSegunFechaDe { get; set; }
    }
}