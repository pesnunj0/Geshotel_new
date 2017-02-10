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
        export const lookupKey = 'Portal.FrecuenciaFacturacion';

        export function getLookup(): Q.Lookup<FrecuenciaFacturacionRow> {
            return Q.getLookup<FrecuenciaFacturacionRow>('Portal.FrecuenciaFacturacion');
        }

        export namespace Fields {
            export declare const FrecuenciaId: string;
            export declare const DescripcionCorta: string;
            export declare const Descripcion: string;
        }

        ['FrecuenciaId', 'DescripcionCorta', 'Descripcion'].forEach(x => (<any>Fields)[x] = x);
    }
}

