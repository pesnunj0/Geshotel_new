
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
        N?: number;
        TipoOfertaId?: number;
        M?: number;
        AmbitoOfertaId?: number;
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
    }

    export namespace LineasRow {
        export const idProperty = 'LineaContratoId';
        export const localTextPrefix = 'Contratos.Lineas';

        export namespace Fields {
            export declare const LineaContratoId;
            export declare const ContratoId;
            export declare const Oferta;
            export declare const Desde;
            export declare const Hasta;
            export declare const ServicioId;
            export declare const UnidadCalculoId;
            export declare const FrecuenciaId;
            export declare const TipoImputacionId;
            export declare const Importe;
            export declare const N;
            export declare const TipoOfertaId;
            export declare const M;
            export declare const AmbitoOfertaId;
            export declare const Lunes;
            export declare const Martes;
            export declare const Miercoles;
            export declare const Jueves;
            export declare const Viernes;
            export declare const Sabado;
            export declare const Domingo;
            export declare const PagFactura;
            export declare const UserId;
            export declare const FechaModificacion;
        }

        ['LineaContratoId', 'ContratoId', 'Oferta', 'Desde', 'Hasta', 'ServicioId', 'UnidadCalculoId', 'FrecuenciaId', 'TipoImputacionId', 'Importe', 'N', 'TipoOfertaId', 'M', 'AmbitoOfertaId', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado', 'Domingo', 'PagFactura', 'UserId', 'FechaModificacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

