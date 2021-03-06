﻿
namespace Geshotel.Contratos.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Contratos.Agencias")]
    [BasedOnRow(typeof(Entities.AgenciasRow))]
    public class AgenciasForm
    {
        [Category("General")]
        public String Razon { get; set; }
        public String DescCorta { get; set; }
        public Int16 EmpresaId { get; set; }
        [DisplayName("Tipo Cliente"), DefaultValue(1)]
        public Int16 GrupoClienteId { get; set; }
        public String TipoDocumentoId { get; set; }
        public String Nif { get; set; }
        [Category("Dirección")]
        public DateTime FechaDocumento { get; set; }
        public String Direccion { get; set; }
        public String Poblacion { get; set; }
        public String Zip { get; set; }
        public Int16 NacionId { get; set; }
        public Int16 ProvinciaId { get; set; }
        [Category("Contabilidad")]
        public String CtaContableAnticipo { get; set; }
        public String CtaContable { get; set; }
        public String DptoContable { get; set; }
        public String CtaDepositos { get; set; }
        [Category("Contacto")]
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String Fax { get; set; }
        public String Contacto { get; set; }
        public String TelefonoContacto { get; set; }
        public String FaxContacto { get; set; }
        public String EmailContacto { get; set; }
        [Category("Facturación")]
        public String CifFra { get; set; }
        public String DireccionFra { get; set; }
        public String PoblacionFra { get; set; }
        public String ZipFra { get; set; }
        public Int16 NacionIdFactura { get; set; }
        public Int16 ProvinciaIdFactura { get; set; }
        public Boolean ClienteFactura { get; set; }
        public Boolean PermiteCredito { get; set; }
        public Double LimiteCredito { get; set; }
        public Boolean FacturaAnticipada { get; set; }
        public Int16 VencimientoFacturasId { get; set; }
        [Category("Extras")]
        public Int16 UserId { get; set; }
        public DateTime FechaModificacion { get; set; }
        public String ClienteBavel { get; set; }
    }
}