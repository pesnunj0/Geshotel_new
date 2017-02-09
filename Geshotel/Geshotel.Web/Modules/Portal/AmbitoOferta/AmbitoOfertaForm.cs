
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.AmbitoOferta")]
    [BasedOnRow(typeof(Entities.AmbitoOfertaRow))]
    public class AmbitoOfertaForm
    {
        public String Nombre { get; set; }
    }
}