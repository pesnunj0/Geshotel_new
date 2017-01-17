
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposHuesped")]
    [BasedOnRow(typeof(Entities.TiposHuespedRow))]
    public class TiposHuespedColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 TipoHuespedId { get; set; }
        [EditLink]
        public String Descripcion { get; set; }
        public String DescCorta { get; set; }
        public String Empresa { get; set; }
        public String UcDescripcionUnidadCalculo { get; set; }
    }
}