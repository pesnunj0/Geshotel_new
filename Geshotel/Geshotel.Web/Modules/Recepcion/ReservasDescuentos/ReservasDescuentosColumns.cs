
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.ReservasDescuentos")]
    [BasedOnRow(typeof(Entities.ReservasDescuentosRow))]
    public class ReservasDescuentosColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ReservaDescuentoId { get; set; }
        public Int32 ReservaId { get; set; }
        public Int32 ServicioId { get; set; }
        public Int16 TipoDescuentoId { get; set; }
        [EditLink]
        public String Tipo { get; set; }
        public Decimal Descuento { get; set; }
        public Int32 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}