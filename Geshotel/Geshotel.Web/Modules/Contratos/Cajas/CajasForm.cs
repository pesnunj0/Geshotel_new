
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Cajas")]
    [BasedOnRow(typeof(Entities.CajasRow))]
    public class CajasForm
    {
        public Int16 HotelId { get; set; }
        public String NombreCaja { get; set; }
        public String DescCorta { get; set; }
        public Boolean CierreDia { get; set; }
        //public String CtaContable { get; set; }
        //public String DptoContable { get; set; }
 
    }
}