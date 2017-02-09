
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.ContratosEdades")]
    [BasedOnRow(typeof(Entities.ContratosEdadesRow))]
    public class ContratosEdadesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ContratosEdadesId { get; set; }
        public Int16 HotelId { get; set; }
        public Int32 ClienteId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Int16 TipoHuespedId { get; set; }
        public Int32 EdadMinima { get; set; }
        public Int32 EdadMaxima { get; set; }
        public Int32 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}