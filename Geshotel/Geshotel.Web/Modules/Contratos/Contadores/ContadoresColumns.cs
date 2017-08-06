
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Contadores")]
    [BasedOnRow(typeof(Entities.ContadoresRow))]
    public class ContadoresColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ContadorId { get; set; }
        [Width(100), QuickFilter]
        public String Empresa { get; set; }
        [Width(90), QuickFilter]
        public String Serie { get; set; }
        [Width(50),QuickFilter]
        public Int16 Ano { get; set; }
        public Int32 Contador { get; set; }
    }
}