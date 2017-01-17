
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.GruposHabitacion")]
    [BasedOnRow(typeof(Entities.GruposHabitacionRow))]
    public class GruposHabitacionForm
    {
        public String Habitacion { get; set; }
    }
}