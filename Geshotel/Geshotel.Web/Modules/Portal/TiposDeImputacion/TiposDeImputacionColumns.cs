
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposDeImputacion")]
    [BasedOnRow(typeof(Entities.TiposDeImputacionRow))]
    public class TiposDeImputacionColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 TipoImputacionId { get; set; }
        [EditLink]
        public String Imputacion { get; set; }
    }
}