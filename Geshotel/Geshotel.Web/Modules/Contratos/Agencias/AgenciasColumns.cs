
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Agencias")]
    [BasedOnRow(typeof(Entities.AgenciasRow))]
    public class AgenciasColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ClienteId { get; set; }
        [EditLink,QuickFilter]
        public String Razon { get; set; }
        public String DescCorta { get; set; }

        [Width(100), QuickFilter, QuickFilterOption("multiple", true)]
        public String Empresa { get; set; }
        [Width(100), QuickFilter, QuickFilterOption("multiple", true)]
        public String TipoDocumento { get; set; }
        public String Nif { get; set; }
        public DateTime FechaDocumento { get; set; }
        public String Direccion { get; set; }
        public String Poblacion { get; set; }
        public String Zip { get; set; }

        [Width(100), QuickFilter, QuickFilterOption("multiple", true)]
        public String Nacion { get; set; }
        [Width(100), QuickFilter, QuickFilterOption("multiple", true)]
        public String Provincia { get; set; }
        public String CtaContableAnticipo { get; set; }
        public String CtaContable { get; set; }
        public String DptoContable { get; set; }
        public String CtaDepositos { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String Fax { get; set; }
        public String Contacto { get; set; }
        public String TelefonoContacto { get; set; }
        public String FaxContacto { get; set; }
        public String EmailContacto { get; set; }
        public DateTime AceptaLopd { get; set; }
        public String CifFra { get; set; }
        public String DireccionFra { get; set; }
        public String PoblacionFra { get; set; }
        public String ZipFra { get; set; }
        public String FacturaNacion { get; set; }
        public String FacturaProvincia { get; set; }
        public Boolean ClienteFactura { get; set; }
        public Boolean PermiteCredito { get; set; }
        public Double LimiteCredito { get; set; }
        public Boolean FacturaAnticipada { get; set; }
        public Int16 VencimientoFacturasId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String UserName { get; set; }
        public DateTime FechaModificacion { get; set; }
        public String ClienteBavel { get; set; }

    }
}