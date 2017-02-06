
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Lineas")]
    [BasedOnRow(typeof(Entities.LineasRow))]
    public class LineasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 LineaContratoId { get; set; }
        //        public Int32 ContratoId { get; set; }
        //        public Boolean Oferta { get; set; }
        [Width(100), QuickFilter, QuickFilterOption("multiple", true), Hidden]
        public String TipoServicio { get; set; }

        [Width(100), QuickFilter, QuickFilterOption("CascadeFrom", "TipoServicioId")]
        public String Servicio { get; set; }

        [QuickFilter]
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
 
        [Width(80),QuickFilter]
        public String UnidadCalculo { get; set; }
        [Width(80), QuickFilter]

        public String Frecuencia { get; set; }
        [Width(80), QuickFilter]

        public String Imputacion { get; set; }
        public Double Importe { get; set; }
        //public Int16 N { get; set; }
        //public Int16 TipoOfertaId { get; set; }
        //public Double M { get; set; }
        //public Int16 AmbitoOfertaId { get; set; }
        [DisplayName("L")]
        public Boolean Lunes { get; set; }
        [DisplayName("M")]
        public Boolean Martes { get; set; }
        [DisplayName("X")]
        public Boolean Miercoles { get; set; }
        [DisplayName("J")]
        public Boolean Jueves { get; set; }
        [DisplayName("V")]
        public Boolean Viernes { get; set; }
        [DisplayName("S")]
        public Boolean Sabado { get; set; }
        [DisplayName("D")]
        public Boolean Domingo { get; set; }
        public Int16 PagFactura { get; set; }
//        public Int16 UserId { get; set; }
//        public DateTime FechaModificacion { get; set; }
    }
}