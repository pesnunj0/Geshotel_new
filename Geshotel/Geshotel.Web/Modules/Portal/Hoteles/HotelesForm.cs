﻿
namespace Geshotel.Portal.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Portal.Hoteles")]
    [BasedOnRow(typeof(Entities.HotelesRow))]
    public class HotelesForm
    {
        [Category("General")]
        public String Hotel { get; set; }
        public Int16 EmpresaId { get; set; }
        public Int16 TipoHotelId { get; set; }
        public Int16 CategoriaId { get; set; }
        public String NombreCorto { get; set; }
        [Category("Direccion")]
        public String Direccion { get; set; }
        public String Poblacion { get; set; }
        public String Zip { get; set; }
        public Int16 ProvinciaId { get; set; }
        public Int16 NacionId { get; set; }
        public String Telefono { get; set; }
        public String Fax { get; set; }
        [Category("Emails")]
        public String EmailReservas { get; set; }
        public String EmailVentas { get; set; }
        public String EmailSmtp { get; set; }
        public String TextoCancelacion { get; set; }
        [Category("Contabilidad")]
        public String CtaManocorriente { get; set; }
        public String DptoContable { get; set; }
        public String CtaContableCajas { get; set; }
        public String CtaContableBanco { get; set; }
        public DateTime FechaInicioPrograma { get; set; }
        [Category("Miscelaneo")]
        public String RutaFicheroPolicia { get; set; }
        public Int32 ContadorFicheroPolicia { get; set; }
        public String IdentificadorFicheroPolicia { get; set; }
        public String UsuarioIsta { get; set; }
        public String PasswordIsta { get; set; }
        public String UrlIsta { get; set; }
        public String MunicipioIsta { get; set; }
        public Int32 NumeroRegistroIsta { get; set; }
        public String RutaBavel { get; set; }
        [Category("Dingus")]
        public String DingusUsuario { get; set; }
        public String DingusPassword { get; set; }
        public String DingusHotelCode { get; set; }
        public String DingusTraductor { get; set; }
        public String DingusUrl { get; set; }
        [Category("Online")]
        public Int16 CheckinOnLine { get; set; }
        public Int16 MinimoDiasCheckinOnline { get; set; }
        public Int16 ZoomMapa { get; set; }
        [DecimalEditor(MinValue = "-999.9999999999999999", MaxValue = "999.9999999999999999")]
        public Decimal Lat { get; set; }
        [DecimalEditor(MinValue = "-999.9999999999999999", MaxValue = "999.9999999999999999")]
        public Decimal Lng { get; set; }
        public Int16 Ancho { get; set; }
        public Int16 Alto { get; set; }
        public Double OverbookingLimit { get; set; }
    }
}