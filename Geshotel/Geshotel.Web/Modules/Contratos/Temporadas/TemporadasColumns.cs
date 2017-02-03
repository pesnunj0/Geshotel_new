
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Temporadas")]
    [BasedOnRow(typeof(Entities.TemporadasRow))]
    public class TemporadasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 TemporadaId { get; set; }
        [EditLink]
        public String Temporada { get; set; }
        public Int16 EmpresaId { get; set; }
        public Int16 Ano { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
    }
}