
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
        public Int16 EmpresaId { get; set; }
        [LookupEditor(("Portal.Hoteles"), CascadeFrom = "EmpresaId", CascadeField ="EmpresaId")]
        public Int16 HotelId { get; set; }
        [ReadOnly(true),DefaultValue(0)]
        public Int16 EstadoReservaId { get; set; }
        [LookupEditor(("Contratos.Clientes"), FilterField = "GrupoClienteId", FilterValue = 2)]
        public Int32 ClienteId { get; set; }
        [LookupEditor(("Contratos.Clientes"), FilterField = "GrupoClienteId", FilterValue = 2)]
        public Int32 ClienteIdFactura { get; set; }
       
        public String NombreReserva { get; set; }
        [LookupEditor(("Contratos.ServiciosHotel"), CascadeFrom = "HotelId", CascadeField = "HotelId", FilterField = "ConceptoAceleradorReservasId", FilterValue = 1)]
        public Int16 TipoHabitacionId { get; set; }
        [LookupEditor(("Contratos.ServiciosHotel"), CascadeFrom ="HotelId", CascadeField ="HotelId", FilterField = "ConceptoAceleradorReservasId", FilterValue = 2)]
        public Int16 PensionId { get; set; }
        
        public Int16 Adultos { get; set; }      
        public Int16 Child50 { get; set; }
        public Int16 ChildFree { get; set; }
        public Int16 Bebes { get; set; }

        public String BonoReferencia { get; set; }
        
        public String BonoOnline { get; set; }
        public Int16 CanalReservaId { get; set; }
        public String CodigoOferta { get; set; }
        [DefaultValue(0)]
        public Boolean BloquearTarifa { get; set; }
        [DefaultValue(0)]
        public Boolean PermiteDevolucion { get; set; }
        [DefaultValue(0)]
        public Boolean Vip { get; set; }
        [ReadOnly(true), DisplayFormat("#,##0.00"), AlignRight]
        public Decimal Valor { get; set; }


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
        [Category("Tarjeta Credito")]
        public Int16 TipoTarjetaId { get; set; }
        public String TarjetaCredito { get; set; }
        public String Caducidad { get; set; }
        public String CodSeguridad { get; set; }
        [Category("Ficheros")]
        public String Ficheros { get; set; }

    }
}