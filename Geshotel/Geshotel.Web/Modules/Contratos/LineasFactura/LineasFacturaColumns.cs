
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.LineasFactura")]
    [BasedOnRow(typeof(Entities.LineasFacturaRow))]
    public class LineasFacturaColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 LineaFacturaId { get; set; }
        public Int16 HotelId { get; set; }
        public DateTime Fecha { get; set; }
        public Int32 FacturaId { get; set; }
        public Int32 ReservaId { get; set; }
        public Int32 ContratoId { get; set; }
        [EditLink]
        public String Descripcion { get; set; }
        public Decimal Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public Int16 ImpuestoId { get; set; }
        public Decimal PorcImpuesto { get; set; }
        public Int32 ServicioId { get; set; }
        public Int16 UnidadCalculoId { get; set; }
        public String TipoLineaFactura { get; set; }
        public Decimal PrecioProduccion { get; set; }
        public Int16 PagFactura { get; set; }
        public Decimal Costo { get; set; }
        public Int32 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Int16 SwAjuste { get; set; }
    }
}