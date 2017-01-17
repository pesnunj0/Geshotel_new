
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposUnidadCalculo")]
    [BasedOnRow(typeof(Entities.TiposUnidadCalculoRow))]
    public class TiposUnidadCalculoColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 UnidadCalculoId { get; set; }
        [EditLink]
        public String Uc { get; set; }
    }
}