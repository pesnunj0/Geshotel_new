
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposHabitacionHotel")]
    [BasedOnRow(typeof(Entities.TiposHabitacionHotelRow))]
    public class TiposHabitacionHotelForm
    {
        public Int16 TipoHabitacionId { get; set; }
        public Int32 ServicioId { get; set; }
    }
}