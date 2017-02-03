namespace Geshotel.Contratos {
    export interface FrecuenciaFacturacionRow {
        FrecuenciaId?: number;
        DescripcionCorta?: string;
        Descripcion?: string;
    }

    export namespace FrecuenciaFacturacionRow {
        export const idProperty = 'FrecuenciaId';
        export const nameProperty = 'Descripcion';
        export const localTextPrefix = 'Contratos.FrecuenciaFacturacion';
        export const lookupKey = 'Contratos.FrecuenciaFacturacion';

        export function getLookup(): Q.Lookup<FrecuenciaFacturacionRow> {
            return Q.getLookup<FrecuenciaFacturacionRow>('Contratos.FrecuenciaFacturacion');
        }

        export namespace Fields {
            export declare const FrecuenciaId: string;
            export declare const DescripcionCorta: string;
            export declare const Descripcion: string;
        }

        ['FrecuenciaId', 'DescripcionCorta', 'Descripcion'].forEach(x => (<any>Fields)[x] = x);
    }
}

