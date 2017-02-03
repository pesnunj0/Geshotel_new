
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Mercados")]
    [BasedOnRow(typeof(Entities.MercadosRow))]
    public class MercadosForm
    {
        public String Mercado { get; set; }
        public Int16 EmpresaId { get; set; }
    }
}