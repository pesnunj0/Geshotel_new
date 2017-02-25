
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.TiposDeTarjeta")]
    [BasedOnRow(typeof(Entities.TiposDeTarjetaRow))]
    public class TiposDeTarjetaColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 TipoTarjetaId { get; set; }
        [EditLink,Width(100)]
        public String TipoTarjeta { get; set; }
        [Width(100)]
        public String TarjetaLength { get; set; }
        [Width(110)]
        public String TarjetaPrefixes { get; set; }
        [Width(100),AlignCenter]
        public Boolean TarjetaCheckdigit { get; set; }
    }
}