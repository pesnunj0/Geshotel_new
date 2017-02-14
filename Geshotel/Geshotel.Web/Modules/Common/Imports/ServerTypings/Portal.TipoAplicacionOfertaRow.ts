
namespace Geshotel.Portal {
    export interface TipoAplicacionOfertaRow {
        TipoAplicacionOfertaId?: string;
        AplicableSegunFechaDe?: string;
    }

    export namespace TipoAplicacionOfertaRow {
        export const idProperty = 'TipoAplicacionOfertaId';
        export const nameProperty = 'TipoAplicacionOfertaId';
        export const localTextPrefix = 'Portal.TipoAplicacionOferta';
        export const lookupKey = 'Portal.TipoAplicacionOferta';

        export function getLookup(): Q.Lookup<TipoAplicacionOfertaRow> {
            return Q.getLookup<TipoAplicacionOfertaRow>('Portal.TipoAplicacionOferta');
        }

        export namespace Fields {
            export declare const TipoAplicacionOfertaId: string;
            export declare const AplicableSegunFechaDe: string;
        }

        ['TipoAplicacionOfertaId', 'AplicableSegunFechaDe'].forEach(x => (<any>Fields)[x] = x);
    }
}

