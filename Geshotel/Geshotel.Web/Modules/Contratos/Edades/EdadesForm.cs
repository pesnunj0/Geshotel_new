
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Edades")]
    [BasedOnRow(typeof(Entities.EdadesRow))]
    public class EdadesForm
    {
        public Int16 TipoHuespedId { get; set; }
        public Int32 EdadMinima { get; set; }
        public Int32 EdadMaxima { get; set; }
        public Int16 UserId { get; set; }
    }
}