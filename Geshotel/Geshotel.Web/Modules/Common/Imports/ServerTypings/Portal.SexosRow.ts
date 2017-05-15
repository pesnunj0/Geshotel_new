namespace Geshotel.Portal {
    export interface SexosRow {
        SexoId?: string;
        Sexo?: string;
    }

    export namespace SexosRow {
        export const idProperty = 'SexoId';
        export const nameProperty = 'Sexo';
        export const localTextPrefix = 'Portal.Sexos';
        export const lookupKey = 'Portal.Sexos';

        export function getLookup(): Q.Lookup<SexosRow> {
            return Q.getLookup<SexosRow>('Portal.Sexos');
        }

        export namespace Fields {
            export declare const SexoId: string;
            export declare const Sexo: string;
        }

        ['SexoId', 'Sexo'].forEach(x => (<any>Fields)[x] = x);
    }
}

