
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.ClientesAlojados")]
    [BasedOnRow(typeof(Entities.ReservasHuespedesRow))]
    public class ClientesAlojadosColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 ReservasHuespedesId { get; set; }
        [Width(150), QuickFilter, Hidden]
        public String Empresa { get; set; }
        [Width(150), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId")]
        public String HotelName { get; set; }
        
        [Width(130), EditLink]
        public String NombreCompleto { get; set; }
        [Width(90), QuickFilter, Hidden]
        public String Nombre { get; set; }
        [Width(100),QuickFilter,Hidden]
        public String Apellidos { get; set; }
        [Width(80),DisplayName("Doc. Nr.")]
        public String Nif { get; set; }
        [DisplayName("Reserva"), Width(55)]
        public Int32 ReservaId { get; set; }
        [DisplayName("Estado"),Width(70), QuickFilter, QuickFilterOption("Multiple",true)]
        public String EstadoReserva { get; set; }

        [DisplayName("Desde"),QuickFilter,Width(90)]
        public DateTime Desde { get; set; }
        [DisplayName("Hasta"), QuickFilter, Width(90)]
        public DateTime Hasta { get; set; }
        [DisplayName("Tipo Hab."), Width(90)]
        [LookupEditor("Contratos.ServiciosHotel"), QuickFilter, QuickFilterOption("CascadeFrom", "HotelId"), QuickFilterOption("CascadeFrom", "HotelId"), QuickFilterOption("FilterField", "ConceptoAceleradorReservasId"), QuickFilterOption("FilterValue", 1)]
        public String TipoHabitacion { get; set; }
        [DisplayName("Pension"), Width(80)]
        [LookupEditor("Contratos.ServiciosHotel"), QuickFilter, QuickFilterOption("CascadeFrom", "HotelId"), QuickFilterOption("FilterField", "ConceptoAceleradorReservasId"), QuickFilterOption("FilterValue", 2)]
        public String Pension { get; set; }
        [DisplayName("N. Hab."), Width(70)]
        public String NumeroHabitacion { get; set; }
        public Int16 Edad { get; set; }
    }
}