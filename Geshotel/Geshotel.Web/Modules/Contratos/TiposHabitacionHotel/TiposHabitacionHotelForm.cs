
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.TiposHabitacionHotel")]
    [BasedOnRow(typeof(Entities.TiposHabitacionHotelRow))]
    public class TiposHabitacionHotelForm
    {
        public Int16 EmpresaId { get; set; }
        public Int16 HotelId { get; set; }
        public Int16 TipoHabitacionId { get; set; }
        public Int32 ServicioId { get; set; }
    }
}