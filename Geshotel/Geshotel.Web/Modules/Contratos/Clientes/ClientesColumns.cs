
namespace Geshotel.Contratos.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Contratos.Clientes")]
    [BasedOnRow(typeof(Entities.ClientesRow))]
    public class ClientesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ClienteId { get; set; }
        [EditLink,QuickFilter]
        public String Razon { get; set; }
        public String DescCorta { get; set; }
        [Width(100),QuickFilter,Hidden,DisplayName("Empresa")]
        public String Empresa { get; set; }
        [Width(130), LookupEditor(("Contratos.Agencias"), FilterField = "GrupoClienteId", FilterValue = 1), QuickFilter, QuickFilterOption("CascadeFrom", "EmpresaId")]
        public String Agencia { get; set; }

        [Width(90), QuickFilter,AlignCenter]
        public Boolean ClienteDefecto { get; set; }
        [Width(100), QuickFilter, QuickFilterOption("multiple", true)]
        public String TipoDocumento { get; set; }
        public String Nif { get; set; }
//        public DateTime FechaDocumento { get; set; }
        [Hidden]
        public String Direccion { get; set; }
        [Hidden]
        public String Poblacion { get; set; }
        [Hidden]
        public String Zip { get; set; }
        [Width(100), QuickFilter, QuickFilterOption("multiple", true)]
        public String Nacion { get; set; }
        [Width(100), QuickFilter, QuickFilterOption("multiple", true)]
        public String Provincia { get; set; }
        [Hidden]
        public String CtaContableAnticipo { get; set; }
        public String CtaContable { get; set; }
        public String DptoContable { get; set; }
        [Hidden]
        public String CtaDepositos { get; set; }
        [Hidden]
        public String Telefono { get; set; }
        public String Email { get; set; }
        [Hidden]
        public String Fax { get; set; }
        [Hidden]
        public String Contacto { get; set; }
        [Hidden]
        public String TelefonoContacto { get; set; }
        [Hidden]
        public String FaxContacto { get; set; }
        [Hidden]
        public String EmailContacto { get; set; }
        [Hidden]
        public String CifFra { get; set; }
        [Hidden]
        public String DireccionFra { get; set; }
        [Hidden]
        public String PoblacionFra { get; set; }
        [Hidden]
        public String ZipFra { get; set; }
        [Hidden]
        public String FacturaNacion { get; set; }
        [Hidden]
        public String FacturaProvincia { get; set; }
        [Hidden]
        public Boolean ClienteFactura { get; set; }
        [Hidden]
        public Boolean ClienteHuesped { get; set; }
        [Hidden]
        public Boolean PermiteCredito { get; set; }
        [Hidden]
        public Double LimiteCredito { get; set; }
        [Width(100),AlignCenter,DisplayName("Fra. Llegada")]
        public Boolean FacturaAnticipada { get; set; }
        [Hidden]
        public Int16 VencimientoFacturasId { get; set; }
        [Width(100), Hidden]
        public String UserName { get; set; }
        [Width(110), DisplayFormat("g"), Hidden]
        public DateTime FechaModificacion { get; set; }
        [DisplayName("Cli_Bavel"),Width(100)]
        public String ClienteBavel { get; set; }
        [Width(100), AlignCenter,Hidden]
        public Boolean DingusExtras { get; set; }
    }
}