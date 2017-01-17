
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.Provincias")]
    [BasedOnRow(typeof(Entities.ProvinciasRow))]
    public class ProvinciasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 ProvinciaId { get; set; }
        [EditLink]
        public String Provincia { get; set; }
        public String ComunidadAutonoma { get; set; }
        public String Nacion { get; set; }
        public String ProvinciaIsta { get; set; }
        public Int16 DefectoIsta { get; set; }
    }
}