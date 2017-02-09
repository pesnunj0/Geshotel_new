
namespace Geshotel.Portal {
    export interface AmbitoOfertaRow {
        AmbitoOfertaId?: number;
        Nombre?: string;
    }

    export namespace AmbitoOfertaRow {
        export const idProperty = 'AmbitoOfertaId';
        export const nameProperty = 'Nombre';
        export const localTextPrefix = 'Portal.AmbitoOferta';

        export namespace Fields {
            export declare const AmbitoOfertaId;
            export declare const Nombre;
        }

        ['AmbitoOfertaId', 'Nombre'].forEach(x => (<any>Fields)[x] = x);
    }
}

