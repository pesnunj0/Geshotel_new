
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.GruposHabitacion")]
    [BasedOnRow(typeof(Entities.GruposHabitacionRow))]
    public class GruposHabitacionColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 HabitacionId { get; set; }
        [EditLink]
        public String Habitacion { get; set; }
    }
}