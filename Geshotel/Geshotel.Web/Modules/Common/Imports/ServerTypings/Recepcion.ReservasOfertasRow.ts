
namespace Geshotel.Recepcion {
    export interface ReservasOfertasRow {
        ReservaOfertaId?: number;
        ReservaId?: number;
        OfertaId?: number;
        Tipo?: string;
        Activa?: boolean;
        OfertaUsada?: boolean;
        UnidadCalculoId?: number;
        Texto?: string;
        N?: number;
        TipoOfertaId?: number;
        M?: number;
        TipoOfertaName?: string;
        UnidadCalculoName?: string;
    }

    export namespace ReservasOfertasRow {
        export const idProperty = 'ReservaOfertaId';
        export const nameProperty = 'Tipo';
        export const localTextPrefix = 'Recepcion.ReservasOfertas';

        export namespace Fields {
            export declare const ReservaOfertaId: string;
            export declare const ReservaId: string;
            export declare const OfertaId: string;
            export declare const Tipo: string;
            export declare const Activa: string;
            export declare const OfertaUsada: string;
            export declare const UnidadCalculoId: string;
            export declare const Texto: string;
            export declare const N: string;
            export declare const TipoOfertaId: string;
            export declare const M: string;
            export declare const TipoOfertaName: string;
            export declare const UnidadCalculoName: string;
        }

        [
            'ReservaOfertaId', 
            'ReservaId', 
            'OfertaId', 
            'Tipo', 
            'Activa', 
            'OfertaUsada', 
            'UnidadCalculoId', 
            'Texto', 
            'N', 
            'TipoOfertaId', 
            'M', 
            'TipoOfertaName', 
            'UnidadCalculoName'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

