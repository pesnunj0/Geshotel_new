
namespace Geshotel.Portal.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), TableName("tipos_habitacion_hotel"), DisplayName("Tipos Habitacion Hotel"), InstanceName("Tipos Habitacion Hotel"), TwoLevelCached]
    [ReadPermission("HotelConfig:General")]
    [ModifyPermission("HotelConfig:General")]
    public sealed class TiposHabitacionHotelRow : Row, IIdRow
    {
        [DisplayName("Hotel"), Column("hotel_id"), PrimaryKey, ForeignKey("hoteles", "hotel_id"), LeftJoin("jHotel"), TextualField("Hotel")]
        public Int16? HotelId
        {
            get { return Fields.HotelId[this]; }
            set { Fields.HotelId[this] = value; }
        }

        [DisplayName("Tipo Habitacion"), Column("tipo_habitacion_id"), PrimaryKey, ForeignKey("tipos_habitacion", "tipo_habitacion_id"), LeftJoin("jTipoHabitacion"), TextualField("TipoHabitacionDescCorta")]
        public Int16? TipoHabitacionId
        {
            get { return Fields.TipoHabitacionId[this]; }
            set { Fields.TipoHabitacionId[this] = value; }
        }

        [DisplayName("Servicio"), Column("servicio_id"), NotNull, ForeignKey("servicios", "servicio_id"), LeftJoin("jServicio"), TextualField("ServicioNombreServicio")]
        public Int32? ServicioId
        {
            get { return Fields.ServicioId[this]; }
            set { Fields.ServicioId[this] = value; }
        }

        [DisplayName("Hotel"), Expression("jHotel.[hotel]")]
        public String Hotel
        {
            get { return Fields.Hotel[this]; }
            set { Fields.Hotel[this] = value; }
        }

        [DisplayName("Hotel Empresa Id"), Expression("jHotel.[empresa_id]")]
        public Int16? HotelEmpresaId
        {
            get { return Fields.HotelEmpresaId[this]; }
            set { Fields.HotelEmpresaId[this] = value; }
        }

        [DisplayName("Hotel Tipo Hotel Id"), Expression("jHotel.[tipo_hotel_id]")]
        public Int16? HotelTipoHotelId
        {
            get { return Fields.HotelTipoHotelId[this]; }
            set { Fields.HotelTipoHotelId[this] = value; }
        }

        [DisplayName("Hotel Categoria Id"), Expression("jHotel.[categoria_id]")]
        public Int16? HotelCategoriaId
        {
            get { return Fields.HotelCategoriaId[this]; }
            set { Fields.HotelCategoriaId[this] = value; }
        }

        [DisplayName("Hotel Nombre Corto"), Expression("jHotel.[nombre_corto]")]
        public String HotelNombreCorto
        {
            get { return Fields.HotelNombreCorto[this]; }
            set { Fields.HotelNombreCorto[this] = value; }
        }

        [DisplayName("Hotel Direccion"), Expression("jHotel.[direccion]")]
        public String HotelDireccion
        {
            get { return Fields.HotelDireccion[this]; }
            set { Fields.HotelDireccion[this] = value; }
        }

        [DisplayName("Hotel Poblacion"), Expression("jHotel.[poblacion]")]
        public String HotelPoblacion
        {
            get { return Fields.HotelPoblacion[this]; }
            set { Fields.HotelPoblacion[this] = value; }
        }

        [DisplayName("Hotel Zip"), Expression("jHotel.[zip]")]
        public String HotelZip
        {
            get { return Fields.HotelZip[this]; }
            set { Fields.HotelZip[this] = value; }
        }

        [DisplayName("Hotel Provincia Id"), Expression("jHotel.[provincia_id]")]
        public Int16? HotelProvinciaId
        {
            get { return Fields.HotelProvinciaId[this]; }
            set { Fields.HotelProvinciaId[this] = value; }
        }

        [DisplayName("Hotel Nacion Id"), Expression("jHotel.[nacion_id]")]
        public Int16? HotelNacionId
        {
            get { return Fields.HotelNacionId[this]; }
            set { Fields.HotelNacionId[this] = value; }
        }

        [DisplayName("Hotel Telefono"), Expression("jHotel.[telefono]")]
        public String HotelTelefono
        {
            get { return Fields.HotelTelefono[this]; }
            set { Fields.HotelTelefono[this] = value; }
        }

        [DisplayName("Hotel Fax"), Expression("jHotel.[fax]")]
        public String HotelFax
        {
            get { return Fields.HotelFax[this]; }
            set { Fields.HotelFax[this] = value; }
        }

        [DisplayName("Hotel Cta Manocorriente"), Expression("jHotel.[cta_manocorriente]")]
        public String HotelCtaManocorriente
        {
            get { return Fields.HotelCtaManocorriente[this]; }
            set { Fields.HotelCtaManocorriente[this] = value; }
        }

        [DisplayName("Hotel Dpto Contable"), Expression("jHotel.[dpto_contable]")]
        public String HotelDptoContable
        {
            get { return Fields.HotelDptoContable[this]; }
            set { Fields.HotelDptoContable[this] = value; }
        }

        [DisplayName("Hotel Cta Contable Cajas"), Expression("jHotel.[cta_contable_cajas]")]
        public String HotelCtaContableCajas
        {
            get { return Fields.HotelCtaContableCajas[this]; }
            set { Fields.HotelCtaContableCajas[this] = value; }
        }

        [DisplayName("Hotel Cta Contable Banco"), Expression("jHotel.[cta_contable_banco]")]
        public String HotelCtaContableBanco
        {
            get { return Fields.HotelCtaContableBanco[this]; }
            set { Fields.HotelCtaContableBanco[this] = value; }
        }

        [DisplayName("Hotel Fecha Inicio Programa"), Expression("jHotel.[fecha_inicio_programa]")]
        public DateTime? HotelFechaInicioPrograma
        {
            get { return Fields.HotelFechaInicioPrograma[this]; }
            set { Fields.HotelFechaInicioPrograma[this] = value; }
        }

        [DisplayName("Hotel Ruta Fichero Policia"), Expression("jHotel.[ruta_fichero_policia]")]
        public String HotelRutaFicheroPolicia
        {
            get { return Fields.HotelRutaFicheroPolicia[this]; }
            set { Fields.HotelRutaFicheroPolicia[this] = value; }
        }

        [DisplayName("Hotel Contador Fichero Policia"), Expression("jHotel.[contador_fichero_policia]")]
        public Int32? HotelContadorFicheroPolicia
        {
            get { return Fields.HotelContadorFicheroPolicia[this]; }
            set { Fields.HotelContadorFicheroPolicia[this] = value; }
        }

        [DisplayName("Hotel Identificador Fichero Policia"), Expression("jHotel.[identificador_fichero_policia]")]
        public String HotelIdentificadorFicheroPolicia
        {
            get { return Fields.HotelIdentificadorFicheroPolicia[this]; }
            set { Fields.HotelIdentificadorFicheroPolicia[this] = value; }
        }

        [DisplayName("Hotel Email Reservas"), Expression("jHotel.[email_reservas]")]
        public String HotelEmailReservas
        {
            get { return Fields.HotelEmailReservas[this]; }
            set { Fields.HotelEmailReservas[this] = value; }
        }

        [DisplayName("Hotel Email Ventas"), Expression("jHotel.[email_ventas]")]
        public String HotelEmailVentas
        {
            get { return Fields.HotelEmailVentas[this]; }
            set { Fields.HotelEmailVentas[this] = value; }
        }

        [DisplayName("Hotel Email Smtp"), Expression("jHotel.[email_smtp]")]
        public String HotelEmailSmtp
        {
            get { return Fields.HotelEmailSmtp[this]; }
            set { Fields.HotelEmailSmtp[this] = value; }
        }

        [DisplayName("Hotel Texto Cancelacion"), Expression("jHotel.[texto_cancelacion]")]
        public String HotelTextoCancelacion
        {
            get { return Fields.HotelTextoCancelacion[this]; }
            set { Fields.HotelTextoCancelacion[this] = value; }
        }

        [DisplayName("Hotel Usuario Ista"), Expression("jHotel.[usuario_ista]")]
        public String HotelUsuarioIsta
        {
            get { return Fields.HotelUsuarioIsta[this]; }
            set { Fields.HotelUsuarioIsta[this] = value; }
        }

        [DisplayName("Hotel Password Ista"), Expression("jHotel.[password_ista]")]
        public String HotelPasswordIsta
        {
            get { return Fields.HotelPasswordIsta[this]; }
            set { Fields.HotelPasswordIsta[this] = value; }
        }

        [DisplayName("Hotel Url Ista"), Expression("jHotel.[url_ista]")]
        public String HotelUrlIsta
        {
            get { return Fields.HotelUrlIsta[this]; }
            set { Fields.HotelUrlIsta[this] = value; }
        }

        [DisplayName("Hotel Municipio Ista"), Expression("jHotel.[municipio_ista]")]
        public String HotelMunicipioIsta
        {
            get { return Fields.HotelMunicipioIsta[this]; }
            set { Fields.HotelMunicipioIsta[this] = value; }
        }

        [DisplayName("Hotel Numero Registro Ista"), Expression("jHotel.[numero_registro_ista]")]
        public Int32? HotelNumeroRegistroIsta
        {
            get { return Fields.HotelNumeroRegistroIsta[this]; }
            set { Fields.HotelNumeroRegistroIsta[this] = value; }
        }

        [DisplayName("Hotel Ruta Bavel"), Expression("jHotel.[ruta_bavel]")]
        public String HotelRutaBavel
        {
            get { return Fields.HotelRutaBavel[this]; }
            set { Fields.HotelRutaBavel[this] = value; }
        }

        [DisplayName("Hotel Dingus Usuario"), Expression("jHotel.[dingus_usuario]")]
        public String HotelDingusUsuario
        {
            get { return Fields.HotelDingusUsuario[this]; }
            set { Fields.HotelDingusUsuario[this] = value; }
        }

        [DisplayName("Hotel Dingus Password"), Expression("jHotel.[dingus_password]")]
        public String HotelDingusPassword
        {
            get { return Fields.HotelDingusPassword[this]; }
            set { Fields.HotelDingusPassword[this] = value; }
        }

        [DisplayName("Hotel Dingus Hotel Code"), Expression("jHotel.[dingus_hotel_code]")]
        public String HotelDingusHotelCode
        {
            get { return Fields.HotelDingusHotelCode[this]; }
            set { Fields.HotelDingusHotelCode[this] = value; }
        }

        [DisplayName("Hotel Dingus Traductor"), Expression("jHotel.[dingus_traductor]")]
        public String HotelDingusTraductor
        {
            get { return Fields.HotelDingusTraductor[this]; }
            set { Fields.HotelDingusTraductor[this] = value; }
        }

        [DisplayName("Hotel Dingus Url"), Expression("jHotel.[dingus_url]")]
        public String HotelDingusUrl
        {
            get { return Fields.HotelDingusUrl[this]; }
            set { Fields.HotelDingusUrl[this] = value; }
        }

        [DisplayName("Hotel Checkin On Line"), Expression("jHotel.[checkin_on_line]")]
        public Int16? HotelCheckinOnLine
        {
            get { return Fields.HotelCheckinOnLine[this]; }
            set { Fields.HotelCheckinOnLine[this] = value; }
        }

        [DisplayName("Hotel Minimo Dias Checkin Online"), Expression("jHotel.[minimo_dias_checkin_online]")]
        public Int16? HotelMinimoDiasCheckinOnline
        {
            get { return Fields.HotelMinimoDiasCheckinOnline[this]; }
            set { Fields.HotelMinimoDiasCheckinOnline[this] = value; }
        }

        [DisplayName("Hotel Zoom Mapa"), Expression("jHotel.[zoom_mapa]")]
        public Int16? HotelZoomMapa
        {
            get { return Fields.HotelZoomMapa[this]; }
            set { Fields.HotelZoomMapa[this] = value; }
        }

        [DisplayName("Hotel Lat"), Expression("jHotel.[lat]")]
        public Decimal? HotelLat
        {
            get { return Fields.HotelLat[this]; }
            set { Fields.HotelLat[this] = value; }
        }

        [DisplayName("Hotel Lng"), Expression("jHotel.[lng]")]
        public Double? HotelLng
        {
            get { return Fields.HotelLng[this]; }
            set { Fields.HotelLng[this] = value; }
        }

        [DisplayName("Hotel Ancho"), Expression("jHotel.[ancho]")]
        public Int16? HotelAncho
        {
            get { return Fields.HotelAncho[this]; }
            set { Fields.HotelAncho[this] = value; }
        }

        [DisplayName("Hotel Alto"), Expression("jHotel.[alto]")]
        public Int16? HotelAlto
        {
            get { return Fields.HotelAlto[this]; }
            set { Fields.HotelAlto[this] = value; }
        }

        [DisplayName("Hotel Overbooking Limit"), Expression("jHotel.[overbooking_limit]")]
        public Double? HotelOverbookingLimit
        {
            get { return Fields.HotelOverbookingLimit[this]; }
            set { Fields.HotelOverbookingLimit[this] = value; }
        }

        [DisplayName("Tipo Habitacion Desc Corta"), Expression("jTipoHabitacion.[desc_corta]")]
        public String TipoHabitacionDescCorta
        {
            get { return Fields.TipoHabitacionDescCorta[this]; }
            set { Fields.TipoHabitacionDescCorta[this] = value; }
        }

        [DisplayName("Tipo Habitacion Descripcion"), Expression("jTipoHabitacion.[descripcion]")]
        public String TipoHabitacionDescripcion
        {
            get { return Fields.TipoHabitacionDescripcion[this]; }
            set { Fields.TipoHabitacionDescripcion[this] = value; }
        }

        [DisplayName("Tipo Habitacion Grupo Habitacion Id"), Expression("jTipoHabitacion.[grupo_habitacion_id]")]
        public Int16? TipoHabitacionGrupoHabitacionId
        {
            get { return Fields.TipoHabitacionGrupoHabitacionId[this]; }
            set { Fields.TipoHabitacionGrupoHabitacionId[this] = value; }
        }

        [DisplayName("Tipo Habitacion Numero Personas"), Expression("jTipoHabitacion.[numero_personas]")]
        public Int16? TipoHabitacionNumeroPersonas
        {
            get { return Fields.TipoHabitacionNumeroPersonas[this]; }
            set { Fields.TipoHabitacionNumeroPersonas[this] = value; }
        }

        [DisplayName("Tipo Habitacion Desvios"), Expression("jTipoHabitacion.[desvios]")]
        public Int16? TipoHabitacionDesvios
        {
            get { return Fields.TipoHabitacionDesvios[this]; }
            set { Fields.TipoHabitacionDesvios[this] = value; }
        }

        [DisplayName("Tipo Habitacion No Show"), Expression("jTipoHabitacion.[no_show]")]
        public Int16? TipoHabitacionNoShow
        {
            get { return Fields.TipoHabitacionNoShow[this]; }
            set { Fields.TipoHabitacionNoShow[this] = value; }
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

        IIdField IIdRow.IdField
        {
            get { return Fields.HotelId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TiposHabitacionHotelRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field HotelId;
            public Int16Field TipoHabitacionId;
            public Int32Field ServicioId;

            public StringField Hotel;
            public Int16Field HotelEmpresaId;
            public Int16Field HotelTipoHotelId;
            public Int16Field HotelCategoriaId;
            public StringField HotelNombreCorto;
            public StringField HotelDireccion;
            public StringField HotelPoblacion;
            public StringField HotelZip;
            public Int16Field HotelProvinciaId;
            public Int16Field HotelNacionId;
            public StringField HotelTelefono;
            public StringField HotelFax;
            public StringField HotelCtaManocorriente;
            public StringField HotelDptoContable;
            public StringField HotelCtaContableCajas;
            public StringField HotelCtaContableBanco;
            public DateTimeField HotelFechaInicioPrograma;
            public StringField HotelRutaFicheroPolicia;
            public Int32Field HotelContadorFicheroPolicia;
            public StringField HotelIdentificadorFicheroPolicia;
            public StringField HotelEmailReservas;
            public StringField HotelEmailVentas;
            public StringField HotelEmailSmtp;
            public StringField HotelTextoCancelacion;
            public StringField HotelUsuarioIsta;
            public StringField HotelPasswordIsta;
            public StringField HotelUrlIsta;
            public StringField HotelMunicipioIsta;
            public Int32Field HotelNumeroRegistroIsta;
            public StringField HotelRutaBavel;
            public StringField HotelDingusUsuario;
            public StringField HotelDingusPassword;
            public StringField HotelDingusHotelCode;
            public StringField HotelDingusTraductor;
            public StringField HotelDingusUrl;
            public Int16Field HotelCheckinOnLine;
            public Int16Field HotelMinimoDiasCheckinOnline;
            public Int16Field HotelZoomMapa;
            public DecimalField HotelLat;
            public DoubleField HotelLng;
            public Int16Field HotelAncho;
            public Int16Field HotelAlto;
            public DoubleField HotelOverbookingLimit;

            public StringField TipoHabitacionDescCorta;
            public StringField TipoHabitacionDescripcion;
            public Int16Field TipoHabitacionGrupoHabitacionId;
            public Int16Field TipoHabitacionNumeroPersonas;
            public Int16Field TipoHabitacionDesvios;
            public Int16Field TipoHabitacionNoShow;

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

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Portal.TiposHabitacionHotel";
            }
        }
    }
}
