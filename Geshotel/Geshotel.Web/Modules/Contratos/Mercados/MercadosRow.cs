
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Geshotel.Portal.Entities;

    [ConnectionKey("Default"), DisplayName("Mercados"), InstanceName("Mercados"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    [LookupScript("Contratos.Mercados")]
    public sealed class MercadosRow : Row, IIdRow, INameRow
    {
        [DisplayName("Mercado Id"), Column("mercado_id"), PrimaryKey]
        public Int16? MercadoId
        {
            get { return Fields.MercadoId[this]; }
            set { Fields.MercadoId[this] = value; }
        }

        [DisplayName("Mercado"), Column("mercado"), Size(25), NotNull, QuickSearch]
        public String Mercado
        {
            get { return Fields.Mercado[this]; }
            set { Fields.Mercado[this] = value; }
        }

        [DisplayName("Empresa"), Column("empresa_id"), PrimaryKey, ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresa"), TextualField("Empresa")]
        [LookupEditor(typeof(EmpresasRow))]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }
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
            get { return Fields.MercadoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Mercado; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MercadosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field MercadoId;
            public StringField Mercado;
            public Int16Field EmpresaId;

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
                : base("[dbo].[mercados]")
            {
                LocalTextPrefix = "Contratos.Mercados";
            }
        }
    }
}
