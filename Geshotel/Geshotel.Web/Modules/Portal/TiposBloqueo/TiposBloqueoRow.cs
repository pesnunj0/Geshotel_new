
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("tipos_bloqueo"), DisplayName("Tipos Bloqueo"), InstanceName("Tipos Bloqueo"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.TiposBloqueo")]
    
    public sealed class TiposBloqueoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Bloqueo Id"), Column("tipo_bloqueo_id"), Identity,LookupInclude]
        public Int16? TipoBloqueoId
        {
            get { return Fields.TipoBloqueoId[this]; }
            set { Fields.TipoBloqueoId[this] = value; }
        }

        [DisplayName("Descriptivo"), Column("descriptivo"), Size(20), NotNull, QuickSearch]
        public String Descriptivo
        {
            get { return Fields.Descriptivo[this]; }
            set { Fields.Descriptivo[this] = value; }
        }

        [DisplayName("Editable"), Column("editable"), NotNull,LookupInclude]
        public Boolean? Editable
        {
            get { return Fields.Editable[this]; }
            set { Fields.Editable[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TipoBloqueoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Descriptivo; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposBloqueoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TipoBloqueoId;
            public StringField Descriptivo;
            public BooleanField Editable;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Portal.TiposBloqueo";
            }
        }
    }
}
