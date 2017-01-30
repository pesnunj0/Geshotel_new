
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("tipos_huesped"), InstanceName("tipos_huesped"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.TiposHuesped")]
    public sealed class TiposHuespedRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Huesped Id"), Column("tipo_huesped_id"), Identity]
        public Int16? TipoHuespedId
        {
            get { return Fields.TipoHuespedId[this]; }
            set { Fields.TipoHuespedId[this] = value; }
        }

        [DisplayName("Descripcion"), Column("descripcion"), Size(30), NotNull, QuickSearch]
        public String Descripcion
        {
            get { return Fields.Descripcion[this]; }
            set { Fields.Descripcion[this] = value; }
        }

        [DisplayName("Desc Corta"), Column("Desc_corta"), Size(2), NotNull]
        public String DescCorta
        {
            get { return Fields.DescCorta[this]; }
            set { Fields.DescCorta[this] = value; }
        }

        [DisplayName("Unidad Calculo"), Column("uc_id"), ForeignKey("unidades_calculo", "unidad_calculo_id"), LeftJoin("jUc"), TextualField("descripcion_unidad_calculo")]
        [LookupEditor(typeof(UnidadesCalculoRow))]
        public Int16? UcId
        {
            get { return Fields.UcId[this]; }
            set { Fields.UcId[this] = value; }
        }


        [DisplayName("Unidad Calculo"), Expression("jUc.[descripcion_unidad_calculo]")]
        public String UcDescripcionUnidadCalculo
        {
            get { return Fields.UcDescripcionUnidadCalculo[this]; }
            set { Fields.UcDescripcionUnidadCalculo[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.TipoHuespedId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Descripcion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposHuespedRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TipoHuespedId;
            public StringField Descripcion;
            public StringField DescCorta;
            public Int16Field UcId;

            public StringField UcDescripcionUnidadCalculo;

            public RowFields()
                : base("tipos_huesped")
            {
                LocalTextPrefix = "Portal.TiposHuesped";
            }
        }
    }
}
