
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.HabitacionesSituacion")]
    [BasedOnRow(typeof(Entities.HabitacionesSituacionRow))]
    public class HabitacionesSituacionColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 SituacionId { get; set; }
        [EditLink]
        public String Situacion { get; set; }
    }
}