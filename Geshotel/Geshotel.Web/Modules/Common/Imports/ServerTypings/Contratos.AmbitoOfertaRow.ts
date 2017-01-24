namespace Geshotel.Contratos {
    export interface AmbitoOfertaRow {
        AmbitoOfertaId?: number;
        Ambito?: string;
    }

    export namespace AmbitoOfertaRow {
        export const idProperty = 'AmbitoOfertaId';
        export const nameProperty = 'Ambito';
        export const localTextPrefix = 'Contratos.AmbitoOferta';
        export const lookupKey = 'Contratos.AmbitoOferta';

        export function getLookup(): Q.Lookup<AmbitoOfertaRow> {
            return Q.getLookup<AmbitoOfertaRow>('Contratos.AmbitoOferta');
        }

        export namespace Fields {
            export declare const AmbitoOfertaId: string;
            export declare const Ambito: string;
        }

        ['AmbitoOfertaId', 'Ambito'].forEach(x => (<any>Fields)[x] = x);
    }
}

