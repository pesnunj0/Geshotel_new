
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("formas_de_pago"), InstanceName("formas_de_pago"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.FromasDePago")]
    public sealed class FormasDePagoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Forma Pago Id"), Column("forma_pago_id"), Identity]
        public Int16? FormaPagoId
        {
            get { return Fields.FormaPagoId[this]; }
            set { Fields.FormaPagoId[this] = value; }
        }

        [DisplayName("Forma Pago"), Column("forma_pago"), Size(20), NotNull, QuickSearch]
        public String FormaPago
        {
            get { return Fields.FormaPago[this]; }
            set { Fields.FormaPago[this] = value; }
        }

        [DisplayName("Credito"), Column("credito"), Size(1), NotNull]
        public Boolean? Credito
        {
            get { return Fields.Credito[this]; }
            set { Fields.Credito[this] = value; }
        }

        [DisplayName("Sw Efectivo"), Column("sw_efectivo"), Size(1)]
        public Boolean? SwEfectivo
        {
            get { return Fields.SwEfectivo[this]; }
            set { Fields.SwEfectivo[this] = value; }
        }

        [DisplayName("Sw Tarjeta"), Column("sw_tarjeta"), Size(1)]
        public Boolean? SwTarjeta
        {
            get { return Fields.SwTarjeta[this]; }
            set { Fields.SwTarjeta[this] = value; }
        }

        [DisplayName("Tarjeta Length"), Column("tarjeta_length"), Size(20)]
        public String TarjetaLength
        {
            get { return Fields.TarjetaLength[this]; }
            set { Fields.TarjetaLength[this] = value; }
        }

        [DisplayName("Tarjeta Prefixes"), Column("tarjeta_prefixes"), Size(40)]
        public String TarjetaPrefixes
        {
            get { return Fields.TarjetaPrefixes[this]; }
            set { Fields.TarjetaPrefixes[this] = value; }
        }

        [DisplayName("Tarjeta Checkdigit"), Column("tarjeta_checkdigit"), Size(1)]
        public Boolean? TarjetaCheckdigit
        {
            get { return Fields.TarjetaCheckdigit[this]; }
            set { Fields.TarjetaCheckdigit[this] = value; }
        }

        [DisplayName("Sw Dingus"), Column("sw_dingus"), Size(1)]
        public Boolean? SwDingus
        {
            get { return Fields.SwDingus[this]; }
            set { Fields.SwDingus[this] = value; }
        }

        [DisplayName("Produccion Tpv"), Column("produccion_tpv"), Size(1)]
        public Boolean? ProduccionTpv
        {
            get { return Fields.ProduccionTpv[this]; }
            set { Fields.ProduccionTpv[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.FormaPagoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.FormaPago; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public FormasDePagoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field FormaPagoId;
            public StringField FormaPago;
            public BooleanField Credito;
            public BooleanField SwEfectivo;
            public BooleanField SwTarjeta;
            public StringField TarjetaLength;
            public StringField TarjetaPrefixes;
            public BooleanField TarjetaCheckdigit;
            public BooleanField SwDingus;
            public BooleanField ProduccionTpv;

            public RowFields()
                : base("formas_de_pago")
            {
                LocalTextPrefix = "Portal.FormasDePago";
            }
        }
    }
}
