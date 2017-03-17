namespace Geshotel.Recepcion {
    export interface ReservasContratosRow {
        ReservaContratoId?: number;
        ReservaId?: number;
        ContratoId?: number;
        Directo?: number;
    }

    export namespace ReservasContratosRow {
        export const idProperty = 'ReservaContratoId';
        export const localTextPrefix = 'Recepcion.ReservasContratos';

        export namespace Fields {
            export declare const ReservaContratoId: string;
            export declare const ReservaId: string;
            export declare const ContratoId: string;
            export declare const Directo: string;
        }

        ['ReservaContratoId', 'ReservaId', 'ContratoId', 'Directo'].forEach(x => (<any>Fields)[x] = x);
    }
}

