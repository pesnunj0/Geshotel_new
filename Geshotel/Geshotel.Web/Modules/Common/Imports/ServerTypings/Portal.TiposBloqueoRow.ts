
namespace Geshotel.Portal {
    export interface TiposBloqueoRow {
        TipoBloqueoId?: number;
        Descriptivo?: string;
        Editable?: boolean;
    }

    export namespace TiposBloqueoRow {
        export const idProperty = 'TipoBloqueoId';
        export const nameProperty = 'Descriptivo';
        export const localTextPrefix = 'Portal.TiposBloqueo';
        export const lookupKey = 'Portal.TiposBloqueo';

        export function getLookup(): Q.Lookup<TiposBloqueoRow> {
            return Q.getLookup<TiposBloqueoRow>('Portal.TiposBloqueo');
        }

        export namespace Fields {
            export declare const TipoBloqueoId: string;
            export declare const Descriptivo: string;
            export declare const Editable: string;
        }

        ['TipoBloqueoId', 'Descriptivo', 'Editable'].forEach(x => (<any>Fields)[x] = x);
    }
}

