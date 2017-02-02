
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Lineas")]
    [BasedOnRow(typeof(Entities.LineasRow))]
    public class LineasForm
    {
        public Int32 ContratoId { get; set; }
        public Boolean Oferta { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public Int32 ServicioId { get; set; }
        public Int16 UnidadCalculoId { get; set; }
        public Int16 FrecuenciaId { get; set; }
        public Int16 TipoImputacionId { get; set; }
        public Double Importe { get; set; }
        public Int16 N { get; set; }
        public Int16 TipoOfertaId { get; set; }
        public Double M { get; set; }
        public Int16 AmbitoOfertaId { get; set; }
        public Boolean Lunes { get; set; }
        public Boolean Martes { get; set; }
        public Boolean Miercoles { get; set; }
        public Boolean Jueves { get; set; }
        public Boolean Viernes { get; set; }
        public Boolean Sabado { get; set; }
        public Boolean Domingo { get; set; }
        public Int16 PagFactura { get; set; }
        public Int16 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}