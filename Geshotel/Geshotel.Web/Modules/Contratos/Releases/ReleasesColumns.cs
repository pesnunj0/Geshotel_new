
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Releases")]
    [BasedOnRow(typeof(Entities.ReleasesRow))]
    public class ReleasesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ReleaseId { get; set; }
        public Int32 ClienteId { get; set; }
        public Int16 HotelId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        [EditLink]
        public String Observaciones { get; set; }
        public Int16 Dias { get; set; }
        public Int16 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}