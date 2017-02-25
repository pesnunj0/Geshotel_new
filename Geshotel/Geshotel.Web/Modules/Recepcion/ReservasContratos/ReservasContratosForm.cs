
namespace Geshotel.Recepcion.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Recepcion.ReservasContratos")]
    [BasedOnRow(typeof(Entities.ReservasContratosRow))]
    public class ReservasContratosForm
    {
        public Int32 ReservaId { get; set; }
        public Int32 ContratoId { get; set; }
        public Int16 Directo { get; set; }
    }
}