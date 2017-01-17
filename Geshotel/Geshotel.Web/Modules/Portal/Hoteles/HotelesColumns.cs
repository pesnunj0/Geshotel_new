
namespace Geshotel.Portal.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Portal.Hoteles")]
    [BasedOnRow(typeof(Entities.HotelesRow))]
    public class HotelesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 HotelId { get; set; }
        [EditLink]
        public String Hotel { get; set; }
        public String Empresa { get; set; }
        public String TipoHotel { get; set; }
        public String Categoria { get; set; }
        public String NombreCorto { get; set; }
        public String Direccion { get; set; }
        public String Poblacion { get; set; }
        public String Zip { get; set; }
        public String Provincia { get; set; }
        public String Nacion { get; set; }
        public String Telefono { get; set; }
        public String Fax { get; set; }
        public String CtaManocorriente { get; set; }
        public String DptoContable { get; set; }
        public String CtaContableCajas { get; set; }
        public String CtaContableBanco { get; set; }
        public DateTime FechaInicioPrograma { get; set; }
        public String RutaFicheroPolicia { get; set; }
        public Int32 ContadorFicheroPolicia { get; set; }
        public String IdentificadorFicheroPolicia { get; set; }
        public String EmailReservas { get; set; }
        public String EmailVentas { get; set; }
        public String EmailSmtp { get; set; }
        public String TextoCancelacion { get; set; }
        public String UsuarioIsta { get; set; }
        public String PasswordIsta { get; set; }
        public String UrlIsta { get; set; }
        public String MunicipioIsta { get; set; }
        public Int32 NumeroRegistroIsta { get; set; }
        public String RutaBavel { get; set; }
        public String DingusUsuario { get; set; }
        public String DingusPassword { get; set; }
        public String DingusHotelCode { get; set; }
        public String DingusTraductor { get; set; }
        public String DingusUrl { get; set; }
        public Int16 CheckinOnLine { get; set; }
        public Int16 MinimoDiasCheckinOnline { get; set; }
        public Int16 ZoomMapa { get; set; }
        //public Double Lat { get; set; }
        //public Double Lng { get; set; }
        public Int16 Ancho { get; set; }
        public Int16 Alto { get; set; }
        public Double OverbookingLimit { get; set; }
    }
}