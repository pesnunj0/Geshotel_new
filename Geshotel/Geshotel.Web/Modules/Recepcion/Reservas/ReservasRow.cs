
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

    [ConnectionKey("Default"), TableName("reservas"), DisplayName("Reservas"), InstanceName("Reservas"), TwoLevelCached]
    [ReadPermission("Recepcion:Hotel")]
    [ModifyPermission("Recepcion:Hotel")]
    
    public sealed class ReservasRow : Row, IIdRow, INameRow
    {
        [DisplayName("Tipo Habitacion"),Column("tipo_habitacion_id"),NotNull, ForeignKey("servicios","servicio_id"), LeftJoin("jTipoHabitacion"),TextualField("TipoHabitacion")]
        [LookupEditor(("Contratos.ServiciosHotel"), CascadeFrom = "HotelId", CascadeField = "HotelId", FilterField = "ConceptoAceleradorReservasId", FilterValue = 1)]
        public Int16? TipoHabitacionId
        {
            get { return Fields.TipoHabitacionId[this]; }
            set { Fields.TipoHabitacionId[this]= value; }
        }

        [DisplayName("TipoHabitacion"),Expression("jTipoHabitacion.abreviatura")]
        public String TipoHabitacion
        {
            get { return Fields.TipoHabitacion[this]; }
            set { Fields.TipoHabitacion[this] = value; }
        }

        [DisplayName("Pension"), Column("pension_id"), NotNull, ForeignKey("servicios", "servicio_id"), LeftJoin("jPension"), TextualField("Pension")]
        [LookupEditor(("Contratos.ServiciosHotel"), CascadeFrom = "HotelId", CascadeField = "HotelId", FilterField = "ConceptoAceleradorReservasId", FilterValue = 2)]
        public Int16? PensionId
        {
            get { return Fields.PensionId[this]; }
            set { Fields.PensionId[this] = value; }
        }

        [DisplayName("Pension"), Expression("jPension.abreviatura")]
        public String Pension
        {
            get { return Fields.Pension[this]; }
            set { Fields.Pension[this] = value; }
        }
        [DisplayName("Adultos"), Column("adultos"),NotNull]
        public Int16? Adultos
        {
            get { return Fields.Adultos[this]; }
            set { Fields.Adultos[this] = value; }
        }
        [DisplayName("Child_50"), Column("child_50"),NotNull, DefaultValue(0)]
        public Int16? Child50
        {
            get { return Fields.Child50[this]; }
            set { Fields.Child50[this] = value; }
        }
        [DisplayName("ChildFree"), Column("child_free"), NotNull, DefaultValue(0)]
        public Int16? ChildFree
        {
            get { return Fields.ChildFree[this]; }
            set { Fields.ChildFree[this] = value; }
        }
        [DisplayName("Bebes"), Column("bebes"), NotNull, DefaultValue(0)]
        public Int16? Bebes
        {
            get { return Fields.Bebes[this]; }
            set { Fields.Bebes[this] = value; }
        }

        [DisplayName("Reserva Id"), Column("reserva_id"), Identity]
        public Int32? ReservaId
        {
            get { return Fields.ReservaId[this]; }
            set { Fields.ReservaId[this] = value; }
        }
        [DisplayName("Ficheros"), MultipleFileUploadEditor(FilenameFormat = "Reservas/Ficheros/~")]
        public string Ficheros
        {
            get { return Fields.Ficheros[this]; }
            set { Fields.Ficheros[this] = value; }
        }
        [DisplayName("Pax"), Expression("T0.adultos+T0.child_50+t0.child_free")]
        public Int16? Pax
        {
            get { return Fields.Pax[this]; }
            set { Fields.Pax[this] = value; }
        }
        [DisplayName("Reserva"),Expression("CONCAT(t0.reserva_id,'-',t0.bono_referencia,'-',t0.nombre_reserva)")]
        public String ReservaName
        {
            get { return Fields.ReservaName[this]; }
            set { Fields.ReservaName[this] = value; }
        }

        [DisplayName("Noches"),Expression("DATEDIFF(t0.fecha_prevista_salida,t0.fecha_prevista_llegada)")]
        public Int32? Noches
        {
            get { return Fields.Noches[this]; }
            set { Fields.Noches[this] = value; }
        }

        [DisplayName("Fecha Creacion"), Column("fecha_creacion"), DisplayFormat("g"), NotNull]
        public DateTime? FechaCreacion
        {
            get { return Fields.FechaCreacion[this]; }
            set { Fields.FechaCreacion[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), NotNull, ForeignKey("hoteles", "hotel_id"), LeftJoin("jHotel"), TextualField("HotelName"),LookupInclude]
        [LookupEditor("Portal.Hoteles")]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Estado Reserva"), Column("estado_reserva_id"), NotNull, ForeignKey("reserva_estados", "estado_reserva_id"), LeftJoin("jEstadoReserva"), LookupInclude, TextualField("EstadoReserva")]
        [LookupEditor("Portal.ReservaEstados")]
        public Int16? EstadoReservaId
        {
            get { return Fields.EstadoReservaId[this]; }
            set { Fields.EstadoReservaId[this] = value; }
        }

        [DisplayName("Cliente"), Column("cliente_id"), NotNull, ForeignKey("clientes", "cliente_id"), LeftJoin("jCliente"), TextualField("ClienteRazon")]
        [LookupEditor("Contratos.Clientes")]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }

        [DisplayName("Canal Reserva"), Column("canal_reserva_id"), ForeignKey("canales_reserva", "canal_reserva_id"), LeftJoin("jCanalReserva"), LookupInclude, TextualField("CanalReserva")]
        [LookupEditor(typeof(Contratos.Entities.CanalesReservaRow))]
        public Int16? CanalReservaId
        {
            get { return Fields.CanalReservaId[this]; }
            set { Fields.CanalReservaId[this] = value; }
        }

        //[DisplayName("Cliente Id Factura"), Column("cliente_id_factura"), ForeignKey("clientes", "cliente_id"), LeftJoin("jClienteIdFactura"), LookupInclude, TextualField("ClienteIdFacturaRazon")]
        //[LookupEditor("Contratos.Clientes")]
        [DisplayName("Cliente Id Factura"), Column("cliente_id_factura"), ForeignKey("clientes", "cliente_id"), LeftJoin("jClienteIdFactura"), LookupInclude, TextualField("ClienteIdFacturaRazon")]
        [LookupEditor("Contratos.Clientes")]
        public Int32? ClienteIdFactura
        {
            get { return Fields.ClienteIdFactura[this]; }
            set { Fields.ClienteIdFactura[this] = value; }
        }

        [DisplayName("Fecha Reserva"), Column("fecha_reserva"), NotNull]
        public DateTime? FechaReserva
        {
            get { return Fields.FechaReserva[this]; }
            set { Fields.FechaReserva[this] = value; }
        }

        [DisplayName("Nombre Reserva"), Column("nombre_reserva"), Size(100), NotNull, QuickSearch]
        public String NombreReserva
        {
            get { return Fields.NombreReserva[this]; }
            set { Fields.NombreReserva[this] = value; }
        }

        [DisplayName("Fecha Prevista Llegada"), Column("fecha_prevista_llegada"), NotNull]
        [DateTimeKind(DateTimeKind.Utc), DateTimeEditor]
        public DateTime? FechaPrevistaLlegada
        {
            get { return Fields.FechaPrevistaLlegada[this]; }
            set { Fields.FechaPrevistaLlegada[this] = value; }
        }

        [DisplayName("Fecha Prevista Salida"), Column("fecha_prevista_salida"), NotNull]
        [DateTimeKind(DateTimeKind.Utc), DateTimeEditor]
        public DateTime? FechaPrevistaSalida
        {
            get { return Fields.FechaPrevistaSalida[this]; }
            set { Fields.FechaPrevistaSalida[this] = value; }
        }

 
        [DisplayName("Observaciones Llegada"), Column("Observaciones_llegada"), Size(1000)]
        public String ObservacionesLlegada
        {
            get { return Fields.ObservacionesLlegada[this]; }
            set { Fields.ObservacionesLlegada[this] = value; }
        }

        [DisplayName("Observaciones Salida"), Column("Observaciones_salida"), Size(1000)]
        public String ObservacionesSalida
        {
            get { return Fields.ObservacionesSalida[this]; }
            set { Fields.ObservacionesSalida[this] = value; }
        }

        [DisplayName("Observaciones Cliente"), Column("Observaciones_cliente"), Size(1000)]
        public String ObservacionesCliente
        {
            get { return Fields.ObservacionesCliente[this]; }
            set { Fields.ObservacionesCliente[this] = value; }
        }

        [DisplayName("Observaciones"), Size(1000)]
        public String Observaciones
        {
            get { return Fields.Observaciones[this]; }
            set { Fields.Observaciones[this] = value; }
        }

        [DisplayName("Fecha Llegada"), Column("fecha_llegada"), DateTimeKind(DateTimeKind.Local)]
        public DateTime? FechaLlegada
        {
            get { return Fields.FechaLlegada[this]; }
            set { Fields.FechaLlegada[this] = value; }
        }

        [DisplayName("Fecha Salida"), Column("fecha_salida")]
        public DateTime? FechaSalida
        {
            get { return Fields.FechaSalida[this]; }
            set { Fields.FechaSalida[this] = value; }
        }

        [DisplayName("Bono Referencia"), Column("bono_referencia"), Size(40), NotNull]
        public String BonoReferencia
        {
            get { return Fields.BonoReferencia[this]; }
            set { Fields.BonoReferencia[this] = value; }
        }

        [DisplayName("Bono Online"), Column("bono_online"), Size(40)]
        public String BonoOnline
        {
            get { return Fields.BonoOnline[this]; }
            set { Fields.BonoOnline[this] = value; }
        }

        [DisplayName("Bloquear Tarifa"), Column("bloquear_tarifa"), NotNull]
        public Boolean? BloquearTarifa
        {
            get { return Fields.BloquearTarifa[this]; }
            set { Fields.BloquearTarifa[this] = value; }
        }

        [DisplayName("Permite Devolucion"), Column("permite_devolucion"), NotNull]
        public Boolean? PermiteDevolucion
        {
            get { return Fields.PermiteDevolucion[this]; }
            set { Fields.PermiteDevolucion[this] = value; }
        }

        [DisplayName("VIP"), Column("vip"), NotNull]
        public Boolean? Vip
        {
            get { return Fields.Vip[this]; }
            set { Fields.Vip[this] = value; }
        }

        [DisplayName("Tipo Tarjeta Id"), Column("tipo_tarjeta_id"),ForeignKey("tipos_de_tarjeta","tipo_tarjeta_id"),LeftJoin("jTipoTarjeta"),TextualField("tipo_tarjeta")]
        [LookupEditor(typeof(TiposDeTarjetaRow))]
        public Int16? TipoTarjetaId
        {
            get { return Fields.TipoTarjetaId[this]; }
            set { Fields.TipoTarjetaId[this] = value; }
        }
        
        [DisplayName("Tipo Tarjeta"), Expression("jTipoTarjeta.tipo_tarjeta")]
        public String TipoTarjeta
        {
            get { return Fields.TipoTarjeta[this]; }
            set { Fields.TipoTarjeta[this] = value; }
        }

        [DisplayName("Tarjeta Credito"), Column("tarjeta_credito"), Size(255)]
        public String TarjetaCredito
        {
            get { return Fields.TarjetaCredito[this]; }
            set { Fields.TarjetaCredito[this] = value; }
        }

        [DisplayName("Caducidad"), Column("caducidad"), Size(10)]
        public String Caducidad
        {
            get { return Fields.Caducidad[this]; }
            set { Fields.Caducidad[this] = value; }
        }

        [DisplayName("Cod Seguridad"), Column("cod_seguridad"), Size(4)]
        public String CodSeguridad
        {
            get { return Fields.CodSeguridad[this]; }
            set { Fields.CodSeguridad[this] = value; }
        }

        [DisplayName("Contrato Ttoo"), Column("contrato_ttoo"), Size(30)]
        public String ContratoTtoo
        {
            get { return Fields.ContratoTtoo[this]; }
            set { Fields.ContratoTtoo[this] = value; }
        }

        [DisplayName("Codigo Oferta"), Column("codigo_oferta"), Size(30)]
        public String CodigoOferta
        {
            get { return Fields.CodigoOferta[this]; }
            set { Fields.CodigoOferta[this] = value; }
        }

        [DisplayName("Valor"), Column("valor"), Size(10), Scale(2)]
        public Double? Valor
        {
            get { return Fields.Valor[this]; }
            set { Fields.Valor[this] = value; }
        }

        [DisplayName("Valor Validado"), Column("valor_validado"), Size(10), Scale(2)]
        public Decimal? ValorValidado
        {
            get { return Fields.ValorValidado[this]; }
            set { Fields.ValorValidado[this] = value; }
        }

        [DisplayName("Fecha Validacion"), Column("fecha_validacion")]
        public DateTime? FechaValidacion
        {
            get { return Fields.FechaValidacion[this]; }
            set { Fields.FechaValidacion[this] = value; }
        }

        [DisplayName("Usuario Validacion"), Column("usuario_validacion"), ForeignKey("users", "UserId"), LeftJoin("jValidationUser"), TextualField("ValidationUsername")]
        [LookupEditor("Portal.Users")]
        public Int32? UsuarioValidacion
        {
            get { return Fields.UsuarioValidacion[this]; }
            set { Fields.UsuarioValidacion[this] = value; }
        }

        [DisplayName("Paroventas Check"), Column("paroventas_check")]
        public Boolean? ParoventasCheck
        {
            get { return Fields.ParoventasCheck[this]; }
            set { Fields.ParoventasCheck[this] = value; }
        }

        [DisplayName("Cupos Check"), Column("cupos_check")]
        public Boolean? CuposCheck
        {
            get { return Fields.CuposCheck[this]; }
            set { Fields.CuposCheck[this] = value; }
        }

        [DisplayName("Release Check"), Column("release_check")]
        public Boolean? ReleaseCheck
        {
            get { return Fields.ReleaseCheck[this]; }
            set { Fields.ReleaseCheck[this] = value; }
        }

        [DisplayName("Reserva Dingus"), Column("reserva_dingus")]
        public Stream ReservaDingus
        {
            get { return Fields.ReservaDingus[this]; }
            set { Fields.ReservaDingus[this] = value; }
        }

        [DisplayName("Dingus Impuestos Incluidos"), Column("dingus_impuestos_incluidos")]
        public Boolean? DingusImpuestosIncluidos
        {
            get { return Fields.DingusImpuestosIncluidos[this]; }
            set { Fields.DingusImpuestosIncluidos[this] = value; }
        }

        [DisplayName("Dingus Comision"), Column("dingus_comision")]
        public Int16? DingusComision
        {
            get { return Fields.DingusComision[this]; }
            set { Fields.DingusComision[this] = value; }
        }

        [DisplayName("Reserva Dingus Tipo"), Column("reserva_dingus_tipo")]
        public Int16? ReservaDingusTipo
        {
            get { return Fields.ReservaDingusTipo[this]; }
            set { Fields.ReservaDingusTipo[this] = value; }
        }

        [DisplayName("Fecha Anulacion"), Column("fecha_anulacion")]
        public DateTime? FechaAnulacion
        {
            get { return Fields.FechaAnulacion[this]; }
            set { Fields.FechaAnulacion[this] = value; }
        }

        [DisplayName("User"), Column("user_id"), ForeignKey("users", "UserId"), LeftJoin("jUser"), TextualField("Username")]
        [LookupEditor("Portal.Users")]
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

        [DisplayName("Hotel"), Expression("jHotel.[hotel]")]
        public String HotelName
        {
            get { return Fields.HotelName[this]; }
            set { Fields.HotelName[this] = value; }
        }
        //*********
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


        [DisplayName("Estado Reserva Estado"), Expression("jEstadoReserva.[estado]")]
        public String EstadoReserva
        {
            get { return Fields.EstadoReserva[this]; }
            set { Fields.EstadoReserva[this] = value; }
        }


        [DisplayName("Cliente Razon"), Expression("jCliente.[razon]")]
        public String ClienteRazon
        {
            get { return Fields.ClienteRazon[this]; }
            set { Fields.ClienteRazon[this] = value; }
        }

        [DisplayName("Canal Reserva"), Expression("jCanalReserva.[nombre_canal]")]
        public String CanalReserva
        {
            get { return Fields.CanalReserva[this]; }
            set { Fields.CanalReserva[this] = value; }
        }

        [DisplayName("Cliente Id Factura Razon"), Expression("jClienteIdFactura.[razon]")]
        public String ClienteIdFacturaRazon
        {
            get { return Fields.ClienteIdFacturaRazon[this]; }
            set { Fields.ClienteIdFacturaRazon[this] = value; }
        }


        [DisplayName("User Username"), Expression("jUser.[Username]")]
        public String Username
        {
            get { return Fields.Username[this]; }
            set { Fields.Username[this] = value; }
        }

        [DisplayName("Validation Username"), Expression("jValidationUser.[Username]")]
        public String ValidationUsername
        {
            get { return Fields.ValidationUsername[this]; }
            set { Fields.ValidationUsername[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ReservaId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.ReservaName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ReservasRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ReservaId;
            public DateTimeField FechaCreacion;
            public Int16Field HotelId;
            public Int16Field EstadoReservaId;
            public Int32Field ClienteId;
            public Int16Field CanalReservaId;
            public Int32Field ClienteIdFactura;
            public DateTimeField FechaReserva;
            public StringField NombreReserva;
            public Int16Field TipoHabitacionId;
            public Int16Field PensionId;
            public Int16Field Adultos;
            public Int16Field Child50;
            public Int16Field ChildFree;
            public Int16Field Bebes;
            public Int16Field Pax;
            public BooleanField Vip;
            public DateTimeField FechaPrevistaLlegada;
            public DateTimeField FechaPrevistaSalida;
            public StringField ObservacionesLlegada;
            public StringField ObservacionesSalida;
            public StringField ObservacionesCliente;
            public StringField Observaciones;
            public DateTimeField FechaLlegada;
            public DateTimeField FechaSalida;
            public StringField BonoReferencia;
            public StringField BonoOnline;
            public BooleanField BloquearTarifa;
            public BooleanField PermiteDevolucion;
            public Int16Field TipoTarjetaId;
            public StringField TarjetaCredito;
            public StringField Caducidad;
            public StringField CodSeguridad;
            public StringField ContratoTtoo;
            public StringField CodigoOferta;
            public DoubleField Valor;
            public DecimalField ValorValidado;
            public DateTimeField FechaValidacion;
            public Int32Field UsuarioValidacion;
            public BooleanField ParoventasCheck;
            public BooleanField CuposCheck;
            public BooleanField ReleaseCheck;
            public StreamField ReservaDingus;
            public BooleanField DingusImpuestosIncluidos;
            public Int16Field DingusComision;
            public Int16Field ReservaDingusTipo;
            public DateTimeField FechaAnulacion;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public StringField HotelName;
            public Int16Field EmpresaId;
            public StringField Empresa;

            public StringField EstadoReserva;
            public StringField TipoTarjeta;

            public StringField ClienteRazon;

            public StringField CanalReserva;

            public StringField ClienteIdFacturaRazon;

            public StringField TipoHabitacion;
            public StringField Pension;

            public StringField Username;
            public StringField ValidationUsername;

            public StringField ReservaName;
            public Int32Field Noches;
            public readonly StringField Ficheros;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.Reservas";
            }
        }
    }
}
