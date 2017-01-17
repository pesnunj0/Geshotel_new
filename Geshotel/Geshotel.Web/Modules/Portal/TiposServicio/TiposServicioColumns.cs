
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposServicio")]
    [BasedOnRow(typeof(Entities.TiposServicioRow))]
    public class TiposServicioColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 TipoServicioId { get; set; }
        [EditLink]
        public String NombreTipoServicio { get; set; }
    }
}