
namespace Geshotel.Portal {
    export interface UnidadesCalculoRow {
        UnidadCalculoId?: number;
        Uc?: string;
        DescripcionUnidadCalculo?: string;
        TipoUnidadCalculoId?: number;
        Pax?: boolean;
        ServicioId?: number;
        TipoUc?: string;
        ServicioNombreServicio?: string;
    }

    export namespace UnidadesCalculoRow {
        export const idProperty = 'UnidadCalculoId';
        export const nameProperty = 'DescripcionUnidadCalculo';
        export const localTextPrefix = 'Portal.UnidadesCalculo';
        export const lookupKey = 'Portal.UnidadesCalculo';

        export function getLookup(): Q.Lookup<UnidadesCalculoRow> {
            return Q.getLookup<UnidadesCalculoRow>('Portal.UnidadesCalculo');
        }

        export namespace Fields {
            export declare const UnidadCalculoId: string;
            export declare const Uc: string;
            export declare const DescripcionUnidadCalculo: string;
            export declare const TipoUnidadCalculoId: string;
            export declare const Pax: string;
            export declare const ServicioId: string;
            export declare const TipoUc: string;
            export declare const ServicioNombreServicio: string;
        }

        ['UnidadCalculoId', 'Uc', 'DescripcionUnidadCalculo', 'TipoUnidadCalculoId', 'Pax', 'ServicioId', 'TipoUc', 'ServicioNombreServicio'].forEach(x => (<any>Fields)[x] = x);
    }
}

