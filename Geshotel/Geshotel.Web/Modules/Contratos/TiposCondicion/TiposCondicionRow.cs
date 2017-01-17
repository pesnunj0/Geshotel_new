
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Geshotel"), DisplayName("Tipos Condicion"), InstanceName("Tipos Condicion"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Contratos.TiposCondicion")]
    public sealed class TiposCondicionRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Condicion Id"), Column("tipo_condicion_id"), Identity]
        public Int16? TipoCondicionId
        {
            get { return Fields.TipoCondicionId[this]; }
            set { Fields.TipoCondicionId[this] = value; }
        }

        [DisplayName("Condicion"), Column("condicion"), Size(2), NotNull, QuickSearch]
        public String Condicion
        {
            get { return Fields.Condicion[this]; }
            set { Fields.Condicion[this] = value; }
        }

        [DisplayName("Literal"), Column("literal"), Size(15)]
        public String Literal
        {
            get { return Fields.Literal[this]; }
            set { Fields.Literal[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TipoCondicionId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Condicion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposCondicionRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TipoCondicionId;
            public StringField Condicion;
            public StringField Literal;

            public RowFields()
                : base("tipos_condicion")
            {
                LocalTextPrefix = "Contratos.TiposCondicion";
            }
        }
    }
}
