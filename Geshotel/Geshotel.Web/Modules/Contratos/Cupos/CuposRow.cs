
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

    [ConnectionKey("Default"), DisplayName("Cupos"), InstanceName("Cupos"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    [LookupScript("Contratos.Cupos")]
    public sealed class CuposRow : Row, IIdRow
    {
        [DisplayName("Cupo Id"), Column("cupo_id"), Identity]
        public Int32? CupoId
        {
            get { return Fields.CupoId[this]; }
            set { Fields.CupoId[this] = value; }
        }

        [DisplayName("Cliente"), Column("cliente_id"), NotNull, ForeignKey("clientes", "cliente_id"), LeftJoin("jCliente"), TextualField("ClienteRazon")]
        [LookupEditor(typeof(ClientesRow), FilterField = "GrupoClienteId", FilterValue = 2)]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), NotNull, ForeignKey("hoteles", "hotel_id"), LeftJoin("jHotel"), TextualField("Hotel")]
        [LookupEditor(typeof(HotelesRow))]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
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

        [DisplayName("Tipo Habitacion"), Column("tipo_habitacion_id"), NotNull, ForeignKey("tipos_habitacion", "tipo_habitacion_id"), LeftJoin("jTipoHabitacion"), TextualField("TipoHabitacionDescCorta")]
        [LookupEditor(typeof(TiposHabitacionRow))]
        public Int16? TipoHabitacionId
        {
            get { return Fields.TipoHabitacionId[this]; }
            set { Fields.TipoHabitacionId[this] = value; }
        }

        [DisplayName("Tipo Habitacion"), Expression("jTipoHabitacion.[desc_corta]")]
        public String TipoHabitacionDescCorta
        {
            get { return Fields.TipoHabitacionDescCorta[this]; }
            set { Fields.TipoHabitacionDescCorta[this] = value; }
        }

        [DisplayName("Tipo Habitacion"), Expression("jTipoHabitacion.[descripcion]")]
        public String TipoHabitacionDescripcion
        {
            get { return Fields.TipoHabitacionDescripcion[this]; }
            set { Fields.TipoHabitacionDescripcion[this] = value; }
        }

        [DisplayName("Garantia"), Column("garantia"), Size(5), Scale(2), NotNull]
        public Decimal? Garantia
        {
            get { return Fields.Garantia[this]; }
            set { Fields.Garantia[this] = value; }
        }
        [DisplayName("Cupo"),Column("cupo"),NotNull]
        public Int16? Cupo
        {
            get { return Fields.Cupo[this]; }
            set { Fields.Cupo[this] = value; }
        }

        [DisplayName("Reserva Automatica"), Column("reserva_automatica"), NotNull]
        public Boolean? ReservaAutomatica
        {
            get { return Fields.ReservaAutomatica[this]; }
            set { Fields.ReservaAutomatica[this] = value; }
        }

        [DisplayName("Usuario"), Column("user_id"), ForeignKey("users", "UserId"), LeftJoin("jUsers")]
        [LookupEditor(typeof(Geshotel.Administration.Entities.UserRow))]
        public Int32? UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }
        [DisplayName("Usuario"), Expression("jUsers.Username")]
        public String UserName
        {
            get { return Fields.UserName[this]; }
            set { Fields.UserName[this] = value; }
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

        [DisplayName("Cliente Desc Corta"), Expression("jCliente.[desc_corta]")]
        public String ClienteDescCorta
        {
            get { return Fields.ClienteDescCorta[this]; }
            set { Fields.ClienteDescCorta[this] = value; }
        }
 

        [DisplayName("Hotel"), Expression("jHotel.[hotel]")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }

        [DisplayName("Hotel Empresa Id"), Expression("jHotel.[empresa_id]"),ForeignKey("empresas","empresa_id"),LeftJoin("jEmpresa")]
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


        IIdField IIdRow.IdField
        {
            get { return Fields.CupoId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CuposRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field CupoId;
            public Int32Field ClienteId;
            public Int16Field HotelId;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;
            public Int16Field TipoHabitacionId;
            public DecimalField Garantia;
            public BooleanField ReservaAutomatica;
            public Int16Field Cupo;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public StringField ClienteRazon;
            public StringField ClienteDescCorta;

            public StringField HotelName;
            public Int16Field EmpresaId;
            public StringField Empresa;
 
            public StringField TipoHabitacionDescCorta;
            public StringField TipoHabitacionDescripcion;

            public StringField UserName;

            public RowFields()
                : base("[cupos]")
            {
                LocalTextPrefix = "Contratos.Cupos";
            }
        }
    }
}
