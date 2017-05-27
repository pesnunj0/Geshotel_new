
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
        [Width(100), Sortable(true),QuickFilter]
        public DateTime Fecha { get; set; }
        [Width(170), Sortable(true)]
        public string Descripcion { get; set; }
        [DisplayName("Imputacion"),Sortable(false), Width(90)]
        public string DescTipo { get;set; }
        [DisplayName("UC"),Sortable(false), Width(60)]
        public string DescUCReserva { get; set; }
        [Sortable(false), Width(70),AlignRight]
        public decimal Cantidad { get; set; }
        [Sortable(false), Width(70), DisplayFormat("#,##0.00"), AlignRight]
        public decimal Precio { get; set; }
        [DisplayName("Produccion"),Sortable(false), Width(80),DisplayFormat("#,##0.00"),AlignRight]
        public decimal PrecioProduccion { get; set; }
        [Sortable(false), Width(80), DisplayFormat("#,##0.00"), AlignRight]
        public decimal Importe { get; set; }
    }
}