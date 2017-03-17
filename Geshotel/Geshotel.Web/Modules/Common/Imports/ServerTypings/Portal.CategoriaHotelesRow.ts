namespace Geshotel.Portal {
    export interface CategoriaHotelesRow {
        CategoriaId?: number;
        Abreviatura?: string;
        Categoria?: string;
    }

    export namespace CategoriaHotelesRow {
        export const idProperty = 'CategoriaId';
        export const nameProperty = 'Categoria';
        export const localTextPrefix = 'Portal.CategoriaHoteles';
        export const lookupKey = 'Portal.CategoriaHoteles';

        export function getLookup(): Q.Lookup<CategoriaHotelesRow> {
            return Q.getLookup<CategoriaHotelesRow>('Portal.CategoriaHoteles');
        }

        export namespace Fields {
            export declare const CategoriaId: string;
            export declare const Abreviatura: string;
            export declare const Categoria: string;
        }

        ['CategoriaId', 'Abreviatura', 'Categoria'].forEach(x => (<any>Fields)[x] = x);
    }
}

