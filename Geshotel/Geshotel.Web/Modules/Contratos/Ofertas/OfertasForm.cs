
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Ofertas")]
    [BasedOnRow(typeof(Entities.OfertasRow))]
    public class OfertasForm
    {
        [Category("General")]

        public Int32 ContratoId { get; set; }
        public String Texto { get; set; }
        [DefaultValue(1)]
        public Boolean AplicableAuto { get; set; }
        [DefaultValue(1)]
        public Boolean ImpuestoIncluido { get; set; }
        
        
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public String TipoAplicacionOfertaId { get; set; }
        public Int16 OrdenAplicacion { get; set; }

        [Category("Reserva")]
        public DateTime FechaReservaDesde { get; set; }
        public DateTime FechaReservaHasta { get; set; }
        public Int16 EstanciaMinimaDias { get; set; }
        public Int16 EstanciaMaximaDias { get; set; }
        public Int16 DiasDeAntelacion { get; set; }
        public Int16 CupoOferta { get; set; }
        [Category("Oferta")]
        public Int16 TipoServicioId { get; set; }
        public Int32 ServicioId { get; set; }
        public Int16 UnidadCalculoId { get; set; }
        public Int32 ServicioLigadoId { get; set; }
        
        //      public Decimal Precio { get; set; }
        public Int16 TipoImputacionId { get; set; }
        public Int16 AmbitoOfertaId { get; set; }
        public Int16 TipoOfertaId { get; set; }
        public Int16 N { get; set; }
        
        public Decimal M { get; set; }
        
        
        
        
        
    }
}