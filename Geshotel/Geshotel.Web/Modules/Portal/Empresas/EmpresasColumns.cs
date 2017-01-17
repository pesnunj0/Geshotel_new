
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.Empresas")]
    [BasedOnRow(typeof(Entities.EmpresasRow))]
    public class EmpresasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 EmpresaId { get; set; }
        [EditLink]
        public String Empresa { get; set; }
        public String EmpresaContable { get; set; }
        public String Direccion { get; set; }
        public String Poblacion { get; set; }
        public String Zip { get; set; }
        public String Provincia { get; set; }
        public String Telefono { get; set; }
        public String Fax { get; set; }
        public String Cif { get; set; }
        public String RutaFicheros { get; set; }
    }
}