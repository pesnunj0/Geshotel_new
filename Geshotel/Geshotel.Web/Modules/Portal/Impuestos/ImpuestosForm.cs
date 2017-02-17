
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.Impuestos")]
    [BasedOnRow(typeof(Entities.ImpuestosRow))]
    public class ImpuestosForm
    {
        public Int16 EmpresaId { get; set; }
        public String Impuesto { get; set; }
        public Double Porcentaje { get; set; }
        public String CtaContable { get; set; }
        public Boolean ActivoGeshotel { get; set; }
        public Int16 UserId { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}