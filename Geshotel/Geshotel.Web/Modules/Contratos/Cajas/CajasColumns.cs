
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Cajas")]
    [BasedOnRow(typeof(Entities.CajasRow))]
    public class CajasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 CajaId { get; set; }
        [Width(150), QuickFilter, Hidden]
        public String Empresa { get; set; }
        [Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId")]
        public String HotelName { get; set; }
        [EditLink,Width(100)]
        public String NombreCaja { get; set; }
        [Width(90)]
        public String DescCorta { get; set; }
        [Width(90),AlignCenter]
        public Boolean CierreDia { get; set; }
        [Hidden]
        public String CtaContable { get; set; }
        [Hidden]
        public String DptoContable { get; set; }
        [Width(100), Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaModificacion { get; set; }
    }
}