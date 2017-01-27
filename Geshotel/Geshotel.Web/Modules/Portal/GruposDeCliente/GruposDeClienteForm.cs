
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.GruposDeCliente")]
    [BasedOnRow(typeof(Entities.GruposDeClienteRow))]
    public class GruposDeClienteForm
    {
        public String NombreGrupo { get; set; }
        public Boolean Huesped { get; set; }
        public Boolean Contratos { get; set; }
        public Boolean Facturar { get; set; }
        public Boolean Agencia { get; set; }
        public Int16 Perfil { get; set; }
    }
}