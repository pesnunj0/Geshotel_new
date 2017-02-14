
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.UnidadesCalculo")]
    [BasedOnRow(typeof(Entities.UnidadesCalculoRow))]
    public class UnidadesCalculoColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 UnidadCalculoId { get; set; }
        [EditLink]
        public String DescripcionUnidadCalculo { get; set; }
        public String Uc { get; set; }
        public String TipoUc { get; set; }
        public Boolean Pax { get; set; }
//        public Int32 ServicioId { get; set; }
        public String ServicioNombreServicio { get; set; }
    }
}