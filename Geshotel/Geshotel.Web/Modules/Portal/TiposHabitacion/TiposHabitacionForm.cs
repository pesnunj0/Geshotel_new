
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.TiposHabitacion")]
    [BasedOnRow(typeof(Entities.TiposHabitacionRow))]
    public class TiposHabitacionForm
    {
        public String DescCorta { get; set; }
        public String Descripcion { get; set; }
        public Int16 GrupoHabitacionId { get; set; }
        public Int16 NumeroPersonas { get; set; }
        public Int16 Desvios { get; set; }
        public Int16 NoShow { get; set; }
    }
}