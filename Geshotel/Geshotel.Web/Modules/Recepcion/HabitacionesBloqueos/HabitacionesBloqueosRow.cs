
namespace Geshotel.Recepcion.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("[habitaciones_bloqueos]"), DisplayName("Habitaciones Bloqueos"), InstanceName("Habitaciones Bloqueos"), TwoLevelCached]
    [ReadPermission("Recepcion:Hotel")]
    [ModifyPermission("Recepcion:Hotel")]
    public sealed class HabitacionesBloqueosRow : Row, IIdRow, INameRow
    {
        [DisplayName("Habitacion Bloqueo Id"), Column("habitacion_bloqueo_id"), Identity]
        public Int32? HabitacionBloqueoId
        {
            get { return Fields.HabitacionBloqueoId[this]; }
            set { Fields.HabitacionBloqueoId[this] = value; }
        }

        [DisplayName("Habitacion"), Column("habitacion_id"), NotNull, ForeignKey("[habitaciones]", "habitacion_id"), LeftJoin("jHabitacion"), TextualField("HabitacionNumeroHabitacion")]
        [LookupEditor("Contratos.Habitaciones")]
        public Int16? HabitacionId
        {
            get { return Fields.HabitacionId[this]; }
            set { Fields.HabitacionId[this] = value; }
        }
        [DisplayName("Hotel"),Expression("jHabitacion.hotel_id"), ForeignKey("hoteles", "hotel_id"), LeftJoin("jHoteles")]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Empresa"), Expression("jHoteles.[empresa_id]"), ForeignKey("empresas", "empresa_id"), LeftJoin("jEmpresas")]
        [LookupEditor("Portal.Empresas")]
        public Int16? EmpresaId
        {
            get { return Fields.EmpresaId[this]; }
            set { Fields.EmpresaId[this] = value; }

        }
        [DisplayName("Tipo Bloqueo Id"), Column("tipo_bloqueo_id"), ForeignKey("tipos_bloqueo","tipo_bloqueo_id"),LeftJoin("jTipoBloqueo"), NotNull]
        [LookupEditor(typeof(Portal.Entities.TiposBloqueoRow))]

        public Int16? TipoBloqueoId
        {
            get { return Fields.TipoBloqueoId[this]; }
            set { Fields.TipoBloqueoId[this] = value; }
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

        [DisplayName("Observaciones"), Size(1000), QuickSearch]
        public String Observaciones
        {
            get { return Fields.Observaciones[this]; }
            set { Fields.Observaciones[this] = value; }
        }

        [DisplayName("Reserva Id"), Column("reserva_id")]
        public Int32? ReservaId
        {
            get { return Fields.ReservaId[this]; }
            set { Fields.ReservaId[this] = value; }
        }

        [DisplayName("Usuario"), Column("user_id"), ForeignKey("users", "UserId"), LeftJoin("jUsers")]
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

        [DisplayName("Fecha Modificacion"), Column("fecha_modificacion"), NotNull]
        public DateTime? FechaModificacion
        {
            get { return Fields.FechaModificacion[this]; }
            set { Fields.FechaModificacion[this] = value; }
        }

 

        [DisplayName("Numero Habitacion"), Expression("jHabitacion.[numero_habitacion]")]
        public String HabitacionNumeroHabitacion
        {
            get { return Fields.HabitacionNumeroHabitacion[this]; }
            set { Fields.HabitacionNumeroHabitacion[this] = value; }
        }

        [DisplayName("Tipo Habitacion Id"), Expression("jHabitacion.[tipo_habitacion_id]"),ForeignKey("tipos_habitacion","tipo_habitacion_id"),LeftJoin("jTipoHabitacion"),TextualField("DescCorta")]
        public Int16? HabitacionTipoHabitacionId
        {
            get { return Fields.HabitacionTipoHabitacionId[this]; }
            set { Fields.HabitacionTipoHabitacionId[this] = value; }
        }
        [DisplayName("Tipo Habitacion"),Expression("jTipoHabitacion.[desc_corta]")]
        public String DescCorta
        {
            get { return Fields.DescCorta[this]; }
            set { Fields.DescCorta[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.HabitacionBloqueoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.HabitacionNumeroHabitacion; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public HabitacionesBloqueosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field HabitacionBloqueoId;
            public Int16Field HabitacionId;
            public Int16Field TipoBloqueoId;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;
            public StringField Observaciones;
            public Int32Field ReservaId;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public Int16Field HotelId;
            public Int16Field EmpresaId;
            public StringField HabitacionNumeroHabitacion;
            public Int16Field HabitacionTipoHabitacionId;

            public StringField DescCorta;
            public StringField UserName;


            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.HabitacionesBloqueos";
            }
        }
    }
}
