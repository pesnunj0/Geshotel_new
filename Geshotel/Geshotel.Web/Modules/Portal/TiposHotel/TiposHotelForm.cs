
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposHotel")]
    [BasedOnRow(typeof(Entities.TiposHotelRow))]
    public class TiposHotelForm
    {
        public String TipoHotel { get; set; }
        public String Abreviatura { get; set; }
    }
}