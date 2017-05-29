
namespace Geshotel.Recepcion.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Recepcion.ReservasHuespedes")]
    [BasedOnRow(typeof(Entities.ReservasHuespedesRow))]
    public class ReservasHuespedesForm
    {
        [ReadOnly(true),Hidden]
        public Int32 ReservaId { get; set; }
        [Required]
        public Int16 EmpresaId { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        public String Apellidos { get; set; }
        
        public String TipoDocumentoId { get; set; }
        
        public String Nif { get; set; }
        public DateTime FechaDocumento { get; set; }
        public String SexoId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Direccion { get; set; }
        public String Poblacion { get; set; }
        public String Zip { get; set; }
        public Int16 NacionId { get; set; }
        public Int16 ProvinciaId { get; set; }
        [EmailEditor]
        public String Email { get; set; }
        public String Telefono { get; set; }
        [Hidden]
        public Int32 HuespedId { get; set; }
        public Int32 HabitacionId { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public String GalleryImages { get; set; }
        [Hidden]
        public Int16 Edad { get; set; }
    }
}