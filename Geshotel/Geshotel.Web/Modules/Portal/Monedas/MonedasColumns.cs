
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.Monedas")]
    [BasedOnRow(typeof(Entities.MonedasRow))]
    public class MonedasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 MonedaId { get; set; }
        [EditLink]
        public String Descripcion { get; set; }
        public String DescCorta { get; set; }
        public Double Cambio { get; set; }
    }
}