
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Edades")]
    [BasedOnRow(typeof(Entities.EdadesRow))]
    public class EdadesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 EdadesId { get; set; }
        public String HotelName { get; set; }
        public String Touroperador { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public String TipoHuesped { get; set; }
        public Int32 EdadMinima { get; set; }
        public Int32 EdadMaxima { get; set; }
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g")]
        public DateTime FechaModificacion { get; set; }
    }
}