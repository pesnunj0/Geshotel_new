
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.CategoriaHoteles")]
    [BasedOnRow(typeof(Entities.CategoriaHotelesRow))]
    public class CategoriaHotelesForm
    {
        public String Abreviatura { get; set; }
        public String Categoria { get; set; }
    }
}