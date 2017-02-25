
namespace Geshotel.Reservas {
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
        export const localTextPrefix = 'Reservas.ReservasOfertas';

        export namespace Fields {
            export declare const ReservaOfertaId;
            export declare const ReservaId;
            export declare const OfertaId;
            export declare const Tipo;
            export declare const Activa;
            export declare const OfertaUsada;
        }

        ['ReservaOfertaId', 'ReservaId', 'OfertaId', 'Tipo', 'Activa', 'OfertaUsada'].forEach(x => (<any>Fields)[x] = x);
    }
}

