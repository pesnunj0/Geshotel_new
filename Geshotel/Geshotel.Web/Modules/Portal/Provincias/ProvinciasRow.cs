
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("provincias"), InstanceName("provincias"), TwoLevelCached]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript("Portal.Provincias")]
    public sealed class ProvinciasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Provincia Id"), Column("provincia_id"), Identity]
        public Int16? ProvinciaId
        {
            get { return Fields.ProvinciaId[this]; }
            set { Fields.ProvinciaId[this] = value; }
        }

        [DisplayName("Provincia"), Column("provincia"), Size(30), NotNull, QuickSearch]
        public String Provincia
        {
            get { return Fields.Provincia[this]; }
            set { Fields.Provincia[this] = value; }
        }

        [DisplayName("Comunidad Autonoma"), Column("comunidad_autonoma_id"), ForeignKey("comunidades_autonomas", "comunidad_id"), LeftJoin("jComunidadAutonoma"), TextualField("ComunidadAutonoma")]
        [LookupEditor(typeof(ComunidadesAutonomasRow), InplaceAdd = true)]
        public Int16? ComunidadAutonomaId
        {
            get { return Fields.ComunidadAutonomaId[this]; }
            set { Fields.ComunidadAutonomaId[this] = value; }
        }

        [DisplayName("Nacion"), Column("nacion_id"), NotNull, ForeignKey("naciones", "nacion_id"), LeftJoin("jNacion"), TextualField("Nacion")]
        [LookupEditor(typeof(NacionesRow), InplaceAdd = true)]
        public Int16? NacionId
        {
            get { return Fields.NacionId[this]; }
            set { Fields.NacionId[this] = value; }
        }

        [DisplayName("Provincia Ista"), Column("provincia_ista"), Size(6)]
        public String ProvinciaIsta
        {
            get { return Fields.ProvinciaIsta[this]; }
            set { Fields.ProvinciaIsta[this] = value; }
        }

        [DisplayName("Defecto Ista"), Column("defecto_ista")]
        public Int16? DefectoIsta
        {
            get { return Fields.DefectoIsta[this]; }
            set { Fields.DefectoIsta[this] = value; }
        }

        [DisplayName("Comunidad Autonoma Nacion Id"), Expression("jComunidadAutonoma.[nacion_id]")]
        public Int16? ComunidadAutonomaNacionId
        {
            get { return Fields.ComunidadAutonomaNacionId[this]; }
            set { Fields.ComunidadAutonomaNacionId[this] = value; }
        }

        [DisplayName("Comunidad Autonoma Comunidad Autonoma"), Expression("jComunidadAutonoma.[comunidad_autonoma]")]
        public String ComunidadAutonoma
        {
            get { return Fields.ComunidadAutonoma[this]; }
            set { Fields.ComunidadAutonoma[this] = value; }
        }

        [DisplayName("Comunidad Autonoma Comunidad Autonoma Ista"), Expression("jComunidadAutonoma.[comunidad_autonoma_ista]")]
        public String ComunidadAutonomaComunidadAutonomaIsta
        {
            get { return Fields.ComunidadAutonomaComunidadAutonomaIsta[this]; }
            set { Fields.ComunidadAutonomaComunidadAutonomaIsta[this] = value; }
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
            get { return Fields.ProvinciaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Provincia; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ProvinciasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field ProvinciaId;
            public StringField Provincia;
            public Int16Field ComunidadAutonomaId;
            public Int16Field NacionId;
            public StringField ProvinciaIsta;
            public Int16Field DefectoIsta;

            public Int16Field ComunidadAutonomaNacionId;
            public StringField ComunidadAutonoma;
            public StringField ComunidadAutonomaComunidadAutonomaIsta;

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
                : base("provincias")
            {
                LocalTextPrefix = "Portal.Provincias";
            }
        }
    }
}
