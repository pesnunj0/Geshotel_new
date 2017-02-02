
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
        public Int16 HotelId { get; set; }
        public Int32 ClienteId { get; set; }
        public DateTime FechaContrato { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
         [EditLink]
        public String NumeroContratoCliente { get; set; }
        public Int16 TemporadaId { get; set; }
        public Boolean ImpuestoIncluido { get; set; }
        public Int16 MercadoId { get; set; }
    }
}