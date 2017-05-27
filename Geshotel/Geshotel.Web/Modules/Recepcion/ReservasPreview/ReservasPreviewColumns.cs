
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.ReservasPreview")]
    public class ReservasPreviewColumns
    {
        [Width(110), DisplayFormat("d"), Sortable(true)]
        public DateTime FechaReserva { get; set; }
        [Width(120), Sortable(true)]
        public string Descripcion { get; set; }
        [Sortable(false), Width(90)]
        public string DescTipo { get;set; }
        [Sortable(false), Width(90)]
        public string DescUCReserva { get; set; }
        [Sortable(false), Width(80)]
        public string Cantidad { get; set; }
        [Sortable(false), Width(80)]
        public string Precio { get; set; }
        [Sortable(false), Width(80)]
        public string PrecioProduccion { get; set; }
        [Sortable(false), Width(80)]
        public string Importe { get; set; }
    }
}