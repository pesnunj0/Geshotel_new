
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.Reservas")]
    [BasedOnRow(typeof(Entities.ReservasRow))]
    public class ReservasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ReservaId { get; set; }
        [EditLink]
        public String NombreReserva { get; set; }
        [Hidden]
        public String HotelName { get; set; }
        [QuickFilter,QuickFilterOption("Multiple",true),Width(90)]
        public String EstadoReserva { get; set; }
        [DisplayName("Contrato"),Width(150),QuickFilter]
        public String ClienteRazon { get; set; }
        [Hidden]
        public String CanalReserva { get; set; }
        [DisplayName("Cliente Factura"),Width(150),QuickFilter]
        public String ClienteIdFacturaRazon { get; set; }
        [Width(110),QuickFilter, DisplayFormat("dd/MM/yyyy")]
        public DateTime FechaReserva { get; set; }
        [Width(110), QuickFilter,DisplayFormat("g")]
        public DateTime FechaPrevistaLlegada { get; set; }
        [Width(110), QuickFilter, DisplayFormat("g")]
        public DateTime FechaPrevistaSalida { get; set; }
        [Hidden,Width(90),DisplayFormat("HH:mm")]
        public String ObservacionesLlegada { get; set; }
        [Hidden, Width(110)]
        public String ObservacionesSalida { get; set; }
        [Hidden, Width(110)]
        public String ObservacionesCliente { get; set; }
        [Hidden, Width(110)]
        public String Observaciones { get; set; }
        [Hidden, Width(110)]
        public DateTime FechaLlegada { get; set; }
        [Hidden, Width(110)]
        public DateTime FechaSalida { get; set; }
        [Width(110)]
        public String BonoReferencia { get; set; }
        [Hidden, Width(110)]
        public String BonoOnline { get; set; }

        [Width(100), Hidden, DisplayFormat("g")]
        public DateTime FechaCreacion { get; set; }

        [Hidden, Width(90)]
        public Boolean BloquearTarifa { get; set; }
        [Hidden, Width(90)]
        public Boolean PermiteDevolucion { get; set; }
        [Hidden, Width(90)]
        public Int16 TipoTarjetaId { get; set; }
        [Hidden, Width(110)]
        public String TarjetaCredito { get; set; }
        [Hidden, Width(90)]
        public String Caducidad { get; set; }
        [Hidden, Width(80)]
        public String CodSeguridad { get; set; }

        [Hidden, Width(10)]
        public String CodigoOferta { get; set; }
        [ Width(100),DisplayFormat("#,##0.00"), AlignRight]
        public Decimal Valor { get; set; }
        [Hidden, Width(100), DisplayFormat("#,##0.00"),AlignRight]
        public Decimal ValorValidado { get; set; }
        [Hidden,Width(110)]
        public DateTime FechaValidacion { get; set; }
        [Hidden,Width(100)]
        public String ValidationUser { get; set; }
        [Hidden, Width(90)]
        public Boolean ParoventasCheck { get; set; }
        [Hidden, Width(90)]
        public Boolean CuposCheck { get; set; }
        [Hidden, Width(90)]
        public Boolean ReleaseCheck { get; set; }

        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaAnulacion { get; set; }
        [Width(100), Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaModificacion { get; set; }
    }
}