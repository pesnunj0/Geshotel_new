
namespace Geshotel.Contratos.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Releases"), InstanceName("Releases"), TwoLevelCached]
    [ReadPermission("Contratos:General")]
    [ModifyPermission("Contratos:General")]
    public sealed class ReleasesRow : Row, IIdRow, INameRow
    {
        [DisplayName("Release Id"), Column("release_id"), Identity]
        public Int32? ReleaseId
        {
            get { return Fields.ReleaseId[this]; }
            set { Fields.ReleaseId[this] = value; }
        }

        [DisplayName("Cliente"), Column("cliente_id"), NotNull, ForeignKey("[dbo].[clientes]", "cliente_id"), LeftJoin("jCliente"), TextualField("ClienteRazon")]
        public Int32? ClienteId
        {
            get { return Fields.ClienteId[this]; }
            set { Fields.ClienteId[this] = value; }
        }

        [DisplayName("Hotel"), Column("hotel_id"), NotNull, ForeignKey("[dbo].[hoteles]", "hotel_id"), LeftJoin("jHotel"), TextualField("Hotel")]
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

        [DisplayName("Cliente Nombre"), Expression("jCliente.[nombre]")]
        public String ClienteNombre
        {
            get { return Fields.ClienteNombre[this]; }
            set { Fields.ClienteNombre[this] = value; }
        }

        [DisplayName("Cliente Apellidos"), Expression("jCliente.[apellidos]")]
        public String ClienteApellidos
        {
            get { return Fields.ClienteApellidos[this]; }
            set { Fields.ClienteApellidos[this] = value; }
        }

        [DisplayName("Cliente Empresa Id"), Expression("jCliente.[empresa_id]")]
        public Int16? ClienteEmpresaId
        {
            get { return Fields.ClienteEmpresaId[this]; }
            set { Fields.ClienteEmpresaId[this] = value; }
        }

        [DisplayName("Cliente Agencia Id"), Expression("jCliente.[agencia_id]")]
        public Int32? ClienteAgenciaId
        {
            get { return Fields.ClienteAgenciaId[this]; }
            set { Fields.ClienteAgenciaId[this] = value; }
        }

        [DisplayName("Cliente Mercado Id"), Expression("jCliente.[mercado_id]")]
        public Int16? ClienteMercadoId
        {
            get { return Fields.ClienteMercadoId[this]; }
            set { Fields.ClienteMercadoId[this] = value; }
        }

        [DisplayName("Cliente Cliente Defecto"), Expression("jCliente.[cliente_defecto]")]
        public Boolean? ClienteClienteDefecto
        {
            get { return Fields.ClienteClienteDefecto[this]; }
            set { Fields.ClienteClienteDefecto[this] = value; }
        }

        [DisplayName("Cliente Grupo Cliente Id"), Expression("jCliente.[grupo_cliente_id]")]
        public Int16? ClienteGrupoClienteId
        {
            get { return Fields.ClienteGrupoClienteId[this]; }
            set { Fields.ClienteGrupoClienteId[this] = value; }
        }

        [DisplayName("Cliente Tipo Documento Id"), Expression("jCliente.[tipo_documento_id]")]
        public String ClienteTipoDocumentoId
        {
            get { return Fields.ClienteTipoDocumentoId[this]; }
            set { Fields.ClienteTipoDocumentoId[this] = value; }
        }

        [DisplayName("Cliente Nif"), Expression("jCliente.[nif]")]
        public String ClienteNif
        {
            get { return Fields.ClienteNif[this]; }
            set { Fields.ClienteNif[this] = value; }
        }

        [DisplayName("Cliente Fecha Documento"), Expression("jCliente.[fecha_documento]")]
        public DateTime? ClienteFechaDocumento
        {
            get { return Fields.ClienteFechaDocumento[this]; }
            set { Fields.ClienteFechaDocumento[this] = value; }
        }

        [DisplayName("Cliente Sexo Id"), Expression("jCliente.[sexo_id]")]
        public String ClienteSexoId
        {
            get { return Fields.ClienteSexoId[this]; }
            set { Fields.ClienteSexoId[this] = value; }
        }

        [DisplayName("Cliente Direccion"), Expression("jCliente.[direccion]")]
        public String ClienteDireccion
        {
            get { return Fields.ClienteDireccion[this]; }
            set { Fields.ClienteDireccion[this] = value; }
        }

        [DisplayName("Cliente Poblacion"), Expression("jCliente.[poblacion]")]
        public String ClientePoblacion
        {
            get { return Fields.ClientePoblacion[this]; }
            set { Fields.ClientePoblacion[this] = value; }
        }

        [DisplayName("Cliente Zip"), Expression("jCliente.[zip]")]
        public String ClienteZip
        {
            get { return Fields.ClienteZip[this]; }
            set { Fields.ClienteZip[this] = value; }
        }

        [DisplayName("Cliente Nacion Id"), Expression("jCliente.[nacion_id]")]
        public Int16? ClienteNacionId
        {
            get { return Fields.ClienteNacionId[this]; }
            set { Fields.ClienteNacionId[this] = value; }
        }

        [DisplayName("Cliente Provincia Id"), Expression("jCliente.[provincia_id]")]
        public Int16? ClienteProvinciaId
        {
            get { return Fields.ClienteProvinciaId[this]; }
            set { Fields.ClienteProvinciaId[this] = value; }
        }

        [DisplayName("Cliente Cta Contable Anticipo"), Expression("jCliente.[cta_contable_anticipo]")]
        public String ClienteCtaContableAnticipo
        {
            get { return Fields.ClienteCtaContableAnticipo[this]; }
            set { Fields.ClienteCtaContableAnticipo[this] = value; }
        }

        [DisplayName("Cliente Cta Contable"), Expression("jCliente.[cta_contable]")]
        public String ClienteCtaContable
        {
            get { return Fields.ClienteCtaContable[this]; }
            set { Fields.ClienteCtaContable[this] = value; }
        }

        [DisplayName("Cliente Dpto Contable"), Expression("jCliente.[dpto_contable]")]
        public String ClienteDptoContable
        {
            get { return Fields.ClienteDptoContable[this]; }
            set { Fields.ClienteDptoContable[this] = value; }
        }

        [DisplayName("Cliente Cta Depositos"), Expression("jCliente.[cta_depositos]")]
        public String ClienteCtaDepositos
        {
            get { return Fields.ClienteCtaDepositos[this]; }
            set { Fields.ClienteCtaDepositos[this] = value; }
        }

        [DisplayName("Cliente Telefono"), Expression("jCliente.[telefono]")]
        public String ClienteTelefono
        {
            get { return Fields.ClienteTelefono[this]; }
            set { Fields.ClienteTelefono[this] = value; }
        }

        [DisplayName("Cliente Email"), Expression("jCliente.[email]")]
        public String ClienteEmail
        {
            get { return Fields.ClienteEmail[this]; }
            set { Fields.ClienteEmail[this] = value; }
        }

        [DisplayName("Cliente Fax"), Expression("jCliente.[fax]")]
        public String ClienteFax
        {
            get { return Fields.ClienteFax[this]; }
            set { Fields.ClienteFax[this] = value; }
        }

        [DisplayName("Cliente Contacto"), Expression("jCliente.[contacto]")]
        public String ClienteContacto
        {
            get { return Fields.ClienteContacto[this]; }
            set { Fields.ClienteContacto[this] = value; }
        }

        [DisplayName("Cliente Telefono Contacto"), Expression("jCliente.[telefono_contacto]")]
        public String ClienteTelefonoContacto
        {
            get { return Fields.ClienteTelefonoContacto[this]; }
            set { Fields.ClienteTelefonoContacto[this] = value; }
        }

        [DisplayName("Cliente Fax Contacto"), Expression("jCliente.[fax_contacto]")]
        public String ClienteFaxContacto
        {
            get { return Fields.ClienteFaxContacto[this]; }
            set { Fields.ClienteFaxContacto[this] = value; }
        }

        [DisplayName("Cliente Email Contacto"), Expression("jCliente.[email_contacto]")]
        public String ClienteEmailContacto
        {
            get { return Fields.ClienteEmailContacto[this]; }
            set { Fields.ClienteEmailContacto[this] = value; }
        }

        [DisplayName("Cliente Acepta Lopd"), Expression("jCliente.[acepta_lopd]")]
        public DateTime? ClienteAceptaLopd
        {
            get { return Fields.ClienteAceptaLopd[this]; }
            set { Fields.ClienteAceptaLopd[this] = value; }
        }

        [DisplayName("Cliente Cif Fra"), Expression("jCliente.[cif_fra]")]
        public String ClienteCifFra
        {
            get { return Fields.ClienteCifFra[this]; }
            set { Fields.ClienteCifFra[this] = value; }
        }

        [DisplayName("Cliente Direccion Fra"), Expression("jCliente.[direccion_fra]")]
        public String ClienteDireccionFra
        {
            get { return Fields.ClienteDireccionFra[this]; }
            set { Fields.ClienteDireccionFra[this] = value; }
        }

        [DisplayName("Cliente Poblacion Fra"), Expression("jCliente.[poblacion_fra]")]
        public String ClientePoblacionFra
        {
            get { return Fields.ClientePoblacionFra[this]; }
            set { Fields.ClientePoblacionFra[this] = value; }
        }

        [DisplayName("Cliente Zip Fra"), Expression("jCliente.[zip_fra]")]
        public String ClienteZipFra
        {
            get { return Fields.ClienteZipFra[this]; }
            set { Fields.ClienteZipFra[this] = value; }
        }

        [DisplayName("Cliente Nacion Id Factura"), Expression("jCliente.[nacion_id_factura]")]
        public Int16? ClienteNacionIdFactura
        {
            get { return Fields.ClienteNacionIdFactura[this]; }
            set { Fields.ClienteNacionIdFactura[this] = value; }
        }

        [DisplayName("Cliente Provincia Id Factura"), Expression("jCliente.[provincia_id_factura]")]
        public Int16? ClienteProvinciaIdFactura
        {
            get { return Fields.ClienteProvinciaIdFactura[this]; }
            set { Fields.ClienteProvinciaIdFactura[this] = value; }
        }

        [DisplayName("Cliente Cliente Factura"), Expression("jCliente.[Cliente_factura]")]
        public Boolean? ClienteClienteFactura
        {
            get { return Fields.ClienteClienteFactura[this]; }
            set { Fields.ClienteClienteFactura[this] = value; }
        }

        [DisplayName("Cliente Cliente Huesped"), Expression("jCliente.[Cliente_huesped]")]
        public Boolean? ClienteClienteHuesped
        {
            get { return Fields.ClienteClienteHuesped[this]; }
            set { Fields.ClienteClienteHuesped[this] = value; }
        }

        [DisplayName("Cliente Permite Credito"), Expression("jCliente.[permite_credito]")]
        public Boolean? ClientePermiteCredito
        {
            get { return Fields.ClientePermiteCredito[this]; }
            set { Fields.ClientePermiteCredito[this] = value; }
        }

        [DisplayName("Cliente Limite Credito"), Expression("jCliente.[limite_credito]")]
        public Double? ClienteLimiteCredito
        {
            get { return Fields.ClienteLimiteCredito[this]; }
            set { Fields.ClienteLimiteCredito[this] = value; }
        }

        [DisplayName("Cliente Factura Anticipada"), Expression("jCliente.[factura_anticipada]")]
        public Boolean? ClienteFacturaAnticipada
        {
            get { return Fields.ClienteFacturaAnticipada[this]; }
            set { Fields.ClienteFacturaAnticipada[this] = value; }
        }

        [DisplayName("Cliente Vencimiento Facturas Id"), Expression("jCliente.[vencimiento_facturas_id]")]
        public Int16? ClienteVencimientoFacturasId
        {
            get { return Fields.ClienteVencimientoFacturasId[this]; }
            set { Fields.ClienteVencimientoFacturasId[this] = value; }
        }

        [DisplayName("Cliente Fecha Nacimiento"), Expression("jCliente.[fecha_nacimiento]")]
        public DateTime? ClienteFechaNacimiento
        {
            get { return Fields.ClienteFechaNacimiento[this]; }
            set { Fields.ClienteFechaNacimiento[this] = value; }
        }

        [DisplayName("Cliente User Id"), Expression("jCliente.[user_id]")]
        public Int16? ClienteUserId
        {
            get { return Fields.ClienteUserId[this]; }
            set { Fields.ClienteUserId[this] = value; }
        }

        [DisplayName("Cliente Fecha Modificacion"), Expression("jCliente.[fecha_modificacion]")]
        public DateTime? ClienteFechaModificacion
        {
            get { return Fields.ClienteFechaModificacion[this]; }
            set { Fields.ClienteFechaModificacion[this] = value; }
        }

        [DisplayName("Cliente Cliente Bavel"), Expression("jCliente.[cliente_bavel]")]
        public String ClienteClienteBavel
        {
            get { return Fields.ClienteClienteBavel[this]; }
            set { Fields.ClienteClienteBavel[this] = value; }
        }

        [DisplayName("Cliente Foto1"), Expression("jCliente.[foto1]")]
        public String ClienteFoto1
        {
            get { return Fields.ClienteFoto1[this]; }
            set { Fields.ClienteFoto1[this] = value; }
        }

        [DisplayName("Cliente Foto2"), Expression("jCliente.[foto2]")]
        public String ClienteFoto2
        {
            get { return Fields.ClienteFoto2[this]; }
            set { Fields.ClienteFoto2[this] = value; }
        }

        [DisplayName("Cliente Dingus Extras"), Expression("jCliente.[dingus_extras]")]
        public Boolean? ClienteDingusExtras
        {
            get { return Fields.ClienteDingusExtras[this]; }
            set { Fields.ClienteDingusExtras[this] = value; }
        }

        [DisplayName("Cliente Id Clubhd"), Expression("jCliente.[id_clubhd]")]
        public String ClienteIdClubhd
        {
            get { return Fields.ClienteIdClubhd[this]; }
            set { Fields.ClienteIdClubhd[this] = value; }
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
        public Decimal? HotelLng
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
            public Int16Field UserId;
            public DateTimeField FechaModificacion;

            public StringField ClienteRazon;
            public StringField ClienteDescCorta;
            public StringField ClienteNombre;
            public StringField ClienteApellidos;
            public Int16Field ClienteEmpresaId;
            public Int32Field ClienteAgenciaId;
            public Int16Field ClienteMercadoId;
            public BooleanField ClienteClienteDefecto;
            public Int16Field ClienteGrupoClienteId;
            public StringField ClienteTipoDocumentoId;
            public StringField ClienteNif;
            public DateTimeField ClienteFechaDocumento;
            public StringField ClienteSexoId;
            public StringField ClienteDireccion;
            public StringField ClientePoblacion;
            public StringField ClienteZip;
            public Int16Field ClienteNacionId;
            public Int16Field ClienteProvinciaId;
            public StringField ClienteCtaContableAnticipo;
            public StringField ClienteCtaContable;
            public StringField ClienteDptoContable;
            public StringField ClienteCtaDepositos;
            public StringField ClienteTelefono;
            public StringField ClienteEmail;
            public StringField ClienteFax;
            public StringField ClienteContacto;
            public StringField ClienteTelefonoContacto;
            public StringField ClienteFaxContacto;
            public StringField ClienteEmailContacto;
            public DateTimeField ClienteAceptaLopd;
            public StringField ClienteCifFra;
            public StringField ClienteDireccionFra;
            public StringField ClientePoblacionFra;
            public StringField ClienteZipFra;
            public Int16Field ClienteNacionIdFactura;
            public Int16Field ClienteProvinciaIdFactura;
            public BooleanField ClienteClienteFactura;
            public BooleanField ClienteClienteHuesped;
            public BooleanField ClientePermiteCredito;
            public DoubleField ClienteLimiteCredito;
            public BooleanField ClienteFacturaAnticipada;
            public Int16Field ClienteVencimientoFacturasId;
            public DateTimeField ClienteFechaNacimiento;
            public Int16Field ClienteUserId;
            public DateTimeField ClienteFechaModificacion;
            public StringField ClienteClienteBavel;
            public StringField ClienteFoto1;
            public StringField ClienteFoto2;
            public BooleanField ClienteDingusExtras;
            public StringField ClienteIdClubhd;

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
            public DecimalField HotelLng;
            public Int16Field HotelAncho;
            public Int16Field HotelAlto;
            public DoubleField HotelOverbookingLimit;

            public RowFields()
                : base("[dbo].[releases]")
            {
                LocalTextPrefix = "Contratos.Releases";
            }
        }
    }
}
