
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("hoteles"), InstanceName("hoteles"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]

    public sealed class HotelesRow : Row, IIdRow, INameRow, ITenantRow
    {
        [DisplayName("Hotel Id"), Column("hotel_id"), Identity]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel"), Size(50), NotNull, QuickSearch]
        public String Hotel
        {
            get { return Fields.Hotel[this]; }
            set { Fields.Hotel[this] = value; }
        }

        [DisplayName("Empresa"), Column("empresa_id"), NotNull, ForeignKey("empresas", "empresa_id"), LookupInclude, LeftJoin("jEmpresa")]
        [LookupEditor("Portal.Empresas", InplaceAdd = true)]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }
        }

        [DisplayName("Tipo Hotel"), Column("tipo_hotel_id"), NotNull, ForeignKey("tipos_hotel", "tipo_hotel_id"), LeftJoin("jTipoHotel"), TextualField("TipoHotel")]
        [LookupEditor(typeof(TiposHotelRow), InplaceAdd = true)]
        public Int16? TipoHotelId
        {
            get { return Fields.TipoHotelId[this]; }
            set { Fields.TipoHotelId[this] = value; }
        }

        [DisplayName("Categoria"), Column("categoria_id"), NotNull, ForeignKey("categoria_hoteles", "categoria_id"), LeftJoin("jCategoria"), TextualField("Categoria")]
        [LookupEditor(typeof(CategoriaHotelesRow), InplaceAdd = true)]
        public Int16? CategoriaId
        {
            get { return Fields.CategoriaId[this]; }
            set { Fields.CategoriaId[this] = value; }
        }

        [DisplayName("Nombre Corto"), Column("nombre_corto"), Size(6)]
        public String NombreCorto
        {
            get { return Fields.NombreCorto[this]; }
            set { Fields.NombreCorto[this] = value; }
        }

        [DisplayName("Direccion"), Column("direccion"), Size(50)]
        public String Direccion
        {
            get { return Fields.Direccion[this]; }
            set { Fields.Direccion[this] = value; }
        }

        [DisplayName("Poblacion"), Column("poblacion"), Size(50)]
        public String Poblacion
        {
            get { return Fields.Poblacion[this]; }
            set { Fields.Poblacion[this] = value; }
        }

        [DisplayName("Zip"), Column("zip"), Size(5)]
        public String Zip
        {
            get { return Fields.Zip[this]; }
            set { Fields.Zip[this] = value; }
        }

        [DisplayName("Provincia"), Column("provincia_id"), NotNull, ForeignKey("provincias", "provincia_id"), LeftJoin("jProvincia"), TextualField("Provincia")]
        [LookupEditor(typeof(ProvinciasRow), InplaceAdd = true)]
        public Int16? ProvinciaId
        {
            get { return Fields.ProvinciaId[this]; }
            set { Fields.ProvinciaId[this] = value; }
        }

        [DisplayName("Nacion"), Column("nacion_id"), NotNull, ForeignKey("naciones", "nacion_id"), LeftJoin("jnacion"), TextualField("Nacion")]
        [LookupEditor(typeof(NacionesRow), InplaceAdd = true)]
        public Int16? NacionId
        {
            get { return Fields.NacionId[this]; }
            set { Fields.NacionId[this] = value; }
        }

        [DisplayName("Telefono"), Column("telefono"), Size(20)]
        public String Telefono
        {
            get { return Fields.Telefono[this]; }
            set { Fields.Telefono[this] = value; }
        }

        [DisplayName("Fax"), Column("fax"), Size(20)]
        public String Fax
        {
            get { return Fields.Fax[this]; }
            set { Fields.Fax[this] = value; }
        }

        [DisplayName("Cta Manocorriente"), Column("cta_manocorriente"), Size(16)]
        public String CtaManocorriente
        {
            get { return Fields.CtaManocorriente[this]; }
            set { Fields.CtaManocorriente[this] = value; }
        }

        [DisplayName("Dpto Contable"), Column("dpto_contable"), Size(5)]
        public String DptoContable
        {
            get { return Fields.DptoContable[this]; }
            set { Fields.DptoContable[this] = value; }
        }

        [DisplayName("Cta Contable Cajas"), Column("cta_contable_cajas"), Size(16)]
        public String CtaContableCajas
        {
            get { return Fields.CtaContableCajas[this]; }
            set { Fields.CtaContableCajas[this] = value; }
        }

        [DisplayName("Cta Contable Banco"), Column("cta_contable_banco"), Size(16)]
        public String CtaContableBanco
        {
            get { return Fields.CtaContableBanco[this]; }
            set { Fields.CtaContableBanco[this] = value; }
        }

        [DisplayName("Fecha Inicio Programa"), Column("fecha_inicio_programa")]
        public DateTime? FechaInicioPrograma
        {
            get { return Fields.FechaInicioPrograma[this]; }
            set { Fields.FechaInicioPrograma[this] = value; }
        }

        [DisplayName("Ruta Fichero Policia"), Column("ruta_fichero_policia"), Size(512)]
        public String RutaFicheroPolicia
        {
            get { return Fields.RutaFicheroPolicia[this]; }
            set { Fields.RutaFicheroPolicia[this] = value; }
        }

        [DisplayName("Contador Fichero Policia"), Column("contador_fichero_policia")]
        public Int32? ContadorFicheroPolicia
        {
            get { return Fields.ContadorFicheroPolicia[this]; }
            set { Fields.ContadorFicheroPolicia[this] = value; }
        }

        [DisplayName("Identificador Fichero Policia"), Column("identificador_fichero_policia"), Size(10)]
        public String IdentificadorFicheroPolicia
        {
            get { return Fields.IdentificadorFicheroPolicia[this]; }
            set { Fields.IdentificadorFicheroPolicia[this] = value; }
        }

        [DisplayName("Email Reservas"), Column("email_reservas"), Size(100)]
        public String EmailReservas
        {
            get { return Fields.EmailReservas[this]; }
            set { Fields.EmailReservas[this] = value; }
        }

        [DisplayName("Email Ventas"), Column("email_ventas"), Size(100)]
        public String EmailVentas
        {
            get { return Fields.EmailVentas[this]; }
            set { Fields.EmailVentas[this] = value; }
        }

        [DisplayName("Email Smtp"), Column("email_smtp"), Size(100)]
        public String EmailSmtp
        {
            get { return Fields.EmailSmtp[this]; }
            set { Fields.EmailSmtp[this] = value; }
        }

        [DisplayName("Texto Cancelacion"), Column("texto_cancelacion"), Size(65535)]
        public String TextoCancelacion
        {
            get { return Fields.TextoCancelacion[this]; }
            set { Fields.TextoCancelacion[this] = value; }
        }

        [DisplayName("Usuario Ista"), Column("usuario_ista"), Size(65535)]
        public String UsuarioIsta
        {
            get { return Fields.UsuarioIsta[this]; }
            set { Fields.UsuarioIsta[this] = value; }
        }

        [DisplayName("Password Ista"), Column("password_ista"), Size(65535)]
        public String PasswordIsta
        {
            get { return Fields.PasswordIsta[this]; }
            set { Fields.PasswordIsta[this] = value; }
        }

        [DisplayName("Url Ista"), Column("url_ista"), Size(65535)]
        public String UrlIsta
        {
            get { return Fields.UrlIsta[this]; }
            set { Fields.UrlIsta[this] = value; }
        }

        [DisplayName("Municipio Ista"), Column("municipio_ista"), Size(65535)]
        public String MunicipioIsta
        {
            get { return Fields.MunicipioIsta[this]; }
            set { Fields.MunicipioIsta[this] = value; }
        }

        [DisplayName("Numero Registro Ista"), Column("numero_registro_ista")]
        public Int32? NumeroRegistroIsta
        {
            get { return Fields.NumeroRegistroIsta[this]; }
            set { Fields.NumeroRegistroIsta[this] = value; }
        }

        [DisplayName("Ruta Bavel"), Column("ruta_bavel"), Size(100)]
        public String RutaBavel
        {
            get { return Fields.RutaBavel[this]; }
            set { Fields.RutaBavel[this] = value; }
        }

        [DisplayName("Dingus Usuario"), Column("dingus_usuario"), Size(20)]
        public String DingusUsuario
        {
            get { return Fields.DingusUsuario[this]; }
            set { Fields.DingusUsuario[this] = value; }
        }

        [DisplayName("Dingus Password"), Column("dingus_password"), Size(20)]
        public String DingusPassword
        {
            get { return Fields.DingusPassword[this]; }
            set { Fields.DingusPassword[this] = value; }
        }

        [DisplayName("Dingus Hotel Code"), Column("dingus_hotel_code"), Size(10)]
        public String DingusHotelCode
        {
            get { return Fields.DingusHotelCode[this]; }
            set { Fields.DingusHotelCode[this] = value; }
        }

        [DisplayName("Dingus Traductor"), Column("dingus_traductor"), Size(10)]
        public String DingusTraductor
        {
            get { return Fields.DingusTraductor[this]; }
            set { Fields.DingusTraductor[this] = value; }
        }

        [DisplayName("Dingus Url"), Column("dingus_url"), Size(255)]
        public String DingusUrl
        {
            get { return Fields.DingusUrl[this]; }
            set { Fields.DingusUrl[this] = value; }
        }

        [DisplayName("Checkin On Line"), Column("checkin_on_line"), NotNull]
        public Int16? CheckinOnLine
        {
            get { return Fields.CheckinOnLine[this]; }
            set { Fields.CheckinOnLine[this] = value; }
        }

        [DisplayName("Minimo Dias Checkin Online"), Column("minimo_dias_checkin_online")]
        public Int16? MinimoDiasCheckinOnline
        {
            get { return Fields.MinimoDiasCheckinOnline[this]; }
            set { Fields.MinimoDiasCheckinOnline[this] = value; }
        }

        [DisplayName("Zoom Mapa"), Column("zoom_mapa")]
        public Int16? ZoomMapa
        {
            get { return Fields.ZoomMapa[this]; }
            set { Fields.ZoomMapa[this] = value; }
        }

        [DisplayName("Lat"), Column("lat"), Size(30), Scale(15)]
        public Decimal? Lat
        {
            get { return Fields.Lat[this]; }
            set { Fields.Lat[this] = value; }
        }

        [DisplayName("Lng"), Column("lng"), Size(30), Scale(15)]
        public Decimal? Lng
        {
            get { return Fields.Lng[this]; }
            set { Fields.Lng[this] = value; }
        }

        [DisplayName("Ancho"), Column("ancho")]
        public Int16? Ancho
        {
            get { return Fields.Ancho[this]; }
            set { Fields.Ancho[this] = value; }
        }

        [DisplayName("Alto"), Column("alto")]
        public Int16? Alto
        {
            get { return Fields.Alto[this]; }
            set { Fields.Alto[this] = value; }
        }

        [DisplayName("Overbooking Limit"), Column("overbooking_limit")]
        public Double? OverbookingLimit
        {
            get { return Fields.OverbookingLimit[this]; }
            set { Fields.OverbookingLimit[this] = value; }
        }

        [DisplayName("Empresa"), Expression("jEmpresa.[empresa]")]
        public String Empresa
        {
            get { return Fields.Empresa[this]; }
            set { Fields.Empresa[this] = value; }
        }


        [DisplayName("Tipo Hotel"), Expression("jTipoHotel.[tipo_hotel]")]
        public String TipoHotel
        {
            get { return Fields.TipoHotel[this]; }
            set { Fields.TipoHotel[this] = value; }
        }

        [DisplayName("Tipo Hotel Abreviatura"), Expression("jTipoHotel.[abreviatura]")]
        public String TipoHotelAbreviatura
        {
            get { return Fields.TipoHotelAbreviatura[this]; }
            set { Fields.TipoHotelAbreviatura[this] = value; }
        }

        [DisplayName("Categoria"), Expression("jCategoria.[categoria]")]
        public String Categoria
        {
            get { return Fields.Categoria[this]; }
            set { Fields.Categoria[this] = value; }
        }

        [DisplayName("Categoria Abreviatura"), Expression("jCategoria.[abreviatura]")]
        public String CategoriaAbreviatura
        {
            get { return Fields.CategoriaAbreviatura[this]; }
            set { Fields.CategoriaAbreviatura[this] = value; }
        }

        [DisplayName("Provincia"), Expression("jProvincia.[Provincia]")]
        public String Provincia
        {
            get { return Fields.Provincia[this]; }
            set { Fields.Provincia[this] = value; }
        }

        [DisplayName("Nacion"), Expression("jnacion.[nacion]")]
        public String Nacion
        {
            get { return Fields.Nacion[this]; }
            set { Fields.Nacion[this] = value; }
        }

        [DisplayName("Provincia Comunidad Autonoma Id"), Expression("jProvincia.[comunidad_autonoma_id]")]
        public Int16? ProvinciaComunidadAutonomaId
        {
            get { return Fields.ProvinciaComunidadAutonomaId[this]; }
            set { Fields.ProvinciaComunidadAutonomaId[this] = value; }
        }

        [DisplayName("Provincia Provincia Ista"), Expression("jProvincia.[provincia_ista]")]
        public String ProvinciaProvinciaIsta
        {
            get { return Fields.ProvinciaProvinciaIsta[this]; }
            set { Fields.ProvinciaProvinciaIsta[this] = value; }
        }

        [DisplayName("Provincia Defecto Ista"), Expression("jProvincia.[defecto_ista]")]
        public Int16? ProvinciaDefectoIsta
        {
            get { return Fields.ProvinciaDefectoIsta[this]; }
            set { Fields.ProvinciaDefectoIsta[this] = value; }
        }

        public Int16Field HotelIdField
        {
            get { return Fields.HotelId; }
        }
        public Int16Field EmpresaIdField
        {
            get { return Fields.EmpresaId; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.HotelId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Hotel; }
        }

  

        public static readonly RowFields Fields = new RowFields().Init();

        public HotelesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field HotelId;
            public StringField Hotel;
            public Int16Field EmpresaId;
            public Int16Field TipoHotelId;
            public Int16Field CategoriaId;
            public StringField NombreCorto;
            public StringField Direccion;
            public StringField Poblacion;
            public StringField Zip;
            public Int16Field ProvinciaId;
            public Int16Field NacionId;
            public StringField Telefono;
            public StringField Fax;
            public StringField CtaManocorriente;
            public StringField DptoContable;
            public StringField CtaContableCajas;
            public StringField CtaContableBanco;
            public DateTimeField FechaInicioPrograma;
            public StringField RutaFicheroPolicia;
            public Int32Field ContadorFicheroPolicia;
            public StringField IdentificadorFicheroPolicia;
            public StringField EmailReservas;
            public StringField EmailVentas;
            public StringField EmailSmtp;
            public StringField TextoCancelacion;
            public StringField UsuarioIsta;
            public StringField PasswordIsta;
            public StringField UrlIsta;
            public StringField MunicipioIsta;
            public Int32Field NumeroRegistroIsta;
            public StringField RutaBavel;
            public StringField DingusUsuario;
            public StringField DingusPassword;
            public StringField DingusHotelCode;
            public StringField DingusTraductor;
            public StringField DingusUrl;
            public Int16Field CheckinOnLine;
            public Int16Field MinimoDiasCheckinOnline;
            public Int16Field ZoomMapa;
            public DecimalField Lat;
            public DecimalField Lng;
            public Int16Field Ancho;
            public Int16Field Alto;
            public DoubleField OverbookingLimit;

            public StringField Empresa;
            //public StringField EmpresaEmpresaContable;
            //public StringField EmpresaDireccion;
            //public StringField EmpresaPoblacion;
            //public StringField EmpresaZip;
            //public Int16Field EmpresaProvinciaId;
            //public StringField EmpresaTelefono;
            //public StringField EmpresaFax;
            //public StringField EmpresaCif;

            public StringField TipoHotel;
            public StringField TipoHotelAbreviatura;

            public StringField Categoria;
            public StringField CategoriaAbreviatura;

            public StringField Provincia;
            public StringField Nacion;
            public Int16Field ProvinciaComunidadAutonomaId;
            public StringField ProvinciaProvinciaIsta;
            public Int16Field ProvinciaDefectoIsta;

            public RowFields()
                : base("hoteles")
            {
                LocalTextPrefix = "Portal.Hoteles";
            }
        }
    }
}
