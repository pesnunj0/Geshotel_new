
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposCondicion")]
    [BasedOnRow(typeof(Entities.TiposCondicionRow))]
    public class TiposCondicionColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 TipoCondicionId { get; set; }
        [EditLink]
        public String Condicion { get; set; }
        public String Literal { get; set; }
    }
}