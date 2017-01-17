
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.ComunidadesAutonomas")]
    [BasedOnRow(typeof(Entities.ComunidadesAutonomasRow))]
    public class ComunidadesAutonomasForm
    {
        public String ComunidadAutonoma { get; set; }
        public Int16 NacionId { get; set; }
        public String ComunidadAutonomaIsta { get; set; }
    }
}