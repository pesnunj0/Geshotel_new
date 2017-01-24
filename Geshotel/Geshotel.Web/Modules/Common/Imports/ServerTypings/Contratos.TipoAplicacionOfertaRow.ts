namespace Geshotel.Contratos {
    export interface TipoAplicacionOfertaRow {
        TipoAplicacionOfertaId?: string;
        AplicableSegunFechaDe?: string;
    }

    export namespace TipoAplicacionOfertaRow {
        export const idProperty = 'TipoAplicacionOfertaId';
        export const nameProperty = 'AplicableSegunFechaDe';
        export const localTextPrefix = 'Contratos.TipoAplicacionOferta';
        export const lookupKey = 'Contratos.TipoAplicacionOferta';

        export function getLookup(): Q.Lookup<TipoAplicacionOfertaRow> {
            return Q.getLookup<TipoAplicacionOfertaRow>('Contratos.TipoAplicacionOferta');
        }

        export namespace Fields {
            export declare const TipoAplicacionOfertaId: string;
            export declare const AplicableSegunFechaDe: string;
        }

        ['TipoAplicacionOfertaId', 'AplicableSegunFechaDe'].forEach(x => (<any>Fields)[x] = x);
    }
}

