
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Portal"), DisplayName("comunidades_autonomas"), InstanceName("comunidades_autonomas"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.ComunidadesAutonomas")]
    public sealed class ComunidadesAutonomasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Comunidad Id"), Column("comunidad_id"), Identity]
        public Int16? ComunidadId
        {
            get { return Fields.ComunidadId[this]; }
            set { Fields.ComunidadId[this] = value; }
        }

        [DisplayName("Comunidad Autonoma"), Column("comunidad_autonoma"), Size(50), QuickSearch]
        public String ComunidadAutonoma
        {
            get { return Fields.ComunidadAutonoma[this]; }
            set { Fields.ComunidadAutonoma[this] = value; }
        }

        [DisplayName("Nacion"), Column("nacion_id"), ForeignKey("naciones", "nacion_id"), LeftJoin("jNacion"), TextualField("Nacion")]
        [LookupEditor(typeof(NacionesRow))]
        public Int16? NacionId
        {
            get { return Fields.NacionId[this]; }
            set { Fields.NacionId[this] = value; }
        }

        [DisplayName("Comunidad Autonoma Ista"), Column("comunidad_autonoma_ista"), Size(5)]
        public String ComunidadAutonomaIsta
        {
            get { return Fields.ComunidadAutonomaIsta[this]; }
            set { Fields.ComunidadAutonomaIsta[this] = value; }
        }

        [DisplayName("Nacion"), Expression("jNacion.[nacion]")]
        public String Nacion
        {
            get { return Fields.Nacion[this]; }
            set { Fields.Nacion[this] = value; }
        }

        [DisplayName("Nacion Desc Corta"), Expression("jNacion.[desc_corta]")]
        public String NacionDescCorta
        {
            get { return Fields.NacionDescCorta[this]; }
            set { Fields.NacionDescCorta[this] = value; }
        }

        [DisplayName("Nacion Moneda Id"), Expression("jNacion.[moneda_id]")]
        public Int16? NacionMonedaId
        {
            get { return Fields.NacionMonedaId[this]; }
            set { Fields.NacionMonedaId[this] = value; }
        }

        [DisplayName("Nacion Idioma Id"), Expression("jNacion.[idioma_id]")]
        public Int32? NacionIdiomaId
        {
            get { return Fields.NacionIdiomaId[this]; }
            set { Fields.NacionIdiomaId[this] = value; }
        }

        [DisplayName("Nacion Numero Ine"), Expression("jNacion.[numero_ine]")]
        public Int16? NacionNumeroIne
        {
            get { return Fields.NacionNumeroIne[this]; }
            set { Fields.NacionNumeroIne[this] = value; }
        }

        [DisplayName("Nacion Pais Ista"), Expression("jNacion.[pais_ista]")]
        public String NacionPaisIsta
        {
            get { return Fields.NacionPaisIsta[this]; }
            set { Fields.NacionPaisIsta[this] = value; }
        }

        [DisplayName("Nacion Defecto"), Expression("jNacion.[defecto]")]
        public Int16? NacionDefecto
        {
            get { return Fields.NacionDefecto[this]; }
            set { Fields.NacionDefecto[this] = value; }
        }

        [DisplayName("Nacion Nombre Real"), Expression("jNacion.[nombre_real]")]
        public String NacionNombreReal
        {
            get { return Fields.NacionNombreReal[this]; }
            set { Fields.NacionNombreReal[this] = value; }
        }

        [DisplayName("Nacion Idioma Mails"), Expression("jNacion.[idioma_mails]")]
        public String NacionIdiomaMails
        {
            get { return Fields.NacionIdiomaMails[this]; }
            set { Fields.NacionIdiomaMails[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ComunidadId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.ComunidadAutonoma; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ComunidadesAutonomasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field ComunidadId;
            public Int16Field NacionId;
            public StringField ComunidadAutonoma;
            public StringField ComunidadAutonomaIsta;

            public StringField Nacion;
            public StringField NacionDescCorta;
            public Int16Field NacionMonedaId;
            public Int32Field NacionIdiomaId;
            public Int16Field NacionNumeroIne;
            public StringField NacionPaisIsta;
            public Int16Field NacionDefecto;
            public StringField NacionNombreReal;
            public StringField NacionIdiomaMails;

            public RowFields()
                : base("comunidades_autonomas")
            {
                LocalTextPrefix = "Portal.ComunidadesAutonomas";
            }
        }
    }
}
