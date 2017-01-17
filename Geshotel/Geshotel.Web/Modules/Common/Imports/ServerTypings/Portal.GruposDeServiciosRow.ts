namespace Geshotel.Portal {
    export interface GruposDeServiciosRow {
        GrupoServicioId?: number;
        HotelId?: number;
        NombreGrupo?: string;
        CtaContable?: string;
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

    export namespace GruposDeServiciosRow {
        export const idProperty = 'GrupoServicioId';
        export const nameProperty = 'NombreGrupo';
        export const localTextPrefix = 'Portal.GruposDeServicios';
        export const lookupKey = 'Portal.GruposDeServicio';

        export function getLookup(): Q.Lookup<GruposDeServiciosRow> {
            return Q.getLookup<GruposDeServiciosRow>('Portal.GruposDeServicio');
        }

        export namespace Fields {
            export declare const GrupoServicioId: string;
            export declare const HotelId: string;
            export declare const NombreGrupo: string;
            export declare const CtaContable: string;
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

        ['GrupoServicioId', 'HotelId', 'NombreGrupo', 'CtaContable', 'Hotel', 'HotelEmpresaId', 'HotelTipoHotelId', 'HotelCategoriaId', 'HotelNombreCorto', 'HotelDireccion', 'HotelPoblacion', 'HotelZip', 'HotelProvinciaId', 'HotelNacionId', 'HotelTelefono', 'HotelFax', 'HotelCtaManocorriente', 'HotelDptoContable', 'HotelCtaContableCajas', 'HotelCtaContableBanco', 'HotelFechaInicioPrograma', 'HotelRutaFicheroPolicia', 'HotelContadorFicheroPolicia', 'HotelIdentificadorFicheroPolicia', 'HotelEmailReservas', 'HotelEmailVentas', 'HotelEmailSmtp', 'HotelTextoCancelacion', 'HotelUsuarioIsta', 'HotelPasswordIsta', 'HotelUrlIsta', 'HotelMunicipioIsta', 'HotelNumeroRegistroIsta', 'HotelRutaBavel', 'HotelDingusUsuario', 'HotelDingusPassword', 'HotelDingusHotelCode', 'HotelDingusTraductor', 'HotelDingusUrl', 'HotelCheckinOnLine', 'HotelMinimoDiasCheckinOnline', 'HotelZoomMapa', 'HotelLat', 'HotelLng', 'HotelAncho', 'HotelAlto', 'HotelOverbookingLimit'].forEach(x => (<any>Fields)[x] = x);
    }
}

