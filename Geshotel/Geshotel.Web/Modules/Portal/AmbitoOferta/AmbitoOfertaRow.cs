
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("ambito_oferta"), DisplayName("Ambito Oferta"), InstanceName("Ambito Oferta"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.AmbitoOferta")]
    public sealed class AmbitoOfertaRow : Row, IIdRow, INameRow
    {
        [DisplayName("Ambito Oferta Id"), Column("ambito_oferta_id"), PrimaryKey]
        public Int16? AmbitoOfertaId
        {
            get { return Fields.AmbitoOfertaId[this]; }
            set { Fields.AmbitoOfertaId[this] = value; }
        }

        [DisplayName("Nombre"), Column("nombre"), Size(15), NotNull, QuickSearch]
        public String Nombre
        {
            get { return Fields.Nombre[this]; }
            set { Fields.Nombre[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.AmbitoOfertaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Nombre; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AmbitoOfertaRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field AmbitoOfertaId;
            public StringField Nombre;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Portal.AmbitoOferta";
            }
        }
    }
}
