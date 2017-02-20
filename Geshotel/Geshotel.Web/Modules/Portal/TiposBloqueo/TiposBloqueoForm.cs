
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposBloqueo")]
    [BasedOnRow(typeof(Entities.TiposBloqueoRow))]
    public class TiposBloqueoForm
    {
        public String Descriptivo { get; set; }
        public Boolean Editable { get; set; }
    }
}