
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Series")]
    [BasedOnRow(typeof(Entities.SeriesRow))]
    public class SeriesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 SerieId { get; set; }
        [EditLink,Width(100)]
        public String Descripcion { get; set; }
        [Width(150), QuickFilter]
        public String Empresa { get; set; }
        [Width(90)]
        public String Abreviatura { get; set; }
        [Width(100),AlignCenter]
        public Boolean Manocorriente { get; set; }
        [Width(80), AlignCenter]
        public Boolean Visible { get; set; }
        [Width(80), AlignCenter]
        public Boolean Factura { get; set; }
        [Width(80), AlignCenter]
        public Boolean Deposito { get; set; }
        [Width(100), Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaModificacion { get; set; }
        //public Int32 ServicioId { get; set; }
        //public Int32 ImpuestoId { get; set; }
        //public Int16 Voxel { get; set; }
    }
}