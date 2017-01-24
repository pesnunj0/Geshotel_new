
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.LineasDeContrato")]
    [BasedOnRow(typeof(Entities.LineasDeContratoRow))]
    public class LineasDeContratoColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 LineaContratoId { get; set; }
        public Int32 ContratoId { get; set; }
        public Int16 Oferta { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public Int32 ServicioId { get; set; }
        public Int16 UnidadCalculoId { get; set; }
        public Int16 FrecuenciaId { get; set; }
        public Int16 TipoImputacionId { get; set; }
        public Double Importe { get; set; }
        public Int16 N { get; set; }
        public Int16 TipoOfertaId { get; set; }
        public Double M { get; set; }
        public Int16 AmbitoOfertaId { get; set; }
        public Int16 Lunes { get; set; }
        public Boolean Martes { get; set; }
        public Boolean Miercoles { get; set; }
        public Boolean Jueves { get; set; }
        public Boolean Viernes { get; set; }
        public Boolean Sabado { get; set; }
        public Boolean Domingo { get; set; }
        public Int16 PagFactura { get; set; }
        public Int16 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}