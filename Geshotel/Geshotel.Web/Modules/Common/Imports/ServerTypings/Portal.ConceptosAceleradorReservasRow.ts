
namespace Geshotel.Portal {
    export interface ConceptosAceleradorReservasRow {
        ConceptoAceleradorId?: number;
        Concepto?: string;
    }

    export namespace ConceptosAceleradorReservasRow {
        export const idProperty = 'ConceptoAceleradorId';
        export const nameProperty = 'Concepto';
        export const localTextPrefix = 'Portal.ConceptosAceleradorReservas';
        export const lookupKey = 'Portal.ConceptosAceleradorReservas';

        export function getLookup(): Q.Lookup<ConceptosAceleradorReservasRow> {
            return Q.getLookup<ConceptosAceleradorReservasRow>('Portal.ConceptosAceleradorReservas');
        }

        export namespace Fields {
            export declare const ConceptoAceleradorId: string;
            export declare const Concepto: string;
        }

        ['ConceptoAceleradorId', 'Concepto'].forEach(x => (<any>Fields)[x] = x);
    }
}

