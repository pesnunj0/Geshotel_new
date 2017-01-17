
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposHotel")]
    [BasedOnRow(typeof(Entities.TiposHotelRow))]
    public class TiposHotelColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 TipoHotelId { get; set; }
        [EditLink]
        public String TipoHotel { get; set; }
        public String Abreviatura { get; set; }
    }
}