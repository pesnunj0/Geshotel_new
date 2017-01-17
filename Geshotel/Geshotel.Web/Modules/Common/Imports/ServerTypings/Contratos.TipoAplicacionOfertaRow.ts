
namespace Geshotel.Contratos {
    export interface TipoAplicacionOfertaRow {
        TipoAplicacionOfertaId?: string;
        AplicableSegunFechaDe?: string;
    }

    export namespace TipoAplicacionOfertaRow {
        export const idProperty = 'TipoAplicacionOfertaId';
        export const nameProperty = 'TipoAplicacionOfertaId';
        export const localTextPrefix = 'Contratos.TipoAplicacionOferta';

        export namespace Fields {
            export declare const TipoAplicacionOfertaId;
            export declare const AplicableSegunFechaDe;
        }

        ['TipoAplicacionOfertaId', 'AplicableSegunFechaDe'].forEach(x => (<any>Fields)[x] = x);
    }
}

