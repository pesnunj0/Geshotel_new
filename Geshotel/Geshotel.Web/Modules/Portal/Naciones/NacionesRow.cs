
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Geshotel.Administration.Entities;

    [ConnectionKey("CommonFiles"), DisplayName("naciones"), InstanceName("naciones"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.Naciones")]
    public sealed class NacionesRow : Row, IIdRow, INameRow
    {
        [DisplayName("Nacion Id"), Column("nacion_id"), Identity]
        public Int16? NacionId
        {
            get { return Fields.NacionId[this]; }
            set { Fields.NacionId[this] = value; }
        }

        [DisplayName("Nacion"), Column("nacion"), Size(30), QuickSearch]
        public String Nacion
        {
            get { return Fields.Nacion[this]; }
            set { Fields.Nacion[this] = value; }
        }

        [DisplayName("Desc Corta"), Column("desc_corta"), Size(6)]
        public String DescCorta
        {
            get { return Fields.DescCorta[this]; }
            set { Fields.DescCorta[this] = value; }
        }

        [DisplayName("Moneda"), Column("moneda_id"), NotNull, ForeignKey("monedas", "moneda_id"), LeftJoin("jMoneda"), TextualField("MonedaDescripcion")]
        [LookupEditor(typeof(MonedasRow))]
        public Int16? MonedaId
        {
            get { return Fields.MonedaId[this]; }
            set { Fields.MonedaId[this] = value; }
        }

        [DisplayName("Idioma"), Column("idioma_id"), ForeignKey("[geshotel_default_v1].languages", "Id"), LeftJoin("jIdioma"), TextualField("IdiomaLanguageName")]
        [LookupEditor(typeof(LanguageRow))]
        public Int32? IdiomaId
        {
            get { return Fields.IdiomaId[this]; }
            set { Fields.IdiomaId[this] = value; }
        }

        [DisplayName("Numero Ine"), Column("numero_ine")]
        public Int16? NumeroIne
        {
            get { return Fields.NumeroIne[this]; }
            set { Fields.NumeroIne[this] = value; }
        }

        [DisplayName("Pais Ista"), Column("pais_ista"), Size(3)]
        public String PaisIsta
        {
            get { return Fields.PaisIsta[this]; }
            set { Fields.PaisIsta[this] = value; }
        }

        [DisplayName("Defecto"), Column("defecto")]
        public Int16? Defecto
        {
            get { return Fields.Defecto[this]; }
            set { Fields.Defecto[this] = value; }
        }

        [DisplayName("Nombre Real"), Column("nombre_real"), Size(65535)]
        public String NombreReal
        {
            get { return Fields.NombreReal[this]; }
            set { Fields.NombreReal[this] = value; }
        }

        [DisplayName("Idioma Mails"), Column("idioma_mails"), Size(3)]
        public String IdiomaMails
        {
            get { return Fields.IdiomaMails[this]; }
            set { Fields.IdiomaMails[this] = value; }
        }

        [DisplayName("Moneda"), Expression("jMoneda.[descripcion]")]
        public String MonedaDescripcion
        {
            get { return Fields.MonedaDescripcion[this]; }
            set { Fields.MonedaDescripcion[this] = value; }
        }

        [DisplayName("Moneda Desc Corta"), Expression("jMoneda.[desc_corta]")]
        public String MonedaDescCorta
        {
            get { return Fields.MonedaDescCorta[this]; }
            set { Fields.MonedaDescCorta[this] = value; }
        }

        [DisplayName("Moneda Cambio"), Expression("jMoneda.[cambio]")]
        public Double? MonedaCambio
        {
            get { return Fields.MonedaCambio[this]; }
            set { Fields.MonedaCambio[this] = value; }
        }

        [DisplayName("Idioma Language Id"), Expression("jIdioma.[LanguageId]")]
        public String IdiomaLanguageId
        {
            get { return Fields.IdiomaLanguageId[this]; }
            set { Fields.IdiomaLanguageId[this] = value; }
        }

        [DisplayName("Idioma Language Name"), Expression("jIdioma.[LanguageName]")]
        public String IdiomaLanguageName
        {
            get { return Fields.IdiomaLanguageName[this]; }
            set { Fields.IdiomaLanguageName[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.NacionId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Nacion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public NacionesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field NacionId;
            public StringField Nacion;
            public StringField DescCorta;
            public Int16Field MonedaId;
            public Int32Field IdiomaId;
            public Int16Field NumeroIne;
            public StringField PaisIsta;
            public Int16Field Defecto;
            public StringField NombreReal;
            public StringField IdiomaMails;

            public StringField MonedaDescripcion;
            public StringField MonedaDescCorta;
            public DoubleField MonedaCambio;

            public StringField IdiomaLanguageId;
            public StringField IdiomaLanguageName;

            public RowFields()
                : base("naciones")
            {
                LocalTextPrefix = "Portal.Naciones";
            }
        }
    }
}
