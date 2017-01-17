
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.FormasDePago")]
    [BasedOnRow(typeof(Entities.FormasDePagoRow))]
    public class FormasDePagoColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 FormaPagoId { get; set; }
        [EditLink]
        public String FormaPago { get; set; }
        [Width(80),AlignCenter]
        public Boolean Credito { get; set; }
        [Width(80), AlignCenter]
        public Boolean SwEfectivo { get; set; }
        [Width(80), AlignCenter]
        public Boolean SwTarjeta { get; set; }
        [Width(80), AlignCenter]
        public String TarjetaLength { get; set; }
        [Width(80), AlignCenter]
        public String TarjetaPrefixes { get; set; }
        [Width(80), AlignCenter]
        public Boolean TarjetaCheckdigit { get; set; }
        [Width(80), AlignCenter]
        public Boolean SwDingus { get; set; }
        [Width(100), AlignCenter]
        public Boolean ProduccionTpv { get; set; }
    }
}