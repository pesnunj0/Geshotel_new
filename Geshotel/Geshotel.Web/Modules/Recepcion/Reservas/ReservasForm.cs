
namespace Geshotel.Recepcion.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Recepcion.Reservas")]
    [BasedOnRow(typeof(Entities.ReservasRow))]
    public class ReservasForm
    {
        [Category("General")]
        public Int16 HotelId { get; set; }
        [ReadOnly(true),DefaultValue(0)]
        public Int16 EstadoReservaId { get; set; }
        public Int32 ClienteId { get; set; }
        public Int32 ClienteIdFactura { get; set; }
        public String NombreReserva { get; set; }

        public String BonoReferencia { get; set; }
        public Int16 CanalReservaId { get; set; }

        [ReadOnly(true), DisplayFormat("#,##0.00"),AlignRight]
        public Decimal Valor { get; set; }
        public String CodigoOferta { get; set; }
        public Boolean BloquearTarifa { get; set; }
        public Boolean PermiteDevolucion { get; set; }       
       
        
       

        [Category("Fechas")]
        [DisplayFormat("dd/MM/yyyy")]
        public DateTime FechaReserva { get; set; }
        
        [ReadOnly(true),DefaultValue("now"), DisplayFormat("dd/MM/yyyy HH:mm")]
        public DateTime FechaCreacion { get; set; }
        [DisplayFormat("g")]
        public DateTime FechaPrevistaLlegada { get; set; }
        [DisplayFormat("g")]
        public DateTime FechaPrevistaSalida { get; set; }
        [DisplayFormat("dd/MM/yyyy")]
        [ReadOnly(true)]
        public DateTime FechaLlegada { get; set; }
        [DisplayFormat("dd/MM/yyyy")]
        [ReadOnly(true)]
        public DateTime FechaSalida { get; set; }
        [Category("Observaciones")]
        [TextAreaEditor(Rows = 3)]
        public String ObservacionesLlegada { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String ObservacionesSalida { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String Observaciones { get; set; }
        [TextAreaEditor(Rows = 3)]
        public String ObservacionesCliente { get; set; }

        //public String BonoOnline { get; set; }
       
        
        [Category("Tarjeta Credito")]
        public Int16 TipoTarjetaId { get; set; }
        public String TarjetaCredito { get; set; }
        public String Caducidad { get; set; }
        public String CodSeguridad { get; set; }

        //public Decimal ValorValidado { get; set; }
        //[ReadOnly(true)]
        //public DateTime FechaValidacion { get; set; }
        //public Int32 UsuarioValidacion { get; set; }
        //public Int16 ParoventasCheck { get; set; }
        //public Int16 CuposCheck { get; set; }
        //public Int16 ReleaseCheck { get; set; }
        //public Stream ReservaDingus { get; set; }
        //public Int16 DingusImpuestosIncluidos { get; set; }
        //public Int16 DingusComision { get; set; }
        //public Int16 ReservaDingusTipo { get; set; }
        //public DateTime FechaAnulacion { get; set; }
        //public Int32 UserId { get; set; }
        //public DateTime FechaModificacion { get; set; }
    }
}