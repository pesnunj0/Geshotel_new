
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

    [ConnectionKey("Default"), DisplayName("Lineas De Contrato"), InstanceName("Lineas De Contrato"), TwoLevelCached]
    [ReadPermission("Reservas:General")]
    [ModifyPermission("Contratos:General")]
    public sealed class LineasDeContratoRow : Row, IIdRow
    {
        [DisplayName("Linea Contrato Id"), Column("linea_contrato_id"), Identity]
        public Int32? LineaContratoId
        {
            get { return Fields.LineaContratoId[this]; }
            set { Fields.LineaContratoId[this] = value; }
        }

        [DisplayName("Contrato"), Column("contrato_id"), NotNull, ForeignKey("contratos", "contrato_id"), LeftJoin("jContrato"), TextualField("ContratoNumeroContratoCliente")]
        public Int32? ContratoId
        {
            get { return Fields.ContratoId[this]; }
            set { Fields.ContratoId[this] = value; }
        }

        [DisplayName("Oferta"), Column("oferta")]
        public Int16? Oferta
        {
            get { return Fields.Oferta[this]; }
            set { Fields.Oferta[this] = value; }
        }

        [DisplayName("Desde"), Column("desde"), NotNull]
        public DateTime? Desde
        {
            get { return Fields.Desde[this]; }
            set { Fields.Desde[this] = value; }
        }

        [DisplayName("Hasta"), Column("hasta"), NotNull]
        public DateTime? Hasta
        {
            get { return Fields.Hasta[this]; }
            set { Fields.Hasta[this] = value; }
        }

        [DisplayName("Servicio"), Column("servicio_id"), NotNull, ForeignKey("servicios", "servicio_id"), LeftJoin("jServicio"), TextualField("ServicioNombreServicio")]
        [LookupEditor(typeof(ServiciosRow))]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Unidad Calculo"), Column("unidad_calculo_id"), NotNull, ForeignKey("unidades_calculo", "unidad_calculo_id"), LeftJoin("jUnidadCalculo"), TextualField("UnidadCalculoUc")]
        public Int16? UnidadCalculoId
        {
            get { return Fields.UnidadCalculoId[this]; }
            set { Fields.UnidadCalculoId[this] = value; }
        }

        [DisplayName("Frecuencia Id"), Column("frecuencia_id")]
        public Int16? FrecuenciaId
        {
            get { return Fields.FrecuenciaId[this]; }
            set { Fields.FrecuenciaId[this] = value; }
        }

        [DisplayName("Tipo Imputacion Id"), Column("tipo_imputacion_id")]
        public Int16? TipoImputacionId
        {
            get { return Fields.TipoImputacionId[this]; }
            set { Fields.TipoImputacionId[this] = value; }
        }

        [DisplayName("Importe"), Column("importe"), NotNull]
        public Double? Importe
        {
            get { return Fields.Importe[this]; }
            set { Fields.Importe[this] = value; }
        }

        [DisplayName("N"), Column("n")]
        public Int16? N
        {
            get { return Fields.N[this]; }
            set { Fields.N[this] = value; }
        }

        [DisplayName("Tipo Oferta"), Column("tipo_oferta_id"), ForeignKey("tipos_de_oferta", "tipo_oferta_id"), LeftJoin("jTipoOferta"), TextualField("TipoOfertaOferta")]
        public Int16? TipoOfertaId
        {
            get { return Fields.TipoOfertaId[this]; }
            set { Fields.TipoOfertaId[this] = value; }
        }

        [DisplayName("M"), Column("m")]
        public Double? M
        {
            get { return Fields.M[this]; }
            set { Fields.M[this] = value; }
        }

        [DisplayName("Ambito Oferta Id"), Column("ambito_oferta_id")]
        public Int16? AmbitoOfertaId
        {
            get { return Fields.AmbitoOfertaId[this]; }
            set { Fields.AmbitoOfertaId[this] = value; }
        }

        [DisplayName("Lunes"), Column("lunes"), NotNull]
        public Int16? Lunes
        {
            get { return Fields.Lunes[this]; }
            set { Fields.Lunes[this] = value; }
        }

        [DisplayName("Martes"), Column("martes"), Size(1), NotNull]
        public Boolean? Martes
        {
            get { return Fields.Martes[this]; }
            set { Fields.Martes[this] = value; }
        }

        [DisplayName("Miercoles"), Column("miercoles"), Size(1), NotNull]
        public Boolean? Miercoles
        {
            get { return Fields.Miercoles[this]; }
            set { Fields.Miercoles[this] = value; }
        }

        [DisplayName("Jueves"), Column("jueves"), Size(1), NotNull]
        public Boolean? Jueves
        {
            get { return Fields.Jueves[this]; }
            set { Fields.Jueves[this] = value; }
        }

        [DisplayName("Viernes"), Column("viernes"), Size(1), NotNull]
        public Boolean? Viernes
        {
            get { return Fields.Viernes[this]; }
            set { Fields.Viernes[this] = value; }
        }

        [DisplayName("Sabado"), Column("sabado"), Size(1), NotNull]
        public Boolean? Sabado
        {
            get { return Fields.Sabado[this]; }
            set { Fields.Sabado[this] = value; }
        }

        [DisplayName("Domingo"), Column("domingo"), Size(1), NotNull]
        public Boolean? Domingo
        {
            get { return Fields.Domingo[this]; }
            set { Fields.Domingo[this] = value; }
        }

        [DisplayName("Pag Factura"), Column("pag_factura")]
        public Int16? PagFactura
        {
            get { return Fields.PagFactura[this]; }
            set { Fields.PagFactura[this] = value; }
        }

        [DisplayName("User Id"), Column("user_id")]
        public Int16? UserId
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

        [DisplayName("Contrato Hotel Id"), Expression("jContrato.[hotel_id]")]
        public Int16? ContratoHotelId
        {
            get { return Fields.ContratoHotelId[this]; }
            set { Fields.ContratoHotelId[this] = value; }
        }

        [DisplayName("Contrato Cliente Id"), Expression("jContrato.[cliente_id]")]
        public Int32? ContratoClienteId
        {
            get { return Fields.ContratoClienteId[this]; }
            set { Fields.ContratoClienteId[this] = value; }
        }

        [DisplayName("Contrato Fecha Contrato"), Expression("jContrato.[fecha_contrato]")]
        public DateTime? ContratoFechaContrato
        {
            get { return Fields.ContratoFechaContrato[this]; }
            set { Fields.ContratoFechaContrato[this] = value; }
        }

        [DisplayName("Contrato Fecha Desde"), Expression("jContrato.[fecha_desde]")]
        public DateTime? ContratoFechaDesde
        {
            get { return Fields.ContratoFechaDesde[this]; }
            set { Fields.ContratoFechaDesde[this] = value; }
        }

        [DisplayName("Contrato Fecha Hasta"), Expression("jContrato.[fecha_hasta]")]
        public DateTime? ContratoFechaHasta
        {
            get { return Fields.ContratoFechaHasta[this]; }
            set { Fields.ContratoFechaHasta[this] = value; }
        }

        [DisplayName("Contrato Contrato Id Original"), Expression("jContrato.[contrato_id_original]")]
        public Int32? ContratoContratoIdOriginal
        {
            get { return Fields.ContratoContratoIdOriginal[this]; }
            set { Fields.ContratoContratoIdOriginal[this] = value; }
        }

        [DisplayName("Contrato Contrato Id Siguiente"), Expression("jContrato.[contrato_id_siguiente]")]
        public Int32? ContratoContratoIdSiguiente
        {
            get { return Fields.ContratoContratoIdSiguiente[this]; }
            set { Fields.ContratoContratoIdSiguiente[this] = value; }
        }

        [DisplayName("Contrato Numero Contrato Cliente"), Expression("jContrato.[numero_contrato_cliente]")]
        public String ContratoNumeroContratoCliente
        {
            get { return Fields.ContratoNumeroContratoCliente[this]; }
            set { Fields.ContratoNumeroContratoCliente[this] = value; }
        }

        [DisplayName("Contrato User Id"), Expression("jContrato.[user_id]")]
        public Int16? ContratoUserId
        {
            get { return Fields.ContratoUserId[this]; }
            set { Fields.ContratoUserId[this] = value; }
        }

        [DisplayName("Contrato Fecha Modificacion"), Expression("jContrato.[fecha_modificacion]")]
        public DateTime? ContratoFechaModificacion
        {
            get { return Fields.ContratoFechaModificacion[this]; }
            set { Fields.ContratoFechaModificacion[this] = value; }
        }

        [DisplayName("Contrato Temporada Id"), Expression("jContrato.[temporada_id]")]
        public Int16? ContratoTemporadaId
        {
            get { return Fields.ContratoTemporadaId[this]; }
            set { Fields.ContratoTemporadaId[this] = value; }
        }

        [DisplayName("Contrato Impuesto Incluido"), Expression("jContrato.[impuesto_incluido]")]
        public Int16? ContratoImpuestoIncluido
        {
            get { return Fields.ContratoImpuestoIncluido[this]; }
            set { Fields.ContratoImpuestoIncluido[this] = value; }
        }

        [DisplayName("Contrato Mercado Id"), Expression("jContrato.[mercado_id]")]
        public Int16? ContratoMercadoId
        {
            get { return Fields.ContratoMercadoId[this]; }
            set { Fields.ContratoMercadoId[this] = value; }
        }

        [DisplayName("Contrato Cliente Id Padre"), Expression("jContrato.[cliente_id_padre]")]
        public Int32? ContratoClienteIdPadre
        {
            get { return Fields.ContratoClienteIdPadre[this]; }
            set { Fields.ContratoClienteIdPadre[this] = value; }
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

        [DisplayName("Unidad Calculo Uc"), Expression("jUnidadCalculo.[UC]")]
        public String UnidadCalculoUc
        {
            get { return Fields.UnidadCalculoUc[this]; }
            set { Fields.UnidadCalculoUc[this] = value; }
        }

        [DisplayName("Unidad Calculo Descripcion Unidad Calculo"), Expression("jUnidadCalculo.[descripcion_unidad_calculo]")]
        public String UnidadCalculoDescripcionUnidadCalculo
        {
            get { return Fields.UnidadCalculoDescripcionUnidadCalculo[this]; }
            set { Fields.UnidadCalculoDescripcionUnidadCalculo[this] = value; }
        }

        [DisplayName("Unidad Calculo Tipo Unidad Calculo Id"), Expression("jUnidadCalculo.[tipo_unidad_calculo_id]")]
        public Int16? UnidadCalculoTipoUnidadCalculoId
        {
            get { return Fields.UnidadCalculoTipoUnidadCalculoId[this]; }
            set { Fields.UnidadCalculoTipoUnidadCalculoId[this] = value; }
        }

        [DisplayName("Unidad Calculo Pax"), Expression("jUnidadCalculo.[pax]")]
        public Boolean? UnidadCalculoPax
        {
            get { return Fields.UnidadCalculoPax[this]; }
            set { Fields.UnidadCalculoPax[this] = value; }
        }

        [DisplayName("Unidad Calculo Servicio Id"), Expression("jUnidadCalculo.[servicio_id]")]
        public Int32? UnidadCalculoServicioId
        {
            get { return Fields.UnidadCalculoServicioId[this]; }
            set { Fields.UnidadCalculoServicioId[this] = value; }
        }

        [DisplayName("Unidad Calculo User Id"), Expression("jUnidadCalculo.[user_id]")]
        public Int32? UnidadCalculoUserId
        {
            get { return Fields.UnidadCalculoUserId[this]; }
            set { Fields.UnidadCalculoUserId[this] = value; }
        }

        [DisplayName("Unidad Calculo Fecha Modificacion"), Expression("jUnidadCalculo.[fecha_modificacion]")]
        public DateTime? UnidadCalculoFechaModificacion
        {
            get { return Fields.UnidadCalculoFechaModificacion[this]; }
            set { Fields.UnidadCalculoFechaModificacion[this] = value; }
        }

        [DisplayName("Tipo Oferta Oferta"), Expression("jTipoOferta.[Oferta]")]
        public String TipoOfertaOferta
        {
            get { return Fields.TipoOfertaOferta[this]; }
            set { Fields.TipoOfertaOferta[this] = value; }
        }

        [DisplayName("Tipo Oferta Permitir M Mayor Que N"), Expression("jTipoOferta.[permitir_m_mayor_que_n]")]
        public Int16? TipoOfertaPermitirMMayorQueN
        {
            get { return Fields.TipoOfertaPermitirMMayorQueN[this]; }
            set { Fields.TipoOfertaPermitirMMayorQueN[this] = value; }
        }

        [DisplayName("Tipo Oferta Rejilla"), Expression("jTipoOferta.[rejilla]")]
        public Int16? TipoOfertaRejilla
        {
            get { return Fields.TipoOfertaRejilla[this]; }
            set { Fields.TipoOfertaRejilla[this] = value; }
        }

        [DisplayName("Tipo Oferta Observaciones"), Expression("jTipoOferta.[Observaciones]")]
        public String TipoOfertaObservaciones
        {
            get { return Fields.TipoOfertaObservaciones[this]; }
            set { Fields.TipoOfertaObservaciones[this] = value; }
        }

        [DisplayName("Tipo Oferta Orden Aplicacion"), Expression("jTipoOferta.[orden_aplicacion]")]
        public Int16? TipoOfertaOrdenAplicacion
        {
            get { return Fields.TipoOfertaOrdenAplicacion[this]; }
            set { Fields.TipoOfertaOrdenAplicacion[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.LineaContratoId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public LineasDeContratoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field LineaContratoId;
            public Int32Field ContratoId;
            public Int16Field Oferta;
            public DateTimeField Desde;
            public DateTimeField Hasta;
            public Int32Field ServicioId;
            public Int16Field UnidadCalculoId;
            public Int16Field FrecuenciaId;
            public Int16Field TipoImputacionId;
            public DoubleField Importe;
            public Int16Field N;
            public Int16Field TipoOfertaId;
            public DoubleField M;
            public Int16Field AmbitoOfertaId;
            public Int16Field Lunes;
            public BooleanField Martes;
            public BooleanField Miercoles;
            public BooleanField Jueves;
            public BooleanField Viernes;
            public BooleanField Sabado;
            public BooleanField Domingo;
            public Int16Field PagFactura;
            public Int16Field UserId;
            public DateTimeField FechaModificacion;

            public Int16Field ContratoHotelId;
            public Int32Field ContratoClienteId;
            public DateTimeField ContratoFechaContrato;
            public DateTimeField ContratoFechaDesde;
            public DateTimeField ContratoFechaHasta;
            public Int32Field ContratoContratoIdOriginal;
            public Int32Field ContratoContratoIdSiguiente;
            public StringField ContratoNumeroContratoCliente;
            public Int16Field ContratoUserId;
            public DateTimeField ContratoFechaModificacion;
            public Int16Field ContratoTemporadaId;
            public Int16Field ContratoImpuestoIncluido;
            public Int16Field ContratoMercadoId;
            public Int32Field ContratoClienteIdPadre;

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

            public StringField UnidadCalculoUc;
            public StringField UnidadCalculoDescripcionUnidadCalculo;
            public Int16Field UnidadCalculoTipoUnidadCalculoId;
            public BooleanField UnidadCalculoPax;
            public Int32Field UnidadCalculoServicioId;
            public Int32Field UnidadCalculoUserId;
            public DateTimeField UnidadCalculoFechaModificacion;

            public StringField TipoOfertaOferta;
            public Int16Field TipoOfertaPermitirMMayorQueN;
            public Int16Field TipoOfertaRejilla;
            public StringField TipoOfertaObservaciones;
            public Int16Field TipoOfertaOrdenAplicacion;

            public RowFields()
                : base("lineas_de_contrato")
            {
                LocalTextPrefix = "Contratos.LineasDeContrato";
            }
        }
    }
}
