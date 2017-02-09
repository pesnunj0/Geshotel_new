
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

        export namespace Fields {
            export declare const TipoCondicionId;
            export declare const Condicion;
            export declare const Literal;
        }

        ['TipoCondicionId', 'Condicion', 'Literal'].forEach(x => (<any>Fields)[x] = x);
    }
}

