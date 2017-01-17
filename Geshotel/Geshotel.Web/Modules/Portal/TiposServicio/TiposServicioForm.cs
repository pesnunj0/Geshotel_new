
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposServicio")]
    [BasedOnRow(typeof(Entities.TiposServicioRow))]
    public class TiposServicioForm
    {
        public String NombreTipoServicio { get; set; }
    }
}