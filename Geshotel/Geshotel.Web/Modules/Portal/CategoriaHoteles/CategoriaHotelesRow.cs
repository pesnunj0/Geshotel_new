
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CommonFiles"), DisplayName("categoria_hoteles"), InstanceName("categoria_hoteles"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.CategoriaHoteles")]
    public sealed class CategoriaHotelesRow : Row, IIdRow, INameRow
    {
        [DisplayName("Categoria Id"), Column("categoria_id"), Identity]
        public Int16? CategoriaId
        {
            get { return Fields.CategoriaId[this]; }
            set { Fields.CategoriaId[this] = value; }
        }

        [DisplayName("Abreviatura"), Column("abreviatura"), Size(6), NotNull, QuickSearch]
        public String Abreviatura
        {
            get { return Fields.Abreviatura[this]; }
            set { Fields.Abreviatura[this] = value; }
        }

        [DisplayName("Categoria"), Column("categoria"), Size(20), NotNull]
        public String Categoria
        {
            get { return Fields.Categoria[this]; }
            set { Fields.Categoria[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.CategoriaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Categoria; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CategoriaHotelesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field CategoriaId;
            public StringField Abreviatura;
            public StringField Categoria;

            public RowFields()
                : base("categoria_hoteles")
            {
                LocalTextPrefix = "Portal.CategoriaHoteles";
            }
        }
    }
}
