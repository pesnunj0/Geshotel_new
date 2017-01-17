
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.UnidadesCalculo")]
    [BasedOnRow(typeof(Entities.UnidadesCalculoRow))]
    public class UnidadesCalculoForm
    {
        public String Uc { get; set; }
        public String DescripcionUnidadCalculo { get; set; }
        public Int16 TipoUnidadCalculoId { get; set; }
        public Boolean Pax { get; set; }
        public Int32 ServicioId { get; set; }
    }
}