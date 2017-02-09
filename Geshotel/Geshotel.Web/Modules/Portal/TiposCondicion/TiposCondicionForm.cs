
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposCondicion")]
    [BasedOnRow(typeof(Entities.TiposCondicionRow))]
    public class TiposCondicionForm
    {
        public String Condicion { get; set; }
        public String Literal { get; set; }
    }
}