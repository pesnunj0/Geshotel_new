
namespace Geshotel.Contratos {
    export interface EdadesRow {
        ContratoId?: number;
        TipoHuespedId?: number;
        EdadMinima?: number;
        EdadMaxima?: number;
        UserId?: number;
    }

    export namespace EdadesRow {
        export const idProperty = 'ContratoId';
        export const localTextPrefix = 'Contratos.Edades';

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

