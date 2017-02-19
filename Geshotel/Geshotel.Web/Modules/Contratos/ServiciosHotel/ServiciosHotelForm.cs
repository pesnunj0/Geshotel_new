
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.ServiciosHotel")]
    [BasedOnRow(typeof(Entities.ServiciosHotelRow))]
    public class ServiciosHotelForm
    {
        public Int32 ServicioId { get; set; }
        public Int16 HotelId { get; set; }
        public Int16 ImpuestoId { get; set; }
        public Double Costo { get; set; }
        public String CtaContable { get; set; }
        public String DptoContable { get; set; }
        public Boolean PermiteCredito { get; set; }
    }
}