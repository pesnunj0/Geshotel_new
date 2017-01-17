
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.GruposDeServicios")]
    [BasedOnRow(typeof(Entities.GruposDeServiciosRow))]
    public class GruposDeServiciosForm
    {
        public Int16 HotelId { get; set; }
        public String NombreGrupo { get; set; }
        public String CtaContable { get; set; }
    }
}