namespace Geshotel.Contratos {
    export interface TiposDeImputacionRow {
        TipoImputacionId?: number;
        Imputacion?: string;
    }

    export namespace TiposDeImputacionRow {
        export const idProperty = 'TipoImputacionId';
        export const nameProperty = 'Imputacion';
        export const localTextPrefix = 'Contratos.TiposDeImputacion';
        export const lookupKey = 'Contratos.TiposDeImputacion';

        export function getLookup(): Q.Lookup<TiposDeImputacionRow> {
            return Q.getLookup<TiposDeImputacionRow>('Contratos.TiposDeImputacion');
        }

        export namespace Fields {
            export declare const TipoImputacionId: string;
            export declare const Imputacion: string;
        }

        ['TipoImputacionId', 'Imputacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

