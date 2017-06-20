
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
        public Int16 EmpresaId { get; set; }
        [DisplayName("Hotel"), LookupEditor(("Portal.Hoteles"), CascadeFrom = "EmpresaId", CascadeField = "EmpresaId")]
        public Int16 HotelId { get; set; }
        [DisplayName("Touroperador"),LookupEditor(("Contratos.Clientes"), FilterField = "GrupoClienteId", FilterValue = 2)]
        
        public Int32 ClienteId { get; set; }
        public DateTime FechaContrato { get; set; }
        [DisplayName("Nº Contrato TTOO")]
        public String NumeroContratoCliente { get; set; }
        [DisplayName("Desde")]
        public DateTime FechaDesde { get; set; }
        [DisplayName("Hasta")]
        public DateTime FechaHasta { get; set; }

        public Int16 TemporadaId { get; set; }
        [DefaultValue(1),Hidden]
        public Boolean ImpuestoIncluido { get; set; }
        public Int16 MercadoId { get; set; }
        public String Ficheros { get; set; }
    }
}