﻿namespace Geshotel.Contratos {
    export interface ReleasesRow {
        ReleaseId?: number;
        ClienteId?: number;
        HotelId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Observaciones?: string;
        Dias?: number;
        UserId?: number;
        FechaModificacion?: string;
        ClienteRazon?: string;
        ClienteDescCorta?: string;
        ClienteNombre?: string;
        ClienteApellidos?: string;
        ClienteEmpresaId?: number;
        ClienteAgenciaId?: number;
        ClienteMercadoId?: number;
        ClienteClienteDefecto?: boolean;
        ClienteGrupoClienteId?: number;
        ClienteTipoDocumentoId?: string;
        ClienteNif?: string;
        ClienteFechaDocumento?: string;
        ClienteSexoId?: string;
        ClienteDireccion?: string;
        ClientePoblacion?: string;
        ClienteZip?: string;
        ClienteNacionId?: number;
        ClienteProvinciaId?: number;
        ClienteCtaContableAnticipo?: string;
        ClienteCtaContable?: string;
        ClienteDptoContable?: string;
        ClienteCtaDepositos?: string;
        ClienteTelefono?: string;
        ClienteEmail?: string;
        ClienteFax?: string;
        ClienteContacto?: string;
        ClienteTelefonoContacto?: string;
        ClienteFaxContacto?: string;
        ClienteEmailContacto?: string;
        ClienteAceptaLopd?: string;
        ClienteCifFra?: string;
        ClienteDireccionFra?: string;
        ClientePoblacionFra?: string;
        ClienteZipFra?: string;
        ClienteNacionIdFactura?: number;
        ClienteProvinciaIdFactura?: number;
        ClienteClienteFactura?: boolean;
        ClienteClienteHuesped?: boolean;
        ClientePermiteCredito?: boolean;
        ClienteLimiteCredito?: number;
        ClienteFacturaAnticipada?: boolean;
        ClienteVencimientoFacturasId?: number;
        ClienteFechaNacimiento?: string;
        ClienteUserId?: number;
        ClienteFechaModificacion?: string;
        ClienteClienteBavel?: string;
        ClienteFoto1?: string;
        ClienteFoto2?: string;
        ClienteDingusExtras?: boolean;
        ClienteIdClubhd?: string;
        Hotel?: string;
        HotelEmpresaId?: number;
        HotelTipoHotelId?: number;
        HotelCategoriaId?: number;
        HotelNombreCorto?: string;
        HotelDireccion?: string;
        HotelPoblacion?: string;
        HotelZip?: string;
        HotelProvinciaId?: number;
        HotelNacionId?: number;
        HotelTelefono?: string;
        HotelFax?: string;
        HotelCtaManocorriente?: string;
        HotelDptoContable?: string;
        HotelCtaContableCajas?: string;
        HotelCtaContableBanco?: string;
        HotelFechaInicioPrograma?: string;
        HotelRutaFicheroPolicia?: string;
        HotelContadorFicheroPolicia?: number;
        HotelIdentificadorFicheroPolicia?: string;
        HotelEmailReservas?: string;
        HotelEmailVentas?: string;
        HotelEmailSmtp?: string;
        HotelTextoCancelacion?: string;
        HotelUsuarioIsta?: string;
        HotelPasswordIsta?: string;
        HotelUrlIsta?: string;
        HotelMunicipioIsta?: string;
        HotelNumeroRegistroIsta?: number;
        HotelRutaBavel?: string;
        HotelDingusUsuario?: string;
        HotelDingusPassword?: string;
        HotelDingusHotelCode?: string;
        HotelDingusTraductor?: string;
        HotelDingusUrl?: string;
        HotelCheckinOnLine?: number;
        HotelMinimoDiasCheckinOnline?: number;
        HotelZoomMapa?: number;
        HotelLat?: number;
        HotelLng?: number;
        HotelAncho?: number;
        HotelAlto?: number;
        HotelOverbookingLimit?: number;
    }

    export namespace ReleasesRow {
        export const idProperty = 'ReleaseId';
        export const nameProperty = 'Observaciones';
        export const localTextPrefix = 'Contratos.Releases';

        export namespace Fields {
            export declare const ReleaseId: string;
            export declare const ClienteId: string;
            export declare const HotelId: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
            export declare const Observaciones: string;
            export declare const Dias: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const ClienteRazon: string;
            export declare const ClienteDescCorta: string;
            export declare const ClienteNombre: string;
            export declare const ClienteApellidos: string;
            export declare const ClienteEmpresaId: string;
            export declare const ClienteAgenciaId: string;
            export declare const ClienteMercadoId: string;
            export declare const ClienteClienteDefecto: string;
            export declare const ClienteGrupoClienteId: string;
            export declare const ClienteTipoDocumentoId: string;
            export declare const ClienteNif: string;
            export declare const ClienteFechaDocumento: string;
            export declare const ClienteSexoId: string;
            export declare const ClienteDireccion: string;
            export declare const ClientePoblacion: string;
            export declare const ClienteZip: string;
            export declare const ClienteNacionId: string;
            export declare const ClienteProvinciaId: string;
            export declare const ClienteCtaContableAnticipo: string;
            export declare const ClienteCtaContable: string;
            export declare const ClienteDptoContable: string;
            export declare const ClienteCtaDepositos: string;
            export declare const ClienteTelefono: string;
            export declare const ClienteEmail: string;
            export declare const ClienteFax: string;
            export declare const ClienteContacto: string;
            export declare const ClienteTelefonoContacto: string;
            export declare const ClienteFaxContacto: string;
            export declare const ClienteEmailContacto: string;
            export declare const ClienteAceptaLopd: string;
            export declare const ClienteCifFra: string;
            export declare const ClienteDireccionFra: string;
            export declare const ClientePoblacionFra: string;
            export declare const ClienteZipFra: string;
            export declare const ClienteNacionIdFactura: string;
            export declare const ClienteProvinciaIdFactura: string;
            export declare const ClienteClienteFactura: string;
            export declare const ClienteClienteHuesped: string;
            export declare const ClientePermiteCredito: string;
            export declare const ClienteLimiteCredito: string;
            export declare const ClienteFacturaAnticipada: string;
            export declare const ClienteVencimientoFacturasId: string;
            export declare const ClienteFechaNacimiento: string;
            export declare const ClienteUserId: string;
            export declare const ClienteFechaModificacion: string;
            export declare const ClienteClienteBavel: string;
            export declare const ClienteFoto1: string;
            export declare const ClienteFoto2: string;
            export declare const ClienteDingusExtras: string;
            export declare const ClienteIdClubhd: string;
            export declare const Hotel: string;
            export declare const HotelEmpresaId: string;
            export declare const HotelTipoHotelId: string;
            export declare const HotelCategoriaId: string;
            export declare const HotelNombreCorto: string;
            export declare const HotelDireccion: string;
            export declare const HotelPoblacion: string;
            export declare const HotelZip: string;
            export declare const HotelProvinciaId: string;
            export declare const HotelNacionId: string;
            export declare const HotelTelefono: string;
            export declare const HotelFax: string;
            export declare const HotelCtaManocorriente: string;
            export declare const HotelDptoContable: string;
            export declare const HotelCtaContableCajas: string;
            export declare const HotelCtaContableBanco: string;
            export declare const HotelFechaInicioPrograma: string;
            export declare const HotelRutaFicheroPolicia: string;
            export declare const HotelContadorFicheroPolicia: string;
            export declare const HotelIdentificadorFicheroPolicia: string;
            export declare const HotelEmailReservas: string;
            export declare const HotelEmailVentas: string;
            export declare const HotelEmailSmtp: string;
            export declare const HotelTextoCancelacion: string;
            export declare const HotelUsuarioIsta: string;
            export declare const HotelPasswordIsta: string;
            export declare const HotelUrlIsta: string;
            export declare const HotelMunicipioIsta: string;
            export declare const HotelNumeroRegistroIsta: string;
            export declare const HotelRutaBavel: string;
            export declare const HotelDingusUsuario: string;
            export declare const HotelDingusPassword: string;
            export declare const HotelDingusHotelCode: string;
            export declare const HotelDingusTraductor: string;
            export declare const HotelDingusUrl: string;
            export declare const HotelCheckinOnLine: string;
            export declare const HotelMinimoDiasCheckinOnline: string;
            export declare const HotelZoomMapa: string;
            export declare const HotelLat: string;
            export declare const HotelLng: string;
            export declare const HotelAncho: string;
            export declare const HotelAlto: string;
            export declare const HotelOverbookingLimit: string;
        }

        ['ReleaseId', 'ClienteId', 'HotelId', 'FechaDesde', 'FechaHasta', 'Observaciones', 'Dias', 'UserId', 'FechaModificacion', 'ClienteRazon', 'ClienteDescCorta', 'ClienteNombre', 'ClienteApellidos', 'ClienteEmpresaId', 'ClienteAgenciaId', 'ClienteMercadoId', 'ClienteClienteDefecto', 'ClienteGrupoClienteId', 'ClienteTipoDocumentoId', 'ClienteNif', 'ClienteFechaDocumento', 'ClienteSexoId', 'ClienteDireccion', 'ClientePoblacion', 'ClienteZip', 'ClienteNacionId', 'ClienteProvinciaId', 'ClienteCtaContableAnticipo', 'ClienteCtaContable', 'ClienteDptoContable', 'ClienteCtaDepositos', 'ClienteTelefono', 'ClienteEmail', 'ClienteFax', 'ClienteContacto', 'ClienteTelefonoContacto', 'ClienteFaxContacto', 'ClienteEmailContacto', 'ClienteAceptaLopd', 'ClienteCifFra', 'ClienteDireccionFra', 'ClientePoblacionFra', 'ClienteZipFra', 'ClienteNacionIdFactura', 'ClienteProvinciaIdFactura', 'ClienteClienteFactura', 'ClienteClienteHuesped', 'ClientePermiteCredito', 'ClienteLimiteCredito', 'ClienteFacturaAnticipada', 'ClienteVencimientoFacturasId', 'ClienteFechaNacimiento', 'ClienteUserId', 'ClienteFechaModificacion', 'ClienteClienteBavel', 'ClienteFoto1', 'ClienteFoto2', 'ClienteDingusExtras', 'ClienteIdClubhd', 'Hotel', 'HotelEmpresaId', 'HotelTipoHotelId', 'HotelCategoriaId', 'HotelNombreCorto', 'HotelDireccion', 'HotelPoblacion', 'HotelZip', 'HotelProvinciaId', 'HotelNacionId', 'HotelTelefono', 'HotelFax', 'HotelCtaManocorriente', 'HotelDptoContable', 'HotelCtaContableCajas', 'HotelCtaContableBanco', 'HotelFechaInicioPrograma', 'HotelRutaFicheroPolicia', 'HotelContadorFicheroPolicia', 'HotelIdentificadorFicheroPolicia', 'HotelEmailReservas', 'HotelEmailVentas', 'HotelEmailSmtp', 'HotelTextoCancelacion', 'HotelUsuarioIsta', 'HotelPasswordIsta', 'HotelUrlIsta', 'HotelMunicipioIsta', 'HotelNumeroRegistroIsta', 'HotelRutaBavel', 'HotelDingusUsuario', 'HotelDingusPassword', 'HotelDingusHotelCode', 'HotelDingusTraductor', 'HotelDingusUrl', 'HotelCheckinOnLine', 'HotelMinimoDiasCheckinOnline', 'HotelZoomMapa', 'HotelLat', 'HotelLng', 'HotelAncho', 'HotelAlto', 'HotelOverbookingLimit'].forEach(x => (<any>Fields)[x] = x);
    }
}

