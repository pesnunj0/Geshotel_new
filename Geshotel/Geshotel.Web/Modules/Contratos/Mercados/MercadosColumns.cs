
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Mercados")]
    [BasedOnRow(typeof(Entities.MercadosRow))]
    public class MercadosColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 MercadoId { get; set; }
        [EditLink]
        public String Mercado { get; set; }
        public String Empresa { get; set; }
    }
}