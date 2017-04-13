
namespace Geshotel.Recepcion.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using Portal.Entities;

    [ConnectionKey("Default"), TableName("reservas_servicios"), DisplayName("Reservas Servicios"), InstanceName("Reservas Servicios"), TwoLevelCached]
    [ReadPermission("Recepcion:Hotel")]
    [ModifyPermission("Recepcion:Hotel")]
    public sealed class ReservasServiciosRow : Row, IIdRow
    {
        [DisplayName("Servicio Reserva Id"), Column("servicio_reserva_id"), Identity]
        public Int32? ServicioReservaId
        {
            get { return Fields.ServicioReservaId[this]; }
            set { Fields.ServicioReservaId[this] = value; }
        }

        [DisplayName("Reserva"), Column("reserva_id"), NotNull, ForeignKey("reservas", "reserva_id"), LeftJoin("jReserva"), TextualField("ReservaNombreReserva")]
        public Int32? ReservaId
        {
            get { return Fields.ReservaId[this]; }
            set { Fields.ReservaId[this] = value; }
        }

        [DisplayName("Servicio"), Column("servicio_id"), NotNull, ForeignKey("servicios", "servicio_id"), LeftJoin("jServicio"), TextualField("ServicioNombreServicio")]
        [LookupEditor("Portal.Servicios")]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Unidad Calculo"), Column("unidad_calculo_id"), NotNull, ForeignKey("unidades_calculo", "unidad_calculo_id"), LeftJoin("jUnidadCalculo"), TextualField("UnidadCalculo")]
        [LookupEditor(typeof(UnidadesCalculoRow))]
        public Int16? UnidadCalculoId
        {
            get { return Fields.UnidadCalculoId[this]; }
            set { Fields.UnidadCalculoId[this] = value; }
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

        [DisplayName("Cantidad"), Column("cantidad"), Size(5), Scale(2), NotNull]
        public Decimal? Cantidad
        {
            get { return Fields.Cantidad[this]; }
            set { Fields.Cantidad[this] = value; }
        }

        [DisplayName("User"), Column("user_id"), ForeignKey("users", "UserId"), LeftJoin("jUser"), TextualField("UserUsername")]
        [LookupEditor("Portal.Usuarios")]
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

        [DisplayName("Flag Contrato"), Column("flag_contrato")]
        public Int16? FlagContrato
        {
            get { return Fields.FlagContrato[this]; }
            set { Fields.FlagContrato[this] = value; }
        }

        [DisplayName("Precio Servicio"), Column("precio_servicio")]
        public Double? PrecioServicio
        {
            get { return Fields.PrecioServicio[this]; }
            set { Fields.PrecioServicio[this] = value; }
        }

        [DisplayName("Servicio Extra"), Column("servicio_extra")]
        public Int16? ServicioExtra
        {
            get { return Fields.ServicioExtra[this]; }
            set { Fields.ServicioExtra[this] = value; }
        }

        [DisplayName("Servicio Nombre Servicio"), Expression("jServicio.[nombre_servicio]")]
        public String ServicioNombreServicio
        {
            get { return Fields.ServicioNombreServicio[this]; }
            set { Fields.ServicioNombreServicio[this] = value; }
        }




        [DisplayName("Unidad Calculo"), Expression("jUnidadCalculo.[descripcion_unidad_calculo]")]
        public String UnidadCalculo
        {
            get { return Fields.UnidadCalculo[this]; }
            set { Fields.UnidadCalculo[this] = value; }
        }


        [DisplayName("Username"), Expression("jUser.[Username]")]
        public String Username
        {
            get { return Fields.Username[this]; }
            set { Fields.Username[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ServicioReservaId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ReservasServiciosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ServicioReservaId;
            public Int32Field ReservaId;
            public Int32Field ServicioId;
            public Int16Field UnidadCalculoId;
            public DateTimeField FechaDesde;
            public DateTimeField FechaHasta;
            public DecimalField Cantidad;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;
            public Int16Field FlagContrato;
            public DoubleField PrecioServicio;
            public Int16Field ServicioExtra;


            public StringField ServicioNombreServicio;

            
            public StringField UnidadCalculo;

            public StringField Username;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.ReservasServicios";
            }
        }
    }
}
