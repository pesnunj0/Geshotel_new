
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.ReservasContratos")]
    [BasedOnRow(typeof(Entities.ReservasContratosRow))]
    public class ReservasContratosColumns
    {
        [DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ReservaContratoId { get; set; }
        public Int32 ReservaId { get; set; }
        public Int32 ContratoId { get; set; }
        public Int16 Directo { get; set; }
    }
}