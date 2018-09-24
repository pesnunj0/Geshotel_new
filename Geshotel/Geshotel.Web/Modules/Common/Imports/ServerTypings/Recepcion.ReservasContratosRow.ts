
namespace Geshotel.Recepcion {
    export interface ReservasContratosRow {
        ReservaContratoId?: number;
        ReservaId?: number;
        ContratoId?: number;
        Directo?: boolean;
        FechaDesde?: string;
        FechaHasta?: string;
        ClienteId?: number;
        ClienteName?: string;
    }

    export namespace ReservasContratosRow {
        export const idProperty = 'ReservaContratoId';
        export const localTextPrefix = 'Recepcion.ReservasContratos';

        export namespace Fields {
            export declare const ReservaContratoId: string;
            export declare const ReservaId: string;
            export declare const ContratoId: string;
            export declare const Directo: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
            export declare const ClienteId: string;
            export declare const ClienteName: string;
        }

        [
            'ReservaContratoId', 
            'ReservaId', 
            'ContratoId', 
            'Directo', 
            'FechaDesde', 
            'FechaHasta', 
            'ClienteId', 
            'ClienteName'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

