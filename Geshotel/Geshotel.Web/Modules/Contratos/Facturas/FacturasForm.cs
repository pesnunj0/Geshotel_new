﻿
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Facturas")]
    [BasedOnRow(typeof(Entities.FacturasRow))]
    public class FacturasForm
    {
        public Int32 NumeroFactura { get; set; }
        public Int16 SerieId { get; set; }
        public DateTime FechaFactura { get; set; }
        public Int16 HotelId { get; set; }
        public Int32 ClienteId { get; set; }
        public Int16 FormaPagoId { get; set; }
        public String DireccionFactura { get; set; }
        public String PoblacionFactura { get; set; }
        public String Zip { get; set; }
        public Int16 ProvinciaId { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public Int16 EstadoFacturaId { get; set; }
        public String RefFra1 { get; set; }
        public String RefFra2 { get; set; }
        public Int32 IdFacturaRectificada { get; set; }
        public String MotivoRectificacion { get; set; }
        public Int32 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}