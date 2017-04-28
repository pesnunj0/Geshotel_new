using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geshotel.Recepcion
{
    using Serenity.ComponentModel;

    [ScriptInclude]
    public class ReservasPreviewItem
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string DescTipo { get; set; }
        public string DescUCReserva { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioProduccion { get; set; }
        public decimal Importe { get; set; }
        public int Error { get; set; }
    }
}