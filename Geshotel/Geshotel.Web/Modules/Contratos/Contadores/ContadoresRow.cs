
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    // Necesario para pillar las Rows de Portal en los Lookupeditor
    using Geshotel.Portal.Entities;
    using Geshotel.Behaviors;

    [ConnectionKey("Default"), TableName("[dbo].[contadores]"), DisplayName("Contadores"), InstanceName("Contadores"), TwoLevelCached]
    [ReadPermission("Contratos:Empresa")]
    [ModifyPermission("Contratos:Empresa")]
    public sealed class ContadoresRow : Row, IIdRow, ITenantRow
    {
        public Int16Field HotelIdField
        {
            get { return null; }
        }
        public Int16Field EmpresaIdField
        {
            get { return Fields.EmpresaId; }
        }
    
        [DisplayName("Contador Id"), Column("contador_id"), Identity]
        public Int32? ContadorId
        {
            get { return Fields.ContadorId[this]; }
            set { Fields.ContadorId[this] = value; }
        }

        [DisplayName("Empresa"), Column("empresa_id"), NotNull, ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresa"), TextualField("Empresa"), LookupInclude]
        [LookupEditor("Portal.Empresas")]
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

        [DisplayName("Serie Id"), Column("serie_id"), NotNull,ForeignKey("series","serie_id"),LeftJoin("jSeries"),TextualField("Serie"),LookupInclude]
        [LookupEditor("Contratos.Series")]
        public Int16? SerieId
        {
            get { return Fields.SerieId[this]; }
            set { Fields.SerieId[this] = value; }
        }
        public String Serie
        {
            get { return Fields.Serie[this]; }
            set { Fields.Serie[this] = value; }
        }


        [DisplayName("Ano"), Column("ano"), NotNull]
        public Int16? Ano
        {
            get { return Fields.Ano[this]; }
            set { Fields.Ano[this] = value; }
        }

        [DisplayName("Contador"), Column("contador"), NotNull]
        public Int32? Contador
        {
            get { return Fields.Contador[this]; }
            set { Fields.Contador[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ContadorId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ContadoresRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ContadorId;
            public Int16Field EmpresaId;
            public Int16Field SerieId;
            public Int16Field Ano;
            public Int32Field Contador;
            public StringField Empresa;
            public StringField Serie;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.Contadores";
            }
        }
    }
}
