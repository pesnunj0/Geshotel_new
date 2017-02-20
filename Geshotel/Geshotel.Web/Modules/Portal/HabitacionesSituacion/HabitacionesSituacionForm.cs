
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.HabitacionesSituacion")]
    [BasedOnRow(typeof(Entities.HabitacionesSituacionRow))]
    public class HabitacionesSituacionForm
    {
        public String Descriptivo { get; set; }
        public Boolean Editable { get; set; }
    }
}