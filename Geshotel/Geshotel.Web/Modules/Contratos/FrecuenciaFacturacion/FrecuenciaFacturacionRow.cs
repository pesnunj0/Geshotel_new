
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Frecuencia Facturacion"), InstanceName("Frecuencia Facturacion"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class FrecuenciaFacturacionRow : Row, IIdRow, INameRow
    {
        [DisplayName("Frecuencia Id"), Column("frecuencia_id"), Identity]
        public Int16? FrecuenciaId
        {
            get { return Fields.FrecuenciaId[this]; }
            set { Fields.FrecuenciaId[this] = value; }
        }

        [DisplayName("Descripcion Corta"), Column("descripcion_corta"), Size(3), NotNull, QuickSearch]
        public String DescripcionCorta
        {
            get { return Fields.DescripcionCorta[this]; }
            set { Fields.DescripcionCorta[this] = value; }
        }

        [DisplayName("Descripcion"), Column("descripcion"), Size(30), NotNull]
        public String Descripcion
        {
            get { return Fields.Descripcion[this]; }
            set { Fields.Descripcion[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.FrecuenciaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.DescripcionCorta; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public FrecuenciaFacturacionRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field FrecuenciaId;
            public StringField DescripcionCorta;
            public StringField Descripcion;

            public RowFields()
                : base("frecuencia_facturacion")
            {
                LocalTextPrefix = "Contratos.FrecuenciaFacturacion";
            }
        }
    }
}
