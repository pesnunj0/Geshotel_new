
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TipoAplicacionOferta")]
    [BasedOnRow(typeof(Entities.TipoAplicacionOfertaRow))]
    public class TipoAplicacionOfertaColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public String TipoAplicacionOfertaId { get; set; }
        public String AplicableSegunFechaDe { get; set; }
    }
}