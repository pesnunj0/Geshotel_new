
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.ComunidadesAutonomas")]
    [BasedOnRow(typeof(Entities.ComunidadesAutonomasRow))]
    public class ComunidadesAutonomasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 ComunidadId { get; set; }
        [EditLink]
        public String ComunidadAutonoma { get; set; }
        public String Nacion { get; set; }
        public String ComunidadAutonomaIsta { get; set; }
    }
}