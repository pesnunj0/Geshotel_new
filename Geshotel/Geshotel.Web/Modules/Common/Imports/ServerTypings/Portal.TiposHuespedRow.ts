namespace Geshotel.Portal {
    export interface TiposHuespedRow {
        TipoHuespedId?: number;
        EmpresaId?: number;
        Descripcion?: string;
        DescCorta?: string;
        UcId?: number;
        Empresa?: string;
        UcDescripcionUnidadCalculo?: string;
    }

    export namespace TiposHuespedRow {
        export const idProperty = 'TipoHuespedId';
        export const nameProperty = 'Descripcion';
        export const localTextPrefix = 'Portal.TiposHuesped';
        export const lookupKey = 'Portal.TiposHuesped';

        export function getLookup(): Q.Lookup<TiposHuespedRow> {
            return Q.getLookup<TiposHuespedRow>('Portal.TiposHuesped');
        }

        export namespace Fields {
            export declare const TipoHuespedId: string;
            export declare const EmpresaId: string;
            export declare const Descripcion: string;
            export declare const DescCorta: string;
            export declare const UcId: string;
            export declare const Empresa: string;
            export declare const UcDescripcionUnidadCalculo: string;
        }

        ['TipoHuespedId', 'EmpresaId', 'Descripcion', 'DescCorta', 'UcId', 'Empresa', 'UcDescripcionUnidadCalculo'].forEach(x => (<any>Fields)[x] = x);
    }
}

