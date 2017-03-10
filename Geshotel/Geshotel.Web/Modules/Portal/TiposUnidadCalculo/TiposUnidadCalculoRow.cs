
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("tipos_unidad_calculo"), InstanceName("tipos_unidad_calculo"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.TiposUnidadCalculo")]
    public sealed class TiposUnidadCalculoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Unidad Calculo Id"), Column("tipo_unidad_calculo_id"), Identity]
        public Int16? UnidadCalculoId
        {
            get { return Fields.UnidadCalculoId[this]; }
            set { Fields.UnidadCalculoId[this] = value; }
        }

        [DisplayName("Uc"), Column("tipo_uc"), Size(15), NotNull, QuickSearch]
        public String Uc
        {
            get { return Fields.Uc[this]; }
            set { Fields.Uc[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.UnidadCalculoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Uc; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposUnidadCalculoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field UnidadCalculoId;
            public StringField Uc;

            public RowFields()
                : base("tipos_unidad_calculo", "tipo_")
            {
                LocalTextPrefix = "Portal.TiposUnidadCalculo";
            }
        }
    }
}
