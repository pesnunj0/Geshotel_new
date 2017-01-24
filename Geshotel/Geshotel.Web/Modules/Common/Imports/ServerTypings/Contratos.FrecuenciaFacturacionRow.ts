﻿namespace Geshotel.Contratos {
    export interface FrecuenciaFacturacionRow {
        FrecuenciaId?: number;
        DescripcionCorta?: string;
        Descripcion?: string;
    }

    export namespace FrecuenciaFacturacionRow {
        export const idProperty = 'FrecuenciaId';
        export const nameProperty = 'DescripcionCorta';
        export const localTextPrefix = 'Contratos.FrecuenciaFacturacion';

        export namespace Fields {
            export declare const FrecuenciaId: string;
            export declare const DescripcionCorta: string;
            export declare const Descripcion: string;
        }

        ['FrecuenciaId', 'DescripcionCorta', 'Descripcion'].forEach(x => (<any>Fields)[x] = x);
    }
}

