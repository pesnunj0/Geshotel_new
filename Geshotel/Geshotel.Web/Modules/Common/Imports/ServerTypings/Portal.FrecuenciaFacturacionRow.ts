
namespace Geshotel.Portal {
    export interface FrecuenciaFacturacionRow {
        FrecuenciaId?: number;
        DescripcionCorta?: string;
        Descripcion?: string;
    }

    export namespace FrecuenciaFacturacionRow {
        export const idProperty = 'FrecuenciaId';
        export const nameProperty = 'DescripcionCorta';
        export const localTextPrefix = 'Portal.FrecuenciaFacturacion';

        export namespace Fields {
            export declare const FrecuenciaId;
            export declare const DescripcionCorta;
            export declare const Descripcion;
        }

        ['FrecuenciaId', 'DescripcionCorta', 'Descripcion'].forEach(x => (<any>Fields)[x] = x);
    }
}

