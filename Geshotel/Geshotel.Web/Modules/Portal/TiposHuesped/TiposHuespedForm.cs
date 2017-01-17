
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposHuesped")]
    [BasedOnRow(typeof(Entities.TiposHuespedRow))]
    public class TiposHuespedForm
    {
        public String Descripcion { get; set; }
        public String DescCorta { get; set; }
        public Int16 EmpresaId { get; set; }
        public Int16 UcId { get; set; }
    }
}