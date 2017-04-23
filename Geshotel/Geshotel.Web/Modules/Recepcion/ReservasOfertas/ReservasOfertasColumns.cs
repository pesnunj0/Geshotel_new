
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.ReservasOfertas")]
    [BasedOnRow(typeof(Entities.ReservasOfertasRow))]
    public class ReservasOfertasColumns
    {
        [DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 ReservaOfertaId { get; set; }
        //public Int32 ReservaId { get; set; }
        public Int32 OfertaId { get; set; }
        [Width(120)]
        public String Texto { get; set; }
        [Width(90)]
        public String UnidadCalculoName { get; set; }
        [Width(30), AlignRight]
        public Int16 N { get; set; }
        [Width(150)]
        public String TipoOfertaName { get; set; }
        [Width(40), AlignRight]
        public Decimal M { get; set; }
        [Width(50),AlignCenter]
        public Boolean Activa { get; set; }
        [DisplayName("Usada"),Width(50),AlignCenter]
        public Boolean OfertaUsada { get; set; }
    }
}