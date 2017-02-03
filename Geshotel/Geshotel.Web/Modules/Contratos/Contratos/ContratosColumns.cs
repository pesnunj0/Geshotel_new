
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Contratos")]
    [BasedOnRow(typeof(Entities.ContratosRow))]
    public class ContratosColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ContratoId { get; set; }
        [EditLink, Width(120)]
        public String ClienteName { get; set; }
        [Width(120)]
        public String HotelName { get; set; }
        [Width(120),DisplayName("Fecha Contrato")]
        public DateTime FechaContrato { get; set; }
        [Width(80), DisplayName("Desde")]
        public DateTime FechaDesde { get; set; }
        [Width(80), DisplayName("Hasta")]
        public DateTime FechaHasta { get; set; }
         [EditLink]
        public String NumeroContratoCliente { get; set; }
        [Width(120),AlignCenter]
        public Boolean ImpuestoIncluido { get; set; }
        public Int16 TemporadaId { get; set; }
        
        public Int16 MercadoId { get; set; }
    }
}