
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("tipos_documento"), InstanceName("tipos_documento"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.TiposDocumento")]
    public sealed class TiposDocumentoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Documento Id"), Column("tipo_documento_id"), Size(1), PrimaryKey, QuickSearch]
        public String DocumentoId
        {
            get { return Fields.DocumentoId[this]; }
            set { Fields.DocumentoId[this] = value; }
        }

        [DisplayName("Documento"), Column("tipo_documento"), Size(15)]
        public String Documento
        {
            get { return Fields.Documento[this]; }
            set { Fields.Documento[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.DocumentoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Documento; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposDocumentoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField DocumentoId;
            public StringField Documento;

            public RowFields()
                : base("tipos_documento")
            {
                LocalTextPrefix = "Portal.TiposDocumento";
            }
        }
    }
}
