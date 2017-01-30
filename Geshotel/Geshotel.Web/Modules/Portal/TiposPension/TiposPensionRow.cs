
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("tipos_pension"), InstanceName("tipos_pension"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.TiposPension")]
    public sealed class TiposPensionRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Pension Id"), Column("tipo_pension_id"), PrimaryKey]
        public Int16? TipoPensionId
        {
            get { return Fields.TipoPensionId[this]; }
            set { Fields.TipoPensionId[this] = value; }
        }

        [DisplayName("Tipo Pension"), Column("Tipo_pension"), Size(16), NotNull, QuickSearch]
        public String TipoPension
        {
            get { return Fields.TipoPension[this]; }
            set { Fields.TipoPension[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TipoPensionId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TipoPension; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposPensionRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TipoPensionId;
            public StringField TipoPension;

            public RowFields()
                : base("tipos_pension")
            {
                LocalTextPrefix = "Portal.TiposPension";
            }
        }
    }
}
