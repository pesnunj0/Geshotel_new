
namespace Geshotel.Portal {
    export interface TiposDeImputacionRow {
        TipoImputacionId?: number;
        Imputacion?: string;
    }

    export namespace TiposDeImputacionRow {
        export const idProperty = 'TipoImputacionId';
        export const nameProperty = 'Imputacion';
        export const localTextPrefix = 'Portal.TiposDeImputacion';
        export const lookupKey = 'Portal.TiposDeImputacion';

        export function getLookup(): Q.Lookup<TiposDeImputacionRow> {
            return Q.getLookup<TiposDeImputacionRow>('Portal.TiposDeImputacion');
        }

        export namespace Fields {
            export declare const TipoImputacionId: string;
            export declare const Imputacion: string;
        }

        ['TipoImputacionId', 'Imputacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

