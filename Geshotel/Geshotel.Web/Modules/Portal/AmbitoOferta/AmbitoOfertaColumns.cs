
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.AmbitoOferta")]
    [BasedOnRow(typeof(Entities.AmbitoOfertaRow))]
    public class AmbitoOfertaColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 AmbitoOfertaId { get; set; }
        [EditLink]
        public String Nombre { get; set; }
    }
}