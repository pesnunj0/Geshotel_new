namespace Geshotel.Contratos {
    export interface OfertasRejillasRow {
        RejillaId?: number;
        OfertaId?: number;
        N?: number;
        TipoCondicionId?: number;
        TipoAplicacion?: number;
        M?: number;
    }

    export namespace OfertasRejillasRow {
        export const idProperty = 'RejillaId';
        export const localTextPrefix = 'Contratos.OfertasRejillas';

        export namespace Fields {
            export declare const RejillaId: string;
            export declare const OfertaId: string;
            export declare const N: string;
            export declare const TipoCondicionId: string;
            export declare const TipoAplicacion: string;
            export declare const M: string;
        }

        ['RejillaId', 'OfertaId', 'N', 'TipoCondicionId', 'TipoAplicacion', 'M'].forEach(x => (<any>Fields)[x] = x);
    }
}

