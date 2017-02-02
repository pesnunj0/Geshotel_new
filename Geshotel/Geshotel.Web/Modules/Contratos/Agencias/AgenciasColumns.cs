
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
        [EditLink]
        public String Razon { get; set; }
        public String DescCorta { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public Int16 EmpresaId { get; set; }
        public Int32 AgenciaId { get; set; }
        public Int16 MercadoId { get; set; }
        public Boolean ClienteDefecto { get; set; }
        public Int16 GrupoClienteId { get; set; }
        public String TipoDocumentoId { get; set; }
        public String Nif { get; set; }
        public DateTime FechaDocumento { get; set; }
        public String SexoId { get; set; }
        public String Direccion { get; set; }
        public String Poblacion { get; set; }
        public String Zip { get; set; }
        public Int16 NacionId { get; set; }
        public Int16 ProvinciaId { get; set; }
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
        public Int16 NacionIdFactura { get; set; }
        public Int16 ProvinciaIdFactura { get; set; }
        public Boolean ClienteFactura { get; set; }
        public Boolean ClienteHuesped { get; set; }
        public Boolean PermiteCredito { get; set; }
        public Double LimiteCredito { get; set; }
        public Boolean FacturaAnticipada { get; set; }
        public Int16 VencimientoFacturasId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Int16 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
        public String ClienteBavel { get; set; }
        public String Foto1 { get; set; }
        public String Foto2 { get; set; }
        public Boolean DingusExtras { get; set; }
        public String IdClubhd { get; set; }
    }
}