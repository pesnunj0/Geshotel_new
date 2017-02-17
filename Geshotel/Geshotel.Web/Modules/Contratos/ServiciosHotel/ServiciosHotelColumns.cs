
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.ServiciosHotel")]
    [BasedOnRow(typeof(Entities.ServiciosHotelRow))]
    public class ServiciosHotelColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ServicioHotelId { get; set; }
        [Width(150), QuickFilter, Hidden]
        public String Empresa { get; set; }
        [Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId"), QuickFilterOption("multiple", true)]
        public String HotelName { get; set; }
        [EditLink]
        public String ServicioName;
        public Int16 ImpuestoId { get; set; }
        public Double Costo { get; set; }
        [EditLink]
        public String CtaContable { get; set; }
        public String DptoContable { get; set; }
        public Int16 PermiteCredito { get; set; }
    }
}