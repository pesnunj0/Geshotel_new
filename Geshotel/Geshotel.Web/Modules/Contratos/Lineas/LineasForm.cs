
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
        //public Boolean Oferta { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public Int32 ServicioId { get; set; }
        public Int16 UnidadCalculoId { get; set; }
        public Int16 FrecuenciaId { get; set; }
        public Int16 TipoImputacionId { get; set; }
        public Double Importe { get; set; }
        [DefaultValue(1)]
        public Boolean Lunes { get; set; }
        [DefaultValue(1)]
        public Boolean Martes { get; set; }
        [DefaultValue(1)]
        public Boolean Miercoles { get; set; }
        [DefaultValue(1)]
        public Boolean Jueves { get; set; }
        [DefaultValue(1)]
        public Boolean Viernes { get; set; }
        [DefaultValue(1)]
        public Boolean Sabado { get; set; }
        [DefaultValue(1)]
        public Boolean Domingo { get; set; }
        [DefaultValue(1)]
        public Int16 PagFactura { get; set; }
    }
}