namespace Geshotel.Portal {
    export interface AmbitoOfertaRow {
        AmbitoOfertaId?: number;
        Nombre?: string;
    }

    export namespace AmbitoOfertaRow {
        export const idProperty = 'AmbitoOfertaId';
        export const nameProperty = 'Nombre';
        export const localTextPrefix = 'Portal.AmbitoOferta';
        export const lookupKey = 'Portal.AmbitoOferta';

        export function getLookup(): Q.Lookup<AmbitoOfertaRow> {
            return Q.getLookup<AmbitoOfertaRow>('Portal.AmbitoOferta');
        }

        export namespace Fields {
            export declare const AmbitoOfertaId: string;
            export declare const Nombre: string;
        }

        ['AmbitoOfertaId', 'Nombre'].forEach(x => (<any>Fields)[x] = x);
    }
}

