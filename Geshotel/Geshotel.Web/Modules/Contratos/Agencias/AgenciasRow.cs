
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Agencias"), InstanceName("Agencias"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    [LookupScript("Contratos.Agencias")]
    public sealed class AgenciasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Cliente Id"), Column("cliente_id"), Identity]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }

        [DisplayName("Razon"), Column("razon"), Size(60), NotNull, QuickSearch]
        public String Razon
        {
            get { return Fields.Razon[this]; }
            set { Fields.Razon[this] = value; }
        }

        [DisplayName("Desc Corta"), Column("desc_corta"), Size(8)]
        public String DescCorta
        {
            get { return Fields.DescCorta[this]; }
            set { Fields.DescCorta[this] = value; }
        }

        [DisplayName("Nombre"), Column("nombre"), Size(30)]
        public String Nombre
        {
            get { return Fields.Nombre[this]; }
            set { Fields.Nombre[this] = value; }
        }

        [DisplayName("Apellidos"), Column("apellidos"), Size(50)]
        public String Apellidos
        {
            get { return Fields.Apellidos[this]; }
            set { Fields.Apellidos[this] = value; }
        }

        [DisplayName("Empresa Id"), Column("empresa_id"), NotNull]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }
        }

        [DisplayName("Agencia Id"), Column("agencia_id")]
        public Int32? AgenciaId
        {
            get { return Fields.AgenciaId[this]; }
            set { Fields.AgenciaId[this] = value; }
        }

        [DisplayName("Mercado Id"), Column("mercado_id")]
        public Int16? MercadoId
        {
            get { return Fields.MercadoId[this]; }
            set { Fields.MercadoId[this] = value; }
        }

        [DisplayName("Cliente Defecto"), Column("cliente_defecto")]
        public Boolean? ClienteDefecto
        {
            get { return Fields.ClienteDefecto[this]; }
            set { Fields.ClienteDefecto[this] = value; }
        }

        [DisplayName("Grupo Cliente Id"), Column("grupo_cliente_id"), NotNull, LookupInclude]
        public Int16? GrupoClienteId
        {
            get { return Fields.GrupoClienteId[this]; }
            set { Fields.GrupoClienteId[this] = value; }
        }

        [DisplayName("Tipo Documento Id"), Column("tipo_documento_id"), Size(1)]
        public String TipoDocumentoId
        {
            get { return Fields.TipoDocumentoId[this]; }
            set { Fields.TipoDocumentoId[this] = value; }
        }

        [DisplayName("Nif"), Column("nif"), Size(20)]
        public String Nif
        {
            get { return Fields.Nif[this]; }
            set { Fields.Nif[this] = value; }
        }

        [DisplayName("Fecha Documento"), Column("fecha_documento")]
        public DateTime? FechaDocumento
        {
            get { return Fields.FechaDocumento[this]; }
            set { Fields.FechaDocumento[this] = value; }
        }

        [DisplayName("Sexo Id"), Column("sexo_id"), Size(1)]
        public String SexoId
        {
            get { return Fields.SexoId[this]; }
            set { Fields.SexoId[this] = value; }
        }

        [DisplayName("Direccion"), Column("direccion"), Size(70)]
        public String Direccion
        {
            get { return Fields.Direccion[this]; }
            set { Fields.Direccion[this] = value; }
        }

        [DisplayName("Poblacion"), Column("poblacion"), Size(70)]
        public String Poblacion
        {
            get { return Fields.Poblacion[this]; }
            set { Fields.Poblacion[this] = value; }
        }

        [DisplayName("Zip"), Column("zip"), Size(10)]
        public String Zip
        {
            get { return Fields.Zip[this]; }
            set { Fields.Zip[this] = value; }
        }

        [DisplayName("Nacion Id"), Column("nacion_id")]
        public Int16? NacionId
        {
            get { return Fields.NacionId[this]; }
            set { Fields.NacionId[this] = value; }
        }

        [DisplayName("Provincia Id"), Column("provincia_id")]
        public Int16? ProvinciaId
        {
            get { return Fields.ProvinciaId[this]; }
            set { Fields.ProvinciaId[this] = value; }
        }

        [DisplayName("Cta Contable Anticipo"), Column("cta_contable_anticipo"), Size(16)]
        public String CtaContableAnticipo
        {
            get { return Fields.CtaContableAnticipo[this]; }
            set { Fields.CtaContableAnticipo[this] = value; }
        }

        [DisplayName("Cta Contable"), Column("cta_contable"), Size(16)]
        public String CtaContable
        {
            get { return Fields.CtaContable[this]; }
            set { Fields.CtaContable[this] = value; }
        }

        [DisplayName("Dpto Contable"), Column("dpto_contable"), Size(5)]
        public String DptoContable
        {
            get { return Fields.DptoContable[this]; }
            set { Fields.DptoContable[this] = value; }
        }

        [DisplayName("Cta Depositos"), Column("cta_depositos"), Size(15)]
        public String CtaDepositos
        {
            get { return Fields.CtaDepositos[this]; }
            set { Fields.CtaDepositos[this] = value; }
        }

        [DisplayName("Telefono"), Column("telefono"), Size(20)]
        public String Telefono
        {
            get { return Fields.Telefono[this]; }
            set { Fields.Telefono[this] = value; }
        }

        [DisplayName("Email"), Column("email"), Size(100)]
        public String Email
        {
            get { return Fields.Email[this]; }
            set { Fields.Email[this] = value; }
        }

        [DisplayName("Fax"), Column("fax"), Size(20)]
        public String Fax
        {
            get { return Fields.Fax[this]; }
            set { Fields.Fax[this] = value; }
        }

        [DisplayName("Contacto"), Column("contacto"), Size(70)]
        public String Contacto
        {
            get { return Fields.Contacto[this]; }
            set { Fields.Contacto[this] = value; }
        }

        [DisplayName("Telefono Contacto"), Column("telefono_contacto"), Size(20)]
        public String TelefonoContacto
        {
            get { return Fields.TelefonoContacto[this]; }
            set { Fields.TelefonoContacto[this] = value; }
        }

        [DisplayName("Fax Contacto"), Column("fax_contacto"), Size(20)]
        public String FaxContacto
        {
            get { return Fields.FaxContacto[this]; }
            set { Fields.FaxContacto[this] = value; }
        }

        [DisplayName("Email Contacto"), Column("email_contacto"), Size(100)]
        public String EmailContacto
        {
            get { return Fields.EmailContacto[this]; }
            set { Fields.EmailContacto[this] = value; }
        }

        [DisplayName("Acepta Lopd"), Column("acepta_lopd")]
        public DateTime? AceptaLopd
        {
            get { return Fields.AceptaLopd[this]; }
            set { Fields.AceptaLopd[this] = value; }
        }

        [DisplayName("Cif Fra"), Column("cif_fra"), Size(20)]
        public String CifFra
        {
            get { return Fields.CifFra[this]; }
            set { Fields.CifFra[this] = value; }
        }

        [DisplayName("Direccion Fra"), Column("direccion_fra"), Size(70)]
        public String DireccionFra
        {
            get { return Fields.DireccionFra[this]; }
            set { Fields.DireccionFra[this] = value; }
        }

        [DisplayName("Poblacion Fra"), Column("poblacion_fra"), Size(70)]
        public String PoblacionFra
        {
            get { return Fields.PoblacionFra[this]; }
            set { Fields.PoblacionFra[this] = value; }
        }

        [DisplayName("Zip Fra"), Column("zip_fra"), Size(10)]
        public String ZipFra
        {
            get { return Fields.ZipFra[this]; }
            set { Fields.ZipFra[this] = value; }
        }

        [DisplayName("Nacion Id Factura"), Column("nacion_id_factura")]
        public Int16? NacionIdFactura
        {
            get { return Fields.NacionIdFactura[this]; }
            set { Fields.NacionIdFactura[this] = value; }
        }

        [DisplayName("Provincia Id Factura"), Column("provincia_id_factura")]
        public Int16? ProvinciaIdFactura
        {
            get { return Fields.ProvinciaIdFactura[this]; }
            set { Fields.ProvinciaIdFactura[this] = value; }
        }

        [DisplayName("Cliente Factura"), Column("Cliente_factura")]
        public Boolean? ClienteFactura
        {
            get { return Fields.ClienteFactura[this]; }
            set { Fields.ClienteFactura[this] = value; }
        }

        [DisplayName("Cliente Huesped"), Column("Cliente_huesped")]
        public Boolean? ClienteHuesped
        {
            get { return Fields.ClienteHuesped[this]; }
            set { Fields.ClienteHuesped[this] = value; }
        }

        [DisplayName("Permite Credito"), Column("permite_credito")]
        public Boolean? PermiteCredito
        {
            get { return Fields.PermiteCredito[this]; }
            set { Fields.PermiteCredito[this] = value; }
        }

        [DisplayName("Limite Credito"), Column("limite_credito")]
        public Double? LimiteCredito
        {
            get { return Fields.LimiteCredito[this]; }
            set { Fields.LimiteCredito[this] = value; }
        }

        [DisplayName("Factura Anticipada"), Column("factura_anticipada")]
        public Boolean? FacturaAnticipada
        {
            get { return Fields.FacturaAnticipada[this]; }
            set { Fields.FacturaAnticipada[this] = value; }
        }

        [DisplayName("Vencimiento Facturas Id"), Column("vencimiento_facturas_id")]
        public Int16? VencimientoFacturasId
        {
            get { return Fields.VencimientoFacturasId[this]; }
            set { Fields.VencimientoFacturasId[this] = value; }
        }

        [DisplayName("Fecha Nacimiento"), Column("fecha_nacimiento")]
        public DateTime? FechaNacimiento
        {
            get { return Fields.FechaNacimiento[this]; }
            set { Fields.FechaNacimiento[this] = value; }
        }

        [DisplayName("User Id"), Column("user_id")]
        public Int16? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }

        [DisplayName("Fecha Modificacion"), Column("fecha_modificacion")]
        public DateTime? FechaModificacion
        {
            get { return Fields.FechaModificacion[this]; }
            set { Fields.FechaModificacion[this] = value; }
        }

        [DisplayName("Cliente Bavel"), Column("cliente_bavel"), Size(20)]
        public String ClienteBavel
        {
            get { return Fields.ClienteBavel[this]; }
            set { Fields.ClienteBavel[this] = value; }
        }

        [DisplayName("Foto1"), Column("foto1"), Size(256)]
        public String Foto1
        {
            get { return Fields.Foto1[this]; }
            set { Fields.Foto1[this] = value; }
        }

        [DisplayName("Foto2"), Column("foto2"), Size(256)]
        public String Foto2
        {
            get { return Fields.Foto2[this]; }
            set { Fields.Foto2[this] = value; }
        }

        [DisplayName("Dingus Extras"), Column("dingus_extras")]
        public Boolean? DingusExtras
        {
            get { return Fields.DingusExtras[this]; }
            set { Fields.DingusExtras[this] = value; }
        }

        [DisplayName("Id Clubhd"), Column("id_clubhd"), Size(15)]
        public String IdClubhd
        {
            get { return Fields.IdClubhd[this]; }
            set { Fields.IdClubhd[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ClienteId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Razon; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AgenciasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ClienteId;
            public StringField Razon;
            public StringField DescCorta;
            public StringField Nombre;
            public StringField Apellidos;
            public Int16Field EmpresaId;
            public Int32Field AgenciaId;
            public Int16Field MercadoId;
            public BooleanField ClienteDefecto;
            public Int16Field GrupoClienteId;
            public StringField TipoDocumentoId;
            public StringField Nif;
            public DateTimeField FechaDocumento;
            public StringField SexoId;
            public StringField Direccion;
            public StringField Poblacion;
            public StringField Zip;
            public Int16Field NacionId;
            public Int16Field ProvinciaId;
            public StringField CtaContableAnticipo;
            public StringField CtaContable;
            public StringField DptoContable;
            public StringField CtaDepositos;
            public StringField Telefono;
            public StringField Email;
            public StringField Fax;
            public StringField Contacto;
            public StringField TelefonoContacto;
            public StringField FaxContacto;
            public StringField EmailContacto;
            public DateTimeField AceptaLopd;
            public StringField CifFra;
            public StringField DireccionFra;
            public StringField PoblacionFra;
            public StringField ZipFra;
            public Int16Field NacionIdFactura;
            public Int16Field ProvinciaIdFactura;
            public BooleanField ClienteFactura;
            public BooleanField ClienteHuesped;
            public BooleanField PermiteCredito;
            public DoubleField LimiteCredito;
            public BooleanField FacturaAnticipada;
            public Int16Field VencimientoFacturasId;
            public DateTimeField FechaNacimiento;
            public Int16Field UserId;
            public DateTimeField FechaModificacion;
            public StringField ClienteBavel;
            public StringField Foto1;
            public StringField Foto2;
            public BooleanField DingusExtras;
            public StringField IdClubhd;

            public RowFields()
                : base("[dbo].[clientes]")
            {
                LocalTextPrefix = "Contratos.Agencias";
            }
        }
    }
}
