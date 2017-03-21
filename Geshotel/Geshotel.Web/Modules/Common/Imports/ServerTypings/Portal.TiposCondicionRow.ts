
namespace Geshotel.Portal {
    export interface TiposCondicionRow {
        TipoCondicionId?: number;
        Condicion?: string;
        Literal?: string;
    }

    export namespace TiposCondicionRow {
        export const idProperty = 'TipoCondicionId';
        export const nameProperty = 'Condicion';
        export const localTextPrefix = 'Portal.TiposCondicion';
        export const lookupKey = 'Portal.TiposCondicion';

        export function getLookup(): Q.Lookup<TiposCondicionRow> {
            return Q.getLookup<TiposCondicionRow>('Portal.TiposCondicion');
        }

        export namespace Fields {
            export declare const TipoCondicionId: string;
            export declare const Condicion: string;
            export declare const Literal: string;
        }

        ['TipoCondicionId', 'Condicion', 'Literal'].forEach(x => (<any>Fields)[x] = x);
    }
}

