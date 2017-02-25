
namespace Geshotel.Reservas {
    export interface ReservasContratosRow {
        ReservaContratoId?: number;
        ReservaId?: number;
        ContratoId?: number;
        Directo?: number;
    }

    export namespace ReservasContratosRow {
        export const idProperty = 'ReservaContratoId';
        export const localTextPrefix = 'Reservas.ReservasContratos';

        export namespace Fields {
            export declare const ReservaContratoId;
            export declare const ReservaId;
            export declare const ContratoId;
            export declare const Directo;
        }

        ['ReservaContratoId', 'ReservaId', 'ContratoId', 'Directo'].forEach(x => (<any>Fields)[x] = x);
    }
}

