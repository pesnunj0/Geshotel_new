
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.FormasDePago")]
    [BasedOnRow(typeof(Entities.FormasDePagoRow))]
    public class FormasDePagoForm
    {
        public String FormaPago { get; set; }
        public Boolean Credito { get; set; }
        public Boolean SwEfectivo { get; set; }
        public Boolean SwTarjeta { get; set; }
        public String TarjetaLength { get; set; }
        public String TarjetaPrefixes { get; set; }
        public Boolean TarjetaCheckdigit { get; set; }
        public Boolean SwDingus { get; set; }
        public Boolean ProduccionTpv { get; set; }
    }
}