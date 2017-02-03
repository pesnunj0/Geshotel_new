
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Temporadas"), InstanceName("Temporadas"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    public sealed class TemporadasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Temporada Id"), Column("temporada_id"), PrimaryKey]
        public Int16? TemporadaId
        {
            get { return Fields.TemporadaId[this]; }
            set { Fields.TemporadaId[this] = value; }
        }

        [DisplayName("Temporada"), Column("temporada"), Size(25), NotNull, QuickSearch]
        public String Temporada
        {
            get { return Fields.Temporada[this]; }
            set { Fields.Temporada[this] = value; }
        }

        [DisplayName("Empresa"), Column("empresa_id"), PrimaryKey, ForeignKey("[dbo].[empresas]", "empresa_id"), LeftJoin("jEmpresa"), TextualField("Empresa")]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }
        }

        [DisplayName("Ano"), Column("ano")]
        public Int16? Ano
        {
            get { return Fields.Ano[this]; }
            set { Fields.Ano[this] = value; }
        }

        [DisplayName("Fecha Desde"), Column("fecha_desde"), NotNull]
        public DateTime? FechaDesde
        {
            get { return Fields.FechaDesde[this]; }
            set { Fields.FechaDesde[this] = value; }
        }

        [DisplayName("Fecha Hasta"), Column("fecha_hasta"), NotNull]
        public DateTime? FechaHasta
        {
            get { return Fields.FechaHasta[this]; }
            set { Fields.FechaHasta[this] = value; }
        }

        [DisplayName("Empresa"), Expression("jEmpresa.[empresa]")]
        public String Empresa
        {
            get { return Fields.Empresa[this]; }
            set { Fields.Empresa[this] = value; }
        }

        [DisplayName("Empresa Empresa Contable"), Expression("jEmpresa.[empresa_contable]")]
        public String EmpresaEmpresaContable
        {
            get { return Fields.EmpresaEmpresaContable[this]; }
            set { Fields.EmpresaEmpresaContable[this] = value; }
        }

        [DisplayName("Empresa Direccion"), Expression("jEmpresa.[direccion]")]
        public String EmpresaDireccion
        {
            get { return Fields.EmpresaDireccion[this]; }
            set { Fields.EmpresaDireccion[this] = value; }
        }

        [DisplayName("Empresa Poblacion"), Expression("jEmpresa.[poblacion]")]
        public String EmpresaPoblacion
        {
            get { return Fields.EmpresaPoblacion[this]; }
            set { Fields.EmpresaPoblacion[this] = value; }
        }

        [DisplayName("Empresa Zip"), Expression("jEmpresa.[zip]")]
        public String EmpresaZip
        {
            get { return Fields.EmpresaZip[this]; }
            set { Fields.EmpresaZip[this] = value; }
        }

        [DisplayName("Empresa Provincia Id"), Expression("jEmpresa.[provincia_id]")]
        public Int16? EmpresaProvinciaId
        {
            get { return Fields.EmpresaProvinciaId[this]; }
            set { Fields.EmpresaProvinciaId[this] = value; }
        }

        [DisplayName("Empresa Telefono"), Expression("jEmpresa.[telefono]")]
        public String EmpresaTelefono
        {
            get { return Fields.EmpresaTelefono[this]; }
            set { Fields.EmpresaTelefono[this] = value; }
        }

        [DisplayName("Empresa Fax"), Expression("jEmpresa.[fax]")]
        public String EmpresaFax
        {
            get { return Fields.EmpresaFax[this]; }
            set { Fields.EmpresaFax[this] = value; }
        }

        [DisplayName("Empresa Cif"), Expression("jEmpresa.[cif]")]
        public String EmpresaCif
        {
            get { return Fields.EmpresaCif[this]; }
            set { Fields.EmpresaCif[this] = value; }
        }

        [DisplayName("Empresa Ruta Ficheros"), Expression("jEmpresa.[ruta_ficheros]")]
        public String EmpresaRutaFicheros
        {
            get { return Fields.EmpresaRutaFicheros[this]; }
            set { Fields.EmpresaRutaFicheros[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TemporadaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Temporada; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TemporadasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field TemporadaId;
            public StringField Temporada;
            public Int16Field EmpresaId;
            public Int16Field Ano;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;

            public StringField Empresa;
            public StringField EmpresaEmpresaContable;
            public StringField EmpresaDireccion;
            public StringField EmpresaPoblacion;
            public StringField EmpresaZip;
            public Int16Field EmpresaProvinciaId;
            public StringField EmpresaTelefono;
            public StringField EmpresaFax;
            public StringField EmpresaCif;
            public StringField EmpresaRutaFicheros;

            public RowFields()
                : base("[dbo].[temporadas]")
            {
                LocalTextPrefix = "Contratos.Temporadas";
            }
        }
    }
}
