
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("[dbo].[contadores]"), DisplayName("Contadores"), InstanceName("Contadores"), TwoLevelCached]
    [ReadPermission("Contratos:Empresa")]
    [ModifyPermission("Contratos:Empresa")]
    public sealed class ContadoresRow : Row, IIdRow
    {
        [DisplayName("Contador Id"), Column("contador_id"), Identity]
        public Int32? ContadorId
        {
            get { return Fields.ContadorId[this]; }
            set { Fields.ContadorId[this] = value; }
        }

        [DisplayName("Empresa Id"), Column("empresa_id"), NotNull]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }
        }

        [DisplayName("Serie Id"), Column("serie_id"), NotNull]
        public Int16? SerieId
        {
            get { return Fields.SerieId[this]; }
            set { Fields.SerieId[this] = value; }
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

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.Contadores";
            }
        }
    }
}
