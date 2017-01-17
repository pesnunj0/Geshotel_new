
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.Empresas")]
    [BasedOnRow(typeof(Entities.EmpresasRow))]
    public class EmpresasForm
    {
        public String Empresa { get; set; }
        public String EmpresaContable { get; set; }
        public String Direccion { get; set; }
        public String Poblacion { get; set; }
        public String Zip { get; set; }
        public Int16 ProvinciaId { get; set; }
        public String Telefono { get; set; }
        public String Fax { get; set; }
        public String Cif { get; set; }
        public String RutaFicheros { get; set; }
    }
}