
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
        [Width(65),EditLink, DisplayName("Db.Recepcion.Reservas.ReservaId"), AlignRight, SortOrder(-1)]
        public Int32 ReservaId { get; set; }
        [EditLink]
        public String NombreReserva { get; set; }
        [Width(40),QuickFilter,AlignCenter]
        public Boolean Vip { get; set; }
        [Width(150), QuickFilter, Hidden]
        public String Empresa { get; set; }
        [Width(150),Hidden, QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId")]
        public String HotelName { get; set; }
        [DisplayName("Estado"),Width(70),QuickFilter]
        public String EstadoReserva { get; set; }
        [DisplayName("Contrato"),Width(150),QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId"), QuickFilterOption("FilterField", "GrupoClienteId"), QuickFilterOption("FilterValue", 2)]
        public String ClienteRazon { get; set; }
        [DisplayName("Habit."),AlignCenter]
        [LookupEditor("Contratos.ServiciosHotel"),Width(90),QuickFilter, QuickFilterOption("CascadeFrom", "HotelId"), QuickFilterOption("CascadeFrom", "HotelId"), QuickFilterOption("FilterField", "ConceptoAceleradorReservasId"), QuickFilterOption("FilterValue", 1)]
        public String TipoHabitacion { get; set; }
        [DisplayName("Pension"),AlignCenter]
        [LookupEditor("Contratos.ServiciosHotel"),Width(75), QuickFilter, QuickFilterOption("CascadeFrom", "HotelId"),QuickFilterOption("FilterField", "ConceptoAceleradorReservasId"),QuickFilterOption("FilterValue",2)]
        public String Pension { get; set; }
        [Width(55),AlignRight]
        public Int32 Noches { get; set; }
        [Width(45), AlignCenter]
        public Int16 Pax { get; set; }
        [Width(58),AlignCenter]
        public Int16 Adultos { get; set; }
        [Width(65), AlignCenter]
        public Int16 Child50 { get; set; }
        [Width(68), AlignCenter]
        public Int16 ChildFree { get; set; }
        [Width(55), AlignCenter]
        public Int16 Bebes { get; set; }
        [DisplayName("Importe"),Width(70), DisplayFormat("#,##0.00"), AlignRight]
        public Double Valor { get; set; }
        [Hidden]
        public String CanalReserva { get; set; }
        [DisplayName("Cliente Factura"),Hidden,Width(150),QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId"), QuickFilterOption("FilterField", "GrupoClienteId"), QuickFilterOption("FilterValue", 2)]

        public String ClienteIdFacturaRazon { get; set; }
        [Width(110),QuickFilter, DisplayFormat("d")]
        public DateTime FechaReserva { get; set; }
        [Width(120),DisplayFormat("g")]
        public DateTime FechaPrevistaLlegada { get; set; }
        [Width(120), DisplayFormat("g")]
        public DateTime FechaPrevistaSalida { get; set; }
        [Width(110), Hidden,QuickFilter, DisplayFormat("d")]
        public DateTime FechaLlegada { get; set; }
        [Width(110),Hidden, QuickFilter, DisplayFormat("d")]
        public DateTime FechaSalida { get; set; }
        [Hidden,Width(110)]
        public String ObservacionesLlegada { get; set; }
        [Hidden, Width(110)]
        public String ObservacionesSalida { get; set; }
        [Hidden, Width(110)]
        public String ObservacionesCliente { get; set; }
        [Hidden, Width(110)]
        public String Observaciones { get; set; }
        [Width(110),QuickFilter]
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