
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.Impuestos")]
    [BasedOnRow(typeof(Entities.ImpuestosRow))]
    public class ImpuestosColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 ImpuestoId { get; set; }

        [EditLink]
        public String Impuesto { get; set; }

        [Width(150), QuickFilter]
        public String Empresa { get; set; }
        [Width(70),AlignRight,DisplayFormat("#0.00")]
        public Double Porcentaje { get; set; }
        public String CtaContable { get; set; }
        public Boolean ActivoGeshotel { get; set; }
        [Width(100)]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g")]
        public DateTime FechaModificacion { get; set; }
    }
}