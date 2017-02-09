
namespace Geshotel.Portal {
    export interface TiposDeImputacionRow {
        TipoImputacionId?: number;
        Imputacion?: string;
    }

    export namespace TiposDeImputacionRow {
        export const idProperty = 'TipoImputacionId';
        export const nameProperty = 'Imputacion';
        export const localTextPrefix = 'Portal.TiposDeImputacion';

        export namespace Fields {
            export declare const TipoImputacionId;
            export declare const Imputacion;
        }

        ['TipoImputacionId', 'Imputacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

