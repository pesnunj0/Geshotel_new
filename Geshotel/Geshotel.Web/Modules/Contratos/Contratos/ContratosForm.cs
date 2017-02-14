
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Contratos")]
    [BasedOnRow(typeof(Entities.ContratosRow))]
    public class ContratosForm
    {
        public Int16 HotelId { get; set; }
        [DisplayName("Touroperador")]
        public Int32 ClienteId { get; set; }
        public DateTime FechaContrato { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public String NumeroContratoCliente { get; set; }
        public Int16 TemporadaId { get; set; }
        [DefaultValue(1)]
        public Boolean ImpuestoIncluido { get; set; }
        public Int16 MercadoId { get; set; }
    }
}