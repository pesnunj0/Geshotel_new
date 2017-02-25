
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("canales_reserva"), DisplayName("Canales Reserva"), InstanceName("Canales Reserva"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Contratos:Empresa")]
    [LookupScript("Contratos.CanalesReserva")]
    public sealed class CanalesReservaRow : Row, IIdRow, INameRow
    {
        [DisplayName("Canal Reserva Id"), Column("canal_reserva_id"), Identity]
        public Int16? CanalReservaId
        {
            get { return Fields.CanalReservaId[this]; }
            set { Fields.CanalReservaId[this] = value; }
        }

        [DisplayName("Empresa"), Column("empresa_id"), NotNull, ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresa"), TextualField("Empresa")]
        [LookupEditor("Portal.Empresas")]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }
        }

        [DisplayName("Nombre Canal"), Column("nombre_canal"), Size(40), NotNull, QuickSearch]
        public String NombreCanal
        {
            get { return Fields.NombreCanal[this]; }
            set { Fields.NombreCanal[this] = value; }
        }

        [DisplayName("Empresa"), Expression("jEmpresa.[empresa]")]
        public String Empresa
        {
            get { return Fields.Empresa[this]; }
            set { Fields.Empresa[this] = value; }
        }

 
        IIdField IIdRow.IdField
        {
            get { return Fields.CanalReservaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NombreCanal; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CanalesReservaRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field CanalReservaId;
            public Int16Field EmpresaId;
            public StringField NombreCanal;

            public StringField Empresa;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Contratos.CanalesReserva";
            }
        }
    }
}
