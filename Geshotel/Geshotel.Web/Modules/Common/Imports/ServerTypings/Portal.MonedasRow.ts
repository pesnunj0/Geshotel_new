namespace Geshotel.Portal {
    export interface MonedasRow {
        MonedaId?: number;
        DescCorta?: string;
        Descripcion?: string;
        Cambio?: number;
    }

    export namespace MonedasRow {
        export const idProperty = 'MonedaId';
        export const nameProperty = 'Descripcion';
        export const localTextPrefix = 'Portal.Monedas';
        export const lookupKey = 'Portal.Monedas';

        export function getLookup(): Q.Lookup<MonedasRow> {
            return Q.getLookup<MonedasRow>('Portal.Monedas');
        }

        export namespace Fields {
            export declare const MonedaId: string;
            export declare const DescCorta: string;
            export declare const Descripcion: string;
            export declare const Cambio: string;
        }

        ['MonedaId', 'DescCorta', 'Descripcion', 'Cambio'].forEach(x => (<any>Fields)[x] = x);
    }
}

