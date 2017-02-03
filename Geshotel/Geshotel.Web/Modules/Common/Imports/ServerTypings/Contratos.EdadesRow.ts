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
            export declare const ContratoId: string;
            export declare const TipoHuespedId: string;
            export declare const EdadMinima: string;
            export declare const EdadMaxima: string;
            export declare const UserId: string;
        }

        ['ContratoId', 'TipoHuespedId', 'EdadMinima', 'EdadMaxima', 'UserId'].forEach(x => (<any>Fields)[x] = x);
    }
}

