
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
            export declare const RejillaId;
            export declare const OfertaId;
            export declare const N;
            export declare const TipoCondicionId;
            export declare const TipoAplicacion;
            export declare const M;
        }

        ['RejillaId', 'OfertaId', 'N', 'TipoCondicionId', 'TipoAplicacion', 'M'].forEach(x => (<any>Fields)[x] = x);
    }
}

