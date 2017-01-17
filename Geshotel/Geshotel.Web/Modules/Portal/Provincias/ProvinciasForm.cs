
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.Provincias")]
    [BasedOnRow(typeof(Entities.ProvinciasRow))]
    public class ProvinciasForm
    {
        public String Provincia { get; set; }
        public Int16 ComunidadAutonomaId { get; set; }
        public Int16 NacionId { get; set; }
        public String ProvinciaIsta { get; set; }
        public Int16 DefectoIsta { get; set; }
    }
}