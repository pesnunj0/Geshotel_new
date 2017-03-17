namespace Geshotel.Portal {
    export interface TiposServicioRow {
        TipoServicioId?: number;
        NombreTipoServicio?: string;
    }

    export namespace TiposServicioRow {
        export const idProperty = 'TipoServicioId';
        export const nameProperty = 'NombreTipoServicio';
        export const localTextPrefix = 'Portal.TiposServicio';
        export const lookupKey = 'Portal.TiposServicio';

        export function getLookup(): Q.Lookup<TiposServicioRow> {
            return Q.getLookup<TiposServicioRow>('Portal.TiposServicio');
        }

        export namespace Fields {
            export declare const TipoServicioId: string;
            export declare const NombreTipoServicio: string;
        }

        ['TipoServicioId', 'NombreTipoServicio'].forEach(x => (<any>Fields)[x] = x);
    }
}

