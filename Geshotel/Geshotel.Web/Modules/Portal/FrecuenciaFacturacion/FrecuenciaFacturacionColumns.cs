
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.FrecuenciaFacturacion")]
    [BasedOnRow(typeof(Entities.FrecuenciaFacturacionRow))]
    public class FrecuenciaFacturacionColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 FrecuenciaId { get; set; }
        [EditLink]
        public String DescripcionCorta { get; set; }
        public String Descripcion { get; set; }
    }
}