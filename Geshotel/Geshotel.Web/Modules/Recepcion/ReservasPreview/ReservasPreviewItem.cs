﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geshotel.Recepcion
{
    using Serenity.ComponentModel;

    [ScriptInclude]
    public class ReservasPreviewItem
    {
        public int Error { get; set; }
        public int Key { get; set; }
        public int ReservaId { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
        public string DescTipo { get; set; }
        public string DescUCReserva { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioProduccion { get; set; }
        public decimal Importe { get; set; }
    }
}