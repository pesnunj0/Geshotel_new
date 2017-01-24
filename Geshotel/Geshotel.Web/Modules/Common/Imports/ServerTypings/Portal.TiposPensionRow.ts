namespace Geshotel.Portal {
    export interface TiposPensionRow {
        TipoPensionId?: number;
        TipoPension?: string;
    }

    export namespace TiposPensionRow {
        export const idProperty = 'TipoPensionId';
        export const nameProperty = 'TipoPension';
        export const localTextPrefix = 'Portal.TiposPension';
        export const lookupKey = 'Portal.TiposPension';

        export function getLookup(): Q.Lookup<TiposPensionRow> {
            return Q.getLookup<TiposPensionRow>('Portal.TiposPension');
        }

        export namespace Fields {
            export declare const TipoPensionId: string;
            export declare const TipoPension: string;
        }

        ['TipoPensionId', 'TipoPension'].forEach(x => (<any>Fields)[x] = x);
    }
}

