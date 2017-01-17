
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.Naciones")]
    [BasedOnRow(typeof(Entities.NacionesRow))]
    public class NacionesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 NacionId { get; set; }
        [EditLink]
        public String Nacion { get; set; }
        public String DescCorta { get; set; }
        public String MonedaDescripcion { get; set; }
        public String IdiomaLanguageName { get; set; }
        public Int16 NumeroIne { get; set; }
        public String PaisIsta { get; set; }
        public Int16 Defecto { get; set; }
        public String NombreReal { get; set; }
        public String IdiomaMails { get; set; }
    }
}