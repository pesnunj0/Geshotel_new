
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Portal.Entities;

    [ConnectionKey("Default"), DisplayName("Releases"), InstanceName("Releases"), TwoLevelCached]
    [ReadPermission("Todos:General")]
    [ModifyPermission("Contratos:Empresa")]
    public sealed class ReleasesRow : Row, IIdRow, INameRow
    {
        [DisplayName("Release Id"), Column("release_id"), Identity]
        public Int32? ReleaseId
        {
            get { return Fields.ReleaseId[this]; }
            set { Fields.ReleaseId[this] = value; }
        }

        [DisplayName("Cliente"), Column("cliente_id"), NotNull, ForeignKey("clientes", "cliente_id"), LeftJoin("jCliente"), TextualField("ClienteRazon")]
        [LookupEditor(("Contratos.Clientes"), FilterField = "GrupoClienteId", FilterValue = 2)]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), NotNull, ForeignKey("hoteles", "hotel_id"), LeftJoin("jHotel"), TextualField("Hotel")]
        [LookupEditor("Portal.Hoteles")]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Empresa"), Expression("jHotel.[empresa_id]"), ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresas")]
        [LookupEditor("Portal.Empresas")]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }

        }

        [DisplayName("Empresa"), Expression("jEmpresas.empresa")]

        public String Empresa
        {
            get { return Fields.Empresa[this]; }
            set { Fields.Empresa[this] = value; }

        }
        //*******


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

        [DisplayName("Observaciones"), Column("observaciones"), Size(100), QuickSearch]
        public String Observaciones
        {
            get { return Fields.Observaciones[this]; }
            set { Fields.Observaciones[this] = value; }
        }

        [DisplayName("Dias"), Column("dias")]
        public Int16? Dias
        {
            get { return Fields.Dias[this]; }
            set { Fields.Dias[this] = value; }
        }

        [DisplayName("User Id"), Column("user_id"), ForeignKey("Users", "UserID"), LeftJoin("jUsers")]
        [LookupEditor(typeof(Geshotel.Administration.Entities.UserRow))]
        public Int32? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }

        [DisplayName("Fecha Modificacion"), Column("fecha_modificacion")]
        public DateTime? FechaModificacion
        {
            get { return Fields.FechaModificacion[this]; }
            set { Fields.FechaModificacion[this] = value; }
        }

        [DisplayName("Cliente Razon"), Expression("jCliente.[razon]")]
        public String ClienteRazon
        {
            get { return Fields.ClienteRazon[this]; }
            set { Fields.ClienteRazon[this] = value; }
        }


        [DisplayName("Hotel"), Expression("jHotel.[hotel]")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }

        [DisplayName("Usuario"), Expression("jUsers.Username")]
        public String UserName
        {
            get { return Fields.UserName[this]; }
            set { Fields.UserName[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ReleaseId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Observaciones; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ReleasesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ReleaseId;
            public Int32Field ClienteId;
            public Int16Field HotelId;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;
            public StringField Observaciones;
            public Int16Field Dias;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public StringField ClienteRazon;

            public StringField HotelName;
            public Int16Field EmpresaId;
            public StringField Empresa;
            public StringField UserName;

            public RowFields()
                : base("[releases]")
            {
                LocalTextPrefix = "Contratos.Releases";
            }
        }
    }
}
