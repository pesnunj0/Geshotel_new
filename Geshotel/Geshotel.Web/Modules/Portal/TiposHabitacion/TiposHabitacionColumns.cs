
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposHabitacion")]
    [BasedOnRow(typeof(Entities.TiposHabitacionRow))]
    public class TiposHabitacionColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 TipoHabitacionId { get; set; }
        [EditLink]
        public String DescCorta { get; set; }
        public String Descripcion { get; set; }
        public String GrupoHabitacion { get; set; }
        public Int16 NumeroPersonas { get; set; }
        public Int16 Desvios { get; set; }
        public Int16 NoShow { get; set; }
    }
}