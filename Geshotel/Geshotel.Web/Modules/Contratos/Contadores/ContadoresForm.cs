
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Contadores")]
    [BasedOnRow(typeof(Entities.ContadoresRow))]
    public class ContadoresForm
    {
        public Int16 EmpresaId { get; set; }
        public Int16 SerieId { get; set; }
        public Int16 Ano { get; set; }
        public Int32 Contador { get; set; }
    }
}