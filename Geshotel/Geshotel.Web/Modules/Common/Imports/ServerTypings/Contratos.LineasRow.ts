namespace Geshotel.Contratos {
    export interface LineasRow {
        LineaContratoId?: number;
        ContratoId?: number;
        Oferta?: boolean;
        Desde?: string;
        Hasta?: string;
        ServicioId?: number;
        UnidadCalculoId?: number;
        FrecuenciaId?: number;
        TipoImputacionId?: number;
        Importe?: number;
        TipoServicioId?: number;
        Lunes?: boolean;
        Martes?: boolean;
        Miercoles?: boolean;
        Jueves?: boolean;
        Viernes?: boolean;
        Sabado?: boolean;
        Domingo?: boolean;
        PagFactura?: number;
        UserId?: number;
        FechaModificacion?: string;
        Servicio?: string;
        UnidadCalculo?: string;
        Frecuencia?: string;
        Imputacion?: string;
        Usuario?: string;
        TipoServicio?: string;
    }

    export namespace LineasRow {
        export const idProperty = 'LineaContratoId';
        export const localTextPrefix = 'Contratos.Lineas';

        export namespace Fields {
            export declare const LineaContratoId: string;
            export declare const ContratoId: string;
            export declare const Oferta: string;
            export declare const Desde: string;
            export declare const Hasta: string;
            export declare const ServicioId: string;
            export declare const UnidadCalculoId: string;
            export declare const FrecuenciaId: string;
            export declare const TipoImputacionId: string;
            export declare const Importe: string;
            export declare const TipoServicioId: string;
            export declare const Lunes: string;
            export declare const Martes: string;
            export declare const Miercoles: string;
            export declare const Jueves: string;
            export declare const Viernes: string;
            export declare const Sabado: string;
            export declare const Domingo: string;
            export declare const PagFactura: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const Servicio: string;
            export declare const UnidadCalculo: string;
            export declare const Frecuencia: string;
            export declare const Imputacion: string;
            export declare const Usuario: string;
            export declare const TipoServicio: string;
        }

        ['LineaContratoId', 'ContratoId', 'Oferta', 'Desde', 'Hasta', 'ServicioId', 'UnidadCalculoId', 'FrecuenciaId', 'TipoImputacionId', 'Importe', 'TipoServicioId', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado', 'Domingo', 'PagFactura', 'UserId', 'FechaModificacion', 'Servicio', 'UnidadCalculo', 'Frecuencia', 'Imputacion', 'Usuario', 'TipoServicio'].forEach(x => (<any>Fields)[x] = x);
    }
}

