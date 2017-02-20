
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("empresas"), InstanceName("empresas"), TwoLevelCached]
    [ReadPermission("Administration:Empresa")]
    [ModifyPermission("Administration:Empresa")]
    
    public sealed class EmpresasRow : Row, IIdRow, INameRow, ITenantRow
    {
        [DisplayName("Empresa Id"), Column("empresa_id"), Identity]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }
        }

        [DisplayName("Empresa"), Column("empresa"), Size(40), NotNull, QuickSearch]
        public String Empresa
        {
            get { return Fields.Empresa[this]; }
            set { Fields.Empresa[this] = value; }
        }

        [DisplayName("Empresa Contable"), Column("empresa_contable"), Size(5)]
        public String EmpresaContable
        {
            get { return Fields.EmpresaContable[this]; }
            set { Fields.EmpresaContable[this] = value; }
        }

        [DisplayName("Direccion"), Column("direccion"), Size(50)]
        public String Direccion
        {
            get { return Fields.Direccion[this]; }
            set { Fields.Direccion[this] = value; }
        }

        [DisplayName("Poblacion"), Column("poblacion"), Size(50)]
        public String Poblacion
        {
            get { return Fields.Poblacion[this]; }
            set { Fields.Poblacion[this] = value; }
        }

        [DisplayName("Zip"), Column("zip"), Size(5)]
        public String Zip
        {
            get { return Fields.Zip[this]; }
            set { Fields.Zip[this] = value; }
        }

        [DisplayName("Provincia"), Column("provincia_id"), ForeignKey("provincias", "provincia_id"), LeftJoin("jProvincia"), TextualField("Provincia")]
        [LookupEditor(typeof(ProvinciasRow), InplaceAdd = true)]
        public Int16? ProvinciaId
        {
            get { return Fields.ProvinciaId[this]; }
            set { Fields.ProvinciaId[this] = value; }
        }

        [DisplayName("Telefono"), Column("telefono"), Size(20)]
        public String Telefono
        {
            get { return Fields.Telefono[this]; }
            set { Fields.Telefono[this] = value; }
        }

        [DisplayName("Fax"), Column("fax"), Size(20)]
        public String Fax
        {
            get { return Fields.Fax[this]; }
            set { Fields.Fax[this] = value; }
        }

        [DisplayName("Cif"), Column("cif"), Size(20)]
        public String Cif
        {
            get { return Fields.Cif[this]; }
            set { Fields.Cif[this] = value; }
        }

        [DisplayName("Ruta Ficheros"), Column("ruta_ficheros"), Size(65535)]
        public String RutaFicheros
        {
            get { return Fields.RutaFicheros[this]; }
            set { Fields.RutaFicheros[this] = value; }
        }

        [DisplayName("Provincia"), Expression("jProvincia.[provincia]")]
        public String Provincia
        {
            get { return Fields.Provincia[this]; }
            set { Fields.Provincia[this] = value; }
        }

        [DisplayName("Provincia Comunidad Autonoma Id"), Expression("jProvincia.[comunidad_autonoma_id]")]
        public Int16? ProvinciaComunidadAutonomaId
        {
            get { return Fields.ProvinciaComunidadAutonomaId[this]; }
            set { Fields.ProvinciaComunidadAutonomaId[this] = value; }
        }

        [DisplayName("Provincia Nacion Id"), Expression("jProvincia.[nacion_id]")]
        public Int16? ProvinciaNacionId
        {
            get { return Fields.ProvinciaNacionId[this]; }
            set { Fields.ProvinciaNacionId[this] = value; }
        }

        [DisplayName("Provincia Provincia Ista"), Expression("jProvincia.[provincia_ista]")]
        public String ProvinciaProvinciaIsta
        {
            get { return Fields.ProvinciaProvinciaIsta[this]; }
            set { Fields.ProvinciaProvinciaIsta[this] = value; }
        }

        [DisplayName("Provincia Defecto Ista"), Expression("jProvincia.[defecto_ista]")]
        public Int16? ProvinciaDefectoIsta
        {
            get { return Fields.ProvinciaDefectoIsta[this]; }
            set { Fields.ProvinciaDefectoIsta[this] = value; }
        }

        public Int16Field EmpresaIdField
        {
            get { return Fields.EmpresaId; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.EmpresaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Empresa; }
        }

        public Int16Field HotelIdField
        {
            get { return null; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public EmpresasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field EmpresaId;
            public StringField Empresa;
            public StringField EmpresaContable;
            public StringField Direccion;
            public StringField Poblacion;
            public StringField Zip;
            public Int16Field ProvinciaId;
            public StringField Telefono;
            public StringField Fax;
            public StringField Cif;
            public StringField RutaFicheros;

            public StringField Provincia;
            public Int16Field ProvinciaComunidadAutonomaId;
            public Int16Field ProvinciaNacionId;
            public StringField ProvinciaProvinciaIsta;
            public Int16Field ProvinciaDefectoIsta;

            public RowFields()
                : base("empresas")
            {
                LocalTextPrefix = "Portal.Empresas";
            }
        }
    }
}
