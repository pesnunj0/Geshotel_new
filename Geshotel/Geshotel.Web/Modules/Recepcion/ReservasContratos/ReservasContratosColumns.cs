
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
        [DisplayName("Db.Shared.RecordId"), AlignRight, Hidden]
        public Int32 ReservaContratoId { get; set; }
        [Hidden]
        public Int32 ReservaId { get; set; }
        [AlignRight, DisplayName("Contrato")]
        public Int32 ContratoId { get; set; }
        [Width(110), DisplayName("Nombre Contrato")]
        public String ClienteName { get; set; }
        [Width(100)]
        public DateTime FechaDesde { get; set; }
        [Width(100)]
        public DateTime FechaHasta { get; set; }
        [Hidden]
        public Boolean Directo { get; set; }
    }
}