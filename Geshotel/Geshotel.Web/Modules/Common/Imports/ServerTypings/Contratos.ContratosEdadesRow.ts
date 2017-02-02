
namespace Geshotel.Contratos {
    export interface ContratosEdadesRow {
        ContratoId?: number;
        TipoHuespedId?: number;
        EdadMinima?: number;
        EdadMaxima?: number;
        UserId?: number;
    }

    export namespace ContratosEdadesRow {
        export const idProperty = 'ContratoId';
        export const localTextPrefix = 'Contratos.ContratosEdades';

        export namespace Fields {
            export declare const ContratoId;
            export declare const TipoHuespedId;
            export declare const EdadMinima;
            export declare const EdadMaxima;
            export declare const UserId;
        }

        ['ContratoId', 'TipoHuespedId', 'EdadMinima', 'EdadMaxima', 'UserId'].forEach(x => (<any>Fields)[x] = x);
    }
}

