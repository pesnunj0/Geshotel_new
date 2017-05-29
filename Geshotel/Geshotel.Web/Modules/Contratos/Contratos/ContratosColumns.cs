
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

        [Width(150), QuickFilter, Hidden]
        public String Empresa { get; set; }
        [EditLink,Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId")]
        public String HotelName { get; set; }

        [EditLink, Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "HotelId")]
        public String Touroperador { get; set; }
 
        [Width(120),DisplayName("Fecha Contrato") , QuickFilter]
        public DateTime FechaContrato { get; set; }
        [Width(80), DisplayName("Desde"), QuickFilter]
        public DateTime FechaDesde { get; set; }
        [Width(80), DisplayName("Hasta"), QuickFilter]
        public DateTime FechaHasta { get; set; }
        [Width(120),QuickFilter,DisplayName("Contrato Cliente")]
        public String NumeroContratoCliente { get; set; }
        [Hidden,Width(120),AlignCenter]
        public Boolean ImpuestoIncluido { get; set; }
        [Width(100),QuickFilter, QuickFilterOption("multiple", true),Hidden]
        public String Temporada { get; set; }
        [Width(100), QuickFilter, QuickFilterOption("multiple", true),Hidden]
        public String Mercado { get; set; }
        [Width(100),Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"),Hidden]
        public DateTime FechaModificacion { get; set; }
    }
}