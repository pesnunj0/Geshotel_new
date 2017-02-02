
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Edades")]
    [BasedOnRow(typeof(Entities.EdadesRow))]
    public class EdadesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ContratoId { get; set; }
        public Int16 TipoHuespedId { get; set; }
        public Int32 EdadMinima { get; set; }
        public Int32 EdadMaxima { get; set; }
        public Int16 UserId { get; set; }
    }
}