namespace Geshotel.Contratos {
    export interface TiposCondicionRow {
        TipoCondicionId?: number;
        Condicion?: string;
        Literal?: string;
    }

    export namespace TiposCondicionRow {
        export const idProperty = 'TipoCondicionId';
        export const nameProperty = 'Literal';
        export const localTextPrefix = 'Contratos.TiposCondicion';
        export const lookupKey = 'Contratos.TiposCondicion';

        export function getLookup(): Q.Lookup<TiposCondicionRow> {
            return Q.getLookup<TiposCondicionRow>('Contratos.TiposCondicion');
        }

        export namespace Fields {
            export declare const TipoCondicionId: string;
            export declare const Condicion: string;
            export declare const Literal: string;
        }

        ['TipoCondicionId', 'Condicion', 'Literal'].forEach(x => (<any>Fields)[x] = x);
    }
}

