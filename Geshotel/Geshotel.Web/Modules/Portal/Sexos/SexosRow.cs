
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("sexos"), InstanceName("sexos"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.Sexos")]
    public sealed class SexosRow : Row, IIdRow, INameRow
    {
        [DisplayName("Sexo Id"), Column("sexo_id"), Size(1), PrimaryKey, QuickSearch]
        public String SexoId
        {
            get { return Fields.SexoId[this]; }
            set { Fields.SexoId[this] = value; }
        }

        [DisplayName("Sexo"), Column("sexo"), Size(15)]
        public String Sexo
        {
            get { return Fields.Sexo[this]; }
            set { Fields.Sexo[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.SexoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.SexoId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public SexosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField SexoId;
            public StringField Sexo;

            public RowFields()
                : base("sexos")
            {
                LocalTextPrefix = "Portal.Sexos";
            }
        }
    }
}
