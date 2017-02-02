
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.OfertasRejillas")]
    [BasedOnRow(typeof(Entities.OfertasRejillasRow))]
    public class OfertasRejillasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 RejillaId { get; set; }
        public Int32 OfertaId { get; set; }
        public Int16 N { get; set; }
        public Int16 TipoCondicionId { get; set; }
        public Int16 TipoAplicacion { get; set; }
        public Double M { get; set; }
    }
}