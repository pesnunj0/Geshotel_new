
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposDeTarjeta")]
    [BasedOnRow(typeof(Entities.TiposDeTarjetaRow))]
    public class TiposDeTarjetaForm
    {
        public String TipoTarjeta { get; set; }
        public String TarjetaLength { get; set; }
        public String TarjetaPrefixes { get; set; }
        public Boolean TarjetaCheckdigit { get; set; }
    }
}