
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposHabitacionHotel")]
    [BasedOnRow(typeof(Entities.TiposHabitacionHotelRow))]
    public class TiposHabitacionHotelColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 HotelId { get; set; }
        public Int16 TipoHabitacionId { get; set; }
        public Int32 ServicioId { get; set; }
    }
}