
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.CanalesReserva")]
    [BasedOnRow(typeof(Entities.CanalesReservaRow))]
    public class CanalesReservaForm
    {
        public Int16 EmpresaId { get; set; }
        public String NombreCanal { get; set; }
    }
}