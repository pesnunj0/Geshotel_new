
namespace Geshotel.Portal {
    export interface TiposUnidadCalculoRow {
        UnidadCalculoId?: number;
        Uc?: string;
    }

    export namespace TiposUnidadCalculoRow {
        export const idProperty = 'UnidadCalculoId';
        export const nameProperty = 'Uc';
        export const localTextPrefix = 'Portal.TiposUnidadCalculo';
        export const lookupKey = 'Portal.TiposUnidadCalculo';

        export function getLookup(): Q.Lookup<TiposUnidadCalculoRow> {
            return Q.getLookup<TiposUnidadCalculoRow>('Portal.TiposUnidadCalculo');
        }

        export namespace Fields {
            export declare const UnidadCalculoId: string;
            export declare const Uc: string;
        }

        [
            'UnidadCalculoId', 
            'Uc'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

