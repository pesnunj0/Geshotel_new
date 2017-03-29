
namespace Geshotel.Recepcion.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Recepcion.Huespedes")]
    [BasedOnRow(typeof(Entities.HuespedesRow))]
    public class HuespedesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 HuespedId { get; set; }
        [Hidden,Width(90)]
        public String Empresa { get; set; }
        [EditLink, Width(130),QuickFilter]
        public String NombreCompleto { get; set; }
        [Width(85),Hidden]
        public String TipoDocumento { get; set; }
        public String Nif { get; set; }
        [Hidden,Width(100)]
        public DateTime FechaDocumento { get; set; }
        [QuickFilter,Width(75)]
        public String Sexo { get; set; }
        [Hidden,Width(120)]
        public String Direccion { get; set; }
        [Hidden,Width(120)]
        public String Poblacion { get; set; }
        [Hidden,Width(50)]
        public String Zip { get; set; }
        [Width(85),QuickFilter]
        public String Nacion { get; set; }
        [Hidden,Width(80)]
        public Int16 Provincia { get; set; }
        [Hidden,Width(80)]
        public String Telefono { get; set; }
        [Width(120),QuickFilter]
        public String Email { get; set; }
        [Hidden]
        public String Foto1 { get; set; }
        [Hidden]
        public String Foto2 { get; set; }
        [Hidden,Width(80)]
        public String TarjetaFidelizacion { get; set; }
    }
}