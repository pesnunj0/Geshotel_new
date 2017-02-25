
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.ReservasOfertas")]
    [BasedOnRow(typeof(Entities.ReservasOfertasRow))]
    public class ReservasOfertasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ReservaOfertaId { get; set; }
        public Int32 ReservaId { get; set; }
        public Int32 OfertaId { get; set; }
        [EditLink]
        public String Tipo { get; set; }
        public Int16 Activa { get; set; }
        public Int16 OfertaUsada { get; set; }
    }
}