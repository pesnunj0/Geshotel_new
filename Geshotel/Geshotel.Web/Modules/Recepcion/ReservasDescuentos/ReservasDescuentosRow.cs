
namespace Geshotel.Recepcion.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("reservas_descuentos"), DisplayName("Reservas Descuentos"), InstanceName("Reservas Descuentos"), TwoLevelCached]
    [ReadPermission("Recepcion:Hotel")]
    [ModifyPermission("Recepcion:Hotel")]
    public sealed class ReservasDescuentosRow : Row, IIdRow, INameRow
    {
        [DisplayName("Reserva Descuento Id"), Column("reserva_descuento_id"), Identity]
        public Int32? ReservaDescuentoId
        {
            get { return Fields.ReservaDescuentoId[this]; }
            set { Fields.ReservaDescuentoId[this] = value; }
        }

        [DisplayName("Reserva"), Column("reserva_id"), NotNull, ForeignKey("reservas", "reserva_id"), LeftJoin("jReserva"), TextualField("ReservaNombreReserva")]
        public Int32? ReservaId
        {
            get { return Fields.ReservaId[this]; }
            set { Fields.ReservaId[this] = value; }
        }

        [DisplayName("Servicio"), Column("servicio_id"), NotNull, ForeignKey("servicios", "servicio_id"), LeftJoin("jServicio"), TextualField("ServicioNombreServicio")]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Tipo Descuento"), Column("tipo_descuento_id"), NotNull, ForeignKey("tipos_descuento", "tipo_descuento_id"), LeftJoin("jTipoDescuento"), TextualField("TipoDescuentoDescuento")]
        public Int16? TipoDescuentoId
        {
            get { return Fields.TipoDescuentoId[this]; }
            set { Fields.TipoDescuentoId[this] = value; }
        }

        [DisplayName("Tipo"), Column("tipo"), Size(1), NotNull, ForeignKey("modo_descuento", "tipo"), LeftJoin("jTipo"), QuickSearch, TextualField("TipoDescripcion")]
        public String Tipo
        {
            get { return Fields.Tipo[this]; }
            set { Fields.Tipo[this] = value; }
        }

        [DisplayName("Descuento"), Column("descuento"), Size(7), Scale(2), NotNull]
        public Decimal? Descuento
        {
            get { return Fields.Descuento[this]; }
            set { Fields.Descuento[this] = value; }
        }

        [DisplayName("User Id"), Column("user_id")]
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

        [DisplayName("Reserva Fecha Creacion"), Expression("jReserva.[fecha_creacion]")]
        public DateTime? ReservaFechaCreacion
        {
            get { return Fields.ReservaFechaCreacion[this]; }
            set { Fields.ReservaFechaCreacion[this] = value; }
        }

        [DisplayName("Reserva Hotel Id"), Expression("jReserva.[hotel_id]")]
        public Int16? ReservaHotelId
        {
            get { return Fields.ReservaHotelId[this]; }
            set { Fields.ReservaHotelId[this] = value; }
        }

        [DisplayName("Reserva Estado Reserva Id"), Expression("jReserva.[estado_reserva_id]")]
        public Int16? ReservaEstadoReservaId
        {
            get { return Fields.ReservaEstadoReservaId[this]; }
            set { Fields.ReservaEstadoReservaId[this] = value; }
        }

        [DisplayName("Reserva Cliente Id"), Expression("jReserva.[cliente_id]")]
        public Int32? ReservaClienteId
        {
            get { return Fields.ReservaClienteId[this]; }
            set { Fields.ReservaClienteId[this] = value; }
        }

        [DisplayName("Reserva Canal Reserva Id"), Expression("jReserva.[canal_reserva_id]")]
        public Int16? ReservaCanalReservaId
        {
            get { return Fields.ReservaCanalReservaId[this]; }
            set { Fields.ReservaCanalReservaId[this] = value; }
        }

        [DisplayName("Reserva Cliente Id Factura"), Expression("jReserva.[cliente_id_factura]")]
        public Int32? ReservaClienteIdFactura
        {
            get { return Fields.ReservaClienteIdFactura[this]; }
            set { Fields.ReservaClienteIdFactura[this] = value; }
        }

        [DisplayName("Reserva Fecha Reserva"), Expression("jReserva.[fecha_reserva]")]
        public DateTime? ReservaFechaReserva
        {
            get { return Fields.ReservaFechaReserva[this]; }
            set { Fields.ReservaFechaReserva[this] = value; }
        }

        [DisplayName("Reserva Nombre Reserva"), Expression("jReserva.[nombre_reserva]")]
        public String ReservaNombreReserva
        {
            get { return Fields.ReservaNombreReserva[this]; }
            set { Fields.ReservaNombreReserva[this] = value; }
        }

        [DisplayName("Reserva Fecha Prevista Llegada"), Expression("jReserva.[fecha_prevista_llegada]")]
        public DateTime? ReservaFechaPrevistaLlegada
        {
            get { return Fields.ReservaFechaPrevistaLlegada[this]; }
            set { Fields.ReservaFechaPrevistaLlegada[this] = value; }
        }

        [DisplayName("Reserva Fecha Prevista Salida"), Expression("jReserva.[fecha_prevista_salida]")]
        public DateTime? ReservaFechaPrevistaSalida
        {
            get { return Fields.ReservaFechaPrevistaSalida[this]; }
            set { Fields.ReservaFechaPrevistaSalida[this] = value; }
        }

        [DisplayName("Reserva Hora Prevista Llegada"), Expression("jReserva.[hora_prevista_llegada]")]
        public DateTime? ReservaHoraPrevistaLlegada
        {
            get { return Fields.ReservaHoraPrevistaLlegada[this]; }
            set { Fields.ReservaHoraPrevistaLlegada[this] = value; }
        }

        [DisplayName("Reserva Hora Prevista Salida"), Expression("jReserva.[hora_prevista_salida]")]
        public DateTime? ReservaHoraPrevistaSalida
        {
            get { return Fields.ReservaHoraPrevistaSalida[this]; }
            set { Fields.ReservaHoraPrevistaSalida[this] = value; }
        }

        [DisplayName("Reserva Observaciones Llegada"), Expression("jReserva.[Observaciones_llegada]")]
        public String ReservaObservacionesLlegada
        {
            get { return Fields.ReservaObservacionesLlegada[this]; }
            set { Fields.ReservaObservacionesLlegada[this] = value; }
        }

        [DisplayName("Reserva Observaciones Salida"), Expression("jReserva.[Observaciones_salida]")]
        public String ReservaObservacionesSalida
        {
            get { return Fields.ReservaObservacionesSalida[this]; }
            set { Fields.ReservaObservacionesSalida[this] = value; }
        }

        [DisplayName("Reserva Observaciones Cliente"), Expression("jReserva.[Observaciones_cliente]")]
        public String ReservaObservacionesCliente
        {
            get { return Fields.ReservaObservacionesCliente[this]; }
            set { Fields.ReservaObservacionesCliente[this] = value; }
        }

        [DisplayName("Reserva Observaciones"), Expression("jReserva.[Observaciones]")]
        public String ReservaObservaciones
        {
            get { return Fields.ReservaObservaciones[this]; }
            set { Fields.ReservaObservaciones[this] = value; }
        }

        [DisplayName("Reserva Fecha Llegada"), Expression("jReserva.[fecha_llegada]")]
        public DateTime? ReservaFechaLlegada
        {
            get { return Fields.ReservaFechaLlegada[this]; }
            set { Fields.ReservaFechaLlegada[this] = value; }
        }

        [DisplayName("Reserva Fecha Salida"), Expression("jReserva.[fecha_salida]")]
        public DateTime? ReservaFechaSalida
        {
            get { return Fields.ReservaFechaSalida[this]; }
            set { Fields.ReservaFechaSalida[this] = value; }
        }

        [DisplayName("Reserva Bono Referencia"), Expression("jReserva.[bono_referencia]")]
        public String ReservaBonoReferencia
        {
            get { return Fields.ReservaBonoReferencia[this]; }
            set { Fields.ReservaBonoReferencia[this] = value; }
        }

        [DisplayName("Reserva Bono Online"), Expression("jReserva.[bono_online]")]
        public String ReservaBonoOnline
        {
            get { return Fields.ReservaBonoOnline[this]; }
            set { Fields.ReservaBonoOnline[this] = value; }
        }

        [DisplayName("Reserva Bloquear Tarifa"), Expression("jReserva.[bloquear_tarifa]")]
        public Int16? ReservaBloquearTarifa
        {
            get { return Fields.ReservaBloquearTarifa[this]; }
            set { Fields.ReservaBloquearTarifa[this] = value; }
        }

        [DisplayName("Reserva Permite Devolucion"), Expression("jReserva.[permite_devolucion]")]
        public Int16? ReservaPermiteDevolucion
        {
            get { return Fields.ReservaPermiteDevolucion[this]; }
            set { Fields.ReservaPermiteDevolucion[this] = value; }
        }

        [DisplayName("Reserva Tipo Tarjeta Id"), Expression("jReserva.[tipo_tarjeta_id]")]
        public Int16? ReservaTipoTarjetaId
        {
            get { return Fields.ReservaTipoTarjetaId[this]; }
            set { Fields.ReservaTipoTarjetaId[this] = value; }
        }

        [DisplayName("Reserva Tarjeta Credito"), Expression("jReserva.[tarjeta_credito]")]
        public String ReservaTarjetaCredito
        {
            get { return Fields.ReservaTarjetaCredito[this]; }
            set { Fields.ReservaTarjetaCredito[this] = value; }
        }

        [DisplayName("Reserva Caducidad"), Expression("jReserva.[caducidad]")]
        public String ReservaCaducidad
        {
            get { return Fields.ReservaCaducidad[this]; }
            set { Fields.ReservaCaducidad[this] = value; }
        }

        [DisplayName("Reserva Cod Seguridad"), Expression("jReserva.[cod_seguridad]")]
        public String ReservaCodSeguridad
        {
            get { return Fields.ReservaCodSeguridad[this]; }
            set { Fields.ReservaCodSeguridad[this] = value; }
        }

        [DisplayName("Reserva Contrato Ttoo"), Expression("jReserva.[contrato_ttoo]")]
        public String ReservaContratoTtoo
        {
            get { return Fields.ReservaContratoTtoo[this]; }
            set { Fields.ReservaContratoTtoo[this] = value; }
        }

        [DisplayName("Reserva Codigo Oferta"), Expression("jReserva.[codigo_oferta]")]
        public String ReservaCodigoOferta
        {
            get { return Fields.ReservaCodigoOferta[this]; }
            set { Fields.ReservaCodigoOferta[this] = value; }
        }

        [DisplayName("Reserva Valor"), Expression("jReserva.[valor]")]
        public Decimal? ReservaValor
        {
            get { return Fields.ReservaValor[this]; }
            set { Fields.ReservaValor[this] = value; }
        }

        [DisplayName("Reserva Valor Validado"), Expression("jReserva.[valor_validado]")]
        public Decimal? ReservaValorValidado
        {
            get { return Fields.ReservaValorValidado[this]; }
            set { Fields.ReservaValorValidado[this] = value; }
        }

        [DisplayName("Reserva Fecha Validacion"), Expression("jReserva.[fecha_validacion]")]
        public DateTime? ReservaFechaValidacion
        {
            get { return Fields.ReservaFechaValidacion[this]; }
            set { Fields.ReservaFechaValidacion[this] = value; }
        }

        [DisplayName("Reserva Usuario Validacion"), Expression("jReserva.[usuario_validacion]")]
        public Int32? ReservaUsuarioValidacion
        {
            get { return Fields.ReservaUsuarioValidacion[this]; }
            set { Fields.ReservaUsuarioValidacion[this] = value; }
        }

        [DisplayName("Reserva Paroventas Check"), Expression("jReserva.[paroventas_check]")]
        public Int16? ReservaParoventasCheck
        {
            get { return Fields.ReservaParoventasCheck[this]; }
            set { Fields.ReservaParoventasCheck[this] = value; }
        }

        [DisplayName("Reserva Cupos Check"), Expression("jReserva.[cupos_check]")]
        public Int16? ReservaCuposCheck
        {
            get { return Fields.ReservaCuposCheck[this]; }
            set { Fields.ReservaCuposCheck[this] = value; }
        }

        [DisplayName("Reserva Release Check"), Expression("jReserva.[release_check]")]
        public Int16? ReservaReleaseCheck
        {
            get { return Fields.ReservaReleaseCheck[this]; }
            set { Fields.ReservaReleaseCheck[this] = value; }
        }

        [DisplayName("Reserva Reserva Dingus"), Expression("jReserva.[reserva_dingus]")]
        public Stream ReservaReservaDingus
        {
            get { return Fields.ReservaReservaDingus[this]; }
            set { Fields.ReservaReservaDingus[this] = value; }
        }

        [DisplayName("Reserva Dingus Impuestos Incluidos"), Expression("jReserva.[dingus_impuestos_incluidos]")]
        public Int16? ReservaDingusImpuestosIncluidos
        {
            get { return Fields.ReservaDingusImpuestosIncluidos[this]; }
            set { Fields.ReservaDingusImpuestosIncluidos[this] = value; }
        }

        [DisplayName("Reserva Dingus Comision"), Expression("jReserva.[dingus_comision]")]
        public Int16? ReservaDingusComision
        {
            get { return Fields.ReservaDingusComision[this]; }
            set { Fields.ReservaDingusComision[this] = value; }
        }

        [DisplayName("Reserva Reserva Dingus Tipo"), Expression("jReserva.[reserva_dingus_tipo]")]
        public Int16? ReservaReservaDingusTipo
        {
            get { return Fields.ReservaReservaDingusTipo[this]; }
            set { Fields.ReservaReservaDingusTipo[this] = value; }
        }

        [DisplayName("Reserva Fecha Anulacion"), Expression("jReserva.[fecha_anulacion]")]
        public DateTime? ReservaFechaAnulacion
        {
            get { return Fields.ReservaFechaAnulacion[this]; }
            set { Fields.ReservaFechaAnulacion[this] = value; }
        }

        [DisplayName("Reserva User Id"), Expression("jReserva.[user_id]")]
        public Int32? ReservaUserId
        {
            get { return Fields.ReservaUserId[this]; }
            set { Fields.ReservaUserId[this] = value; }
        }

        [DisplayName("Reserva Fecha Modificacion"), Expression("jReserva.[fecha_modificacion]")]
        public DateTime? ReservaFechaModificacion
        {
            get { return Fields.ReservaFechaModificacion[this]; }
            set { Fields.ReservaFechaModificacion[this] = value; }
        }

        [DisplayName("Servicio Nombre Servicio"), Expression("jServicio.[nombre_servicio]")]
        public String ServicioNombreServicio
        {
            get { return Fields.ServicioNombreServicio[this]; }
            set { Fields.ServicioNombreServicio[this] = value; }
        }

        [DisplayName("Servicio Abreviatura"), Expression("jServicio.[abreviatura]")]
        public String ServicioAbreviatura
        {
            get { return Fields.ServicioAbreviatura[this]; }
            set { Fields.ServicioAbreviatura[this] = value; }
        }

        [DisplayName("Servicio Tipo Servicio Id"), Expression("jServicio.[tipo_servicio_id]")]
        public Int16? ServicioTipoServicioId
        {
            get { return Fields.ServicioTipoServicioId[this]; }
            set { Fields.ServicioTipoServicioId[this] = value; }
        }

        [DisplayName("Servicio Sw Produccion"), Expression("jServicio.[sw_produccion]")]
        public Boolean? ServicioSwProduccion
        {
            get { return Fields.ServicioSwProduccion[this]; }
            set { Fields.ServicioSwProduccion[this] = value; }
        }

        [DisplayName("Servicio Sw Descuento"), Expression("jServicio.[sw_descuento]")]
        public Boolean? ServicioSwDescuento
        {
            get { return Fields.ServicioSwDescuento[this]; }
            set { Fields.ServicioSwDescuento[this] = value; }
        }

        [DisplayName("Servicio Sw Ajustes"), Expression("jServicio.[sw_ajustes]")]
        public Boolean? ServicioSwAjustes
        {
            get { return Fields.ServicioSwAjustes[this]; }
            set { Fields.ServicioSwAjustes[this] = value; }
        }

        [DisplayName("Servicio Sw Gastos"), Expression("jServicio.[sw_gastos]")]
        public Boolean? ServicioSwGastos
        {
            get { return Fields.ServicioSwGastos[this]; }
            set { Fields.ServicioSwGastos[this] = value; }
        }

        [DisplayName("Servicio Sw Pension"), Expression("jServicio.[sw_pension]")]
        public Boolean? ServicioSwPension
        {
            get { return Fields.ServicioSwPension[this]; }
            set { Fields.ServicioSwPension[this] = value; }
        }

        [DisplayName("Servicio Sw Rectificativa"), Expression("jServicio.[sw_rectificativa]")]
        public Boolean? ServicioSwRectificativa
        {
            get { return Fields.ServicioSwRectificativa[this]; }
            set { Fields.ServicioSwRectificativa[this] = value; }
        }

        [DisplayName("Servicio Tipo Unidad Calculo Id"), Expression("jServicio.[tipo_unidad_calculo_id]")]
        public Int16? ServicioTipoUnidadCalculoId
        {
            get { return Fields.ServicioTipoUnidadCalculoId[this]; }
            set { Fields.ServicioTipoUnidadCalculoId[this] = value; }
        }

        [DisplayName("Servicio Concepto Acelerador Reservas Id"), Expression("jServicio.[concepto_acelerador_reservas_id]")]
        public Int16? ServicioConceptoAceleradorReservasId
        {
            get { return Fields.ServicioConceptoAceleradorReservasId[this]; }
            set { Fields.ServicioConceptoAceleradorReservasId[this] = value; }
        }

        [DisplayName("Servicio Costo"), Expression("jServicio.[costo]")]
        public Double? ServicioCosto
        {
            get { return Fields.ServicioCosto[this]; }
            set { Fields.ServicioCosto[this] = value; }
        }

        [DisplayName("Servicio Suma Servicio Id"), Expression("jServicio.[suma_servicio_id]")]
        public Int32? ServicioSumaServicioId
        {
            get { return Fields.ServicioSumaServicioId[this]; }
            set { Fields.ServicioSumaServicioId[this] = value; }
        }

        [DisplayName("Servicio Resta Servicio Id"), Expression("jServicio.[resta_servicio_id]")]
        public Int32? ServicioRestaServicioId
        {
            get { return Fields.ServicioRestaServicioId[this]; }
            set { Fields.ServicioRestaServicioId[this] = value; }
        }

        [DisplayName("Servicio User Id"), Expression("jServicio.[user_id]")]
        public Int32? ServicioUserId
        {
            get { return Fields.ServicioUserId[this]; }
            set { Fields.ServicioUserId[this] = value; }
        }

        [DisplayName("Servicio Fecha Modificacion"), Expression("jServicio.[fecha_modificacion]")]
        public DateTime? ServicioFechaModificacion
        {
            get { return Fields.ServicioFechaModificacion[this]; }
            set { Fields.ServicioFechaModificacion[this] = value; }
        }

        [DisplayName("Servicio Tipo Hab"), Expression("jServicio.[tipo_hab]")]
        public Int16? ServicioTipoHab
        {
            get { return Fields.ServicioTipoHab[this]; }
            set { Fields.ServicioTipoHab[this] = value; }
        }

        [DisplayName("Servicio Tipo Pension"), Expression("jServicio.[tipo_pension]")]
        public Int16? ServicioTipoPension
        {
            get { return Fields.ServicioTipoPension[this]; }
            set { Fields.ServicioTipoPension[this] = value; }
        }

        [DisplayName("Tipo Descuento Descuento"), Expression("jTipoDescuento.[tipo_descuento]")]
        public String TipoDescuentoDescuento
        {
            get { return Fields.TipoDescuentoDescuento[this]; }
            set { Fields.TipoDescuentoDescuento[this] = value; }
        }

        [DisplayName("Tipo Descripcion"), Expression("jTipo.[descripcion]")]
        public String TipoDescripcion
        {
            get { return Fields.TipoDescripcion[this]; }
            set { Fields.TipoDescripcion[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ReservaDescuentoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Tipo; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ReservasDescuentosRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ReservaDescuentoId;
            public Int32Field ReservaId;
            public Int32Field ServicioId;
            public Int16Field TipoDescuentoId;
            public StringField Tipo;
            public DecimalField Descuento;
            public Int32Field UserId;
            public DateTimeField FechaModificacion;

            public DateTimeField ReservaFechaCreacion;
            public Int16Field ReservaHotelId;
            public Int16Field ReservaEstadoReservaId;
            public Int32Field ReservaClienteId;
            public Int16Field ReservaCanalReservaId;
            public Int32Field ReservaClienteIdFactura;
            public DateTimeField ReservaFechaReserva;
            public StringField ReservaNombreReserva;
            public DateTimeField ReservaFechaPrevistaLlegada;
            public DateTimeField ReservaFechaPrevistaSalida;
            public DateTimeField ReservaHoraPrevistaLlegada;
            public DateTimeField ReservaHoraPrevistaSalida;
            public StringField ReservaObservacionesLlegada;
            public StringField ReservaObservacionesSalida;
            public StringField ReservaObservacionesCliente;
            public StringField ReservaObservaciones;
            public DateTimeField ReservaFechaLlegada;
            public DateTimeField ReservaFechaSalida;
            public StringField ReservaBonoReferencia;
            public StringField ReservaBonoOnline;
            public Int16Field ReservaBloquearTarifa;
            public Int16Field ReservaPermiteDevolucion;
            public Int16Field ReservaTipoTarjetaId;
            public StringField ReservaTarjetaCredito;
            public StringField ReservaCaducidad;
            public StringField ReservaCodSeguridad;
            public StringField ReservaContratoTtoo;
            public StringField ReservaCodigoOferta;
            public DecimalField ReservaValor;
            public DecimalField ReservaValorValidado;
            public DateTimeField ReservaFechaValidacion;
            public Int32Field ReservaUsuarioValidacion;
            public Int16Field ReservaParoventasCheck;
            public Int16Field ReservaCuposCheck;
            public Int16Field ReservaReleaseCheck;
            public StreamField ReservaReservaDingus;
            public Int16Field ReservaDingusImpuestosIncluidos;
            public Int16Field ReservaDingusComision;
            public Int16Field ReservaReservaDingusTipo;
            public DateTimeField ReservaFechaAnulacion;
            public Int32Field ReservaUserId;
            public DateTimeField ReservaFechaModificacion;

            public StringField ServicioNombreServicio;
            public StringField ServicioAbreviatura;
            public Int16Field ServicioTipoServicioId;
            public BooleanField ServicioSwProduccion;
            public BooleanField ServicioSwDescuento;
            public BooleanField ServicioSwAjustes;
            public BooleanField ServicioSwGastos;
            public BooleanField ServicioSwPension;
            public BooleanField ServicioSwRectificativa;
            public Int16Field ServicioTipoUnidadCalculoId;
            public Int16Field ServicioConceptoAceleradorReservasId;
            public DoubleField ServicioCosto;
            public Int32Field ServicioSumaServicioId;
            public Int32Field ServicioRestaServicioId;
            public Int32Field ServicioUserId;
            public DateTimeField ServicioFechaModificacion;
            public Int16Field ServicioTipoHab;
            public Int16Field ServicioTipoPension;

            public StringField TipoDescuentoDescuento;

            public StringField TipoDescripcion;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Recepcion.ReservasDescuentos";
            }
        }
    }
}
