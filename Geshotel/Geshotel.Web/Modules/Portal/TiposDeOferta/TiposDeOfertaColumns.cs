
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposDeOferta")]
    [BasedOnRow(typeof(Entities.TiposDeOfertaRow))]
    public class TiposDeOfertaColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 TipoOfertaId { get; set; }
        [EditLink]
        public String Oferta { get; set; }
        public Int16 PermitirMMayorQueN { get; set; }
        public Int16 Rejilla { get; set; }
        public String Observaciones { get; set; }
        public Int16 OrdenAplicacion { get; set; }
    }
}