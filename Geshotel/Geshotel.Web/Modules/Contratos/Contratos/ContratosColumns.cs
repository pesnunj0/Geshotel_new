
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

        [Width(150), QuickFilter, QuickFilterOption("multiple", true), Hidden]
        public String Empresa { get; set; }
        [Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId"), QuickFilterOption("multiple", true)]
        public String HotelName { get; set; }

        [EditLink, Width(120), QuickFilter, QuickFilterOption("multiple", true)]
        public String Touroperador { get; set; }
 
        [Width(120),DisplayName("Fecha Contrato") , QuickFilter]
        public DateTime FechaContrato { get; set; }
        [Width(80), DisplayName("Desde"), QuickFilter]
        public DateTime FechaDesde { get; set; }
        [Width(80), DisplayName("Hasta"), QuickFilter]
        public DateTime FechaHasta { get; set; }
        public String NumeroContratoCliente { get; set; }
        [Width(120),AlignCenter]
        public Boolean ImpuestoIncluido { get; set; }
        public String Temporada { get; set; }
        public String Mercado { get; set; }
    }
}