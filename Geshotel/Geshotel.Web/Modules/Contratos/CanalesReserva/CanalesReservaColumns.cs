
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.CanalesReserva")]
    [BasedOnRow(typeof(Entities.CanalesReservaRow))]
    public class CanalesReservaColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 CanalReservaId { get; set; }
        [Width(100), QuickFilter]
        public String Empresa { get; set; }
        [EditLink]
        public String NombreCanal { get; set; }
    }
}