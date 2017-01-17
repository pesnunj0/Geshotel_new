
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Geshotel"), DisplayName("ambito_oferta"), InstanceName("ambito_oferta"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Contratos.AmbitoOferta")]
    public sealed class AmbitoOfertaRow : Row, IIdRow, INameRow
    {
        [DisplayName("Ambito Oferta Id"), Column("ambito_oferta_id"), PrimaryKey]
        public Int16? AmbitoOfertaId
        {
            get { return Fields.AmbitoOfertaId[this]; }
            set { Fields.AmbitoOfertaId[this] = value; }
        }

        [DisplayName("Ambito"), Column("ambito"), Size(15), NotNull, QuickSearch]
        public String Ambito
        {
            get { return Fields.Ambito[this]; }
            set { Fields.Ambito[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.AmbitoOfertaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Ambito; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AmbitoOfertaRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field AmbitoOfertaId;
            public StringField Ambito;

            public RowFields()
                : base("ambito_oferta")
            {
                LocalTextPrefix = "Contratos.AmbitoOferta";
            }
        }
    }
}
