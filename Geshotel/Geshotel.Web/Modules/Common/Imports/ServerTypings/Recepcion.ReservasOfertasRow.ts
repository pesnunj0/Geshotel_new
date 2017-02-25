
namespace Geshotel.Recepcion {
    export interface ReservasOfertasRow {
        ReservaOfertaId?: number;
        ReservaId?: number;
        OfertaId?: number;
        Tipo?: string;
        Activa?: number;
        OfertaUsada?: number;
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
        }

        ['ReservaOfertaId', 'ReservaId', 'OfertaId', 'Tipo', 'Activa', 'OfertaUsada'].forEach(x => (<any>Fields)[x] = x);
    }
}

