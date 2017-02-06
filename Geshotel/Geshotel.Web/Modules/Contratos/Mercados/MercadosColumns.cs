
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Mercados")]
    [BasedOnRow(typeof(Entities.MercadosRow))]
    public class MercadosColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 MercadoId { get; set; }
        [EditLink]
        public String Mercado { get; set; }
        [Width(150), QuickFilter, Hidden]
        public String Empresa { get; set; }
        [Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId"), QuickFilterOption("multiple", true)]
        public String HotelName { get; set; }
    }
}