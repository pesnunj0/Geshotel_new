
namespace Geshotel.Contratos {
    export interface AmbitoOfertaRow {
        AmbitoOfertaId?: number;
        NombreAmbito?: string;
    }

    export namespace AmbitoOfertaRow {
        export const idProperty = 'AmbitoOfertaId';
        export const nameProperty = 'NombreAmbito';
        export const localTextPrefix = 'Contratos.AmbitoOferta';

        export namespace Fields {
            export declare const AmbitoOfertaId;
            export declare const NombreAmbito;
        }

        ['AmbitoOfertaId', 'NombreAmbito'].forEach(x => (<any>Fields)[x] = x);
    }
}

