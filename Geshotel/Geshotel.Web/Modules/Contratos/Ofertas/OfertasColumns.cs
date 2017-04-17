
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Ofertas")]
    [BasedOnRow(typeof(Entities.OfertasRow))]
    public class OfertasColumns
    {
        [EditLink, Width(40),DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 OfertaId { get; set; }
        [EditLink]
        public String Texto { get; set; }
        //public Int32 ContratoId { get; set; }
        [Width(80),AlignCenter]
        public Int16 OrdenAplicacion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        [Width(80)]
        public String TipoAplicacionOfertaName { get; set; }
        //public Boolean AplicableAuto { get; set; }
        //public DateTime FechaReservaDesde { get; set; }
        //public DateTime FechaReservaHasta { get; set; }
        //public Int16 EstanciaMinimaDias { get; set; }
        //public Int16 EstanciaMaximaDias { get; set; }
        //public Int16 DiasDeAntelacion { get; set; }
        //public Int16 TipoServicioId { get; set; }
        //public Int32 ServicioId { get; set; }
        [Width(100)]
        public String UnidadCalculoName { get; set; }
        //public Int32 ServicioLigadoId { get; set; }
        //public Int16 CupoOferta { get; set; }
        //public Decimal Precio { get; set; }
        [Width(30), AlignRight]
        public Int16 N { get; set; }
        [Width(150)]
        public String TipoOfertaName { get; set; }
        [Width(40), AlignRight]
        public Decimal M { get; set; }
        [Width(80)]
        public String AmbitoOfertaName { get; set; }
        [Width(80)]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g")]
        public DateTime FechaModificacion { get; set; }
        //public Boolean ImpuestoIncluido { get; set; }
        //public Int16 TipoImputacionId { get; set; }
        
    }
}