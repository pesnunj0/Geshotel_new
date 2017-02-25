
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("tipos_de_tarjeta"), DisplayName("Tipos De Tarjeta"), InstanceName("Tipos De Tarjeta"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.TiposDeTarjeta")]

    public sealed class TiposDeTarjetaRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Tarjeta Id"), Column("tipo_tarjeta_id"), Identity]
        public Int16? TipoTarjetaId
        {
            get { return Fields.TipoTarjetaId[this]; }
            set { Fields.TipoTarjetaId[this] = value; }
        }

        [DisplayName("Tipo Tarjeta"), Column("tipo_tarjeta"), Size(15), QuickSearch]
        public String TipoTarjeta
        {
            get { return Fields.TipoTarjeta[this]; }
            set { Fields.TipoTarjeta[this] = value; }
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

        [DisplayName("Tarjeta Checkdigit"), Column("tarjeta_checkdigit")]
        public Boolean? TarjetaCheckdigit
        {
            get { return Fields.TarjetaCheckdigit[this]; }
            set { Fields.TarjetaCheckdigit[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TipoTarjetaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TipoTarjeta; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposDeTarjetaRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TipoTarjetaId;
            public StringField TipoTarjeta;
            public StringField TarjetaLength;
            public StringField TarjetaPrefixes;
            public BooleanField TarjetaCheckdigit;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Portal.TiposDeTarjeta";
            }
        }
    }
}
