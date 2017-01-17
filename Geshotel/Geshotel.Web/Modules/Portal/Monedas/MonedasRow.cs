
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Portal"), DisplayName("monedas"), InstanceName("monedas"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.Monedas")]
    public sealed class MonedasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Moneda Id"), Column("moneda_id"), Identity]
        public Int16? MonedaId
        {
            get { return Fields.MonedaId[this]; }
            set { Fields.MonedaId[this] = value; }
        }

        [DisplayName("Descripcion"), Column("descripcion"), Size(20), NotNull, QuickSearch]
        public String Descripcion
        {
            get { return Fields.Descripcion[this]; }
            set { Fields.Descripcion[this] = value; }
        }

        [DisplayName("Desc Corta"), Column("desc_corta"), Size(10), NotNull]
        public String DescCorta
        {
            get { return Fields.DescCorta[this]; }
            set { Fields.DescCorta[this] = value; }
        }


        [DisplayName("Cambio"), Column("cambio")]
        public Double? Cambio
        {
            get { return Fields.Cambio[this]; }
            set { Fields.Cambio[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.MonedaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Descripcion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MonedasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field MonedaId;
            public StringField DescCorta;
            public StringField Descripcion;
            public DoubleField Cambio;

            public RowFields()
                : base("monedas")
            {
                LocalTextPrefix = "Portal.Monedas";
            }
        }
    }
}
