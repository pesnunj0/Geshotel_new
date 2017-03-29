
namespace Geshotel.Recepcion.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Recepcion.Huespedes")]
    [BasedOnRow(typeof(Entities.HuespedesRow))]
    public class HuespedesForm
    {
        public Int16 EmpresaId { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String TipoDocumentoId { get; set; }
        public String Nif { get; set; }
        public DateTime FechaDocumento { get; set; }
        public String SexoId { get; set; }
        public String Direccion { get; set; }
        public String Poblacion { get; set; }
        public String Zip { get; set; }
        public Int16 NacionId { get; set; }
        public Int16 ProvinciaId { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String Foto1 { get; set; }
        public String Foto2 { get; set; }
        public String TarjetaFidelizacion { get; set; }
    }
}