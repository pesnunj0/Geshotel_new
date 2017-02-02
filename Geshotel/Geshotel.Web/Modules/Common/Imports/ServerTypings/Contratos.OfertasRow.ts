
namespace Geshotel.Contratos {
    export interface OfertasRow {
        OfertaId?: number;
        Texto?: string;
        ContratoId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        TipoAplicacionOfertaId?: string;
        AplicableAuto?: boolean;
        FechaReservaDesde?: string;
        FechaReservaHasta?: string;
        EstanciaMinimaDias?: number;
        EstanciaMaximaDias?: number;
        DiasDeAntelacion?: number;
        TipoServicioId?: number;
        ServicioId?: number;
        UnidadCalculoId?: number;
        ServicioLigadoId?: number;
        CupoOferta?: number;
        Precio?: number;
        N?: number;
        TipoOfertaId?: number;
        M?: number;
        AmbitoOfertaId?: number;
        UserId?: number;
        FechaModificacion?: string;
        ImpuestoIncluido?: boolean;
        TipoImputacionId?: number;
        OrdenAplicacion?: number;
    }

    export namespace OfertasRow {
        export const idProperty = 'OfertaId';
        export const nameProperty = 'Texto';
        export const localTextPrefix = 'Contratos.Ofertas';

        export namespace Fields {
            export declare const OfertaId;
            export declare const Texto;
            export declare const ContratoId;
            export declare const FechaDesde;
            export declare const FechaHasta;
            export declare const TipoAplicacionOfertaId;
            export declare const AplicableAuto;
            export declare const FechaReservaDesde;
            export declare const FechaReservaHasta;
            export declare const EstanciaMinimaDias;
            export declare const EstanciaMaximaDias;
            export declare const DiasDeAntelacion;
            export declare const TipoServicioId;
            export declare const ServicioId;
            export declare const UnidadCalculoId;
            export declare const ServicioLigadoId;
            export declare const CupoOferta;
            export declare const Precio;
            export declare const N;
            export declare const TipoOfertaId;
            export declare const M;
            export declare const AmbitoOfertaId;
            export declare const UserId;
            export declare const FechaModificacion;
            export declare const ImpuestoIncluido;
            export declare const TipoImputacionId;
            export declare const OrdenAplicacion;
        }

        ['OfertaId', 'Texto', 'ContratoId', 'FechaDesde', 'FechaHasta', 'TipoAplicacionOfertaId', 'AplicableAuto', 'FechaReservaDesde', 'FechaReservaHasta', 'EstanciaMinimaDias', 'EstanciaMaximaDias', 'DiasDeAntelacion', 'TipoServicioId', 'ServicioId', 'UnidadCalculoId', 'ServicioLigadoId', 'CupoOferta', 'Precio', 'N', 'TipoOfertaId', 'M', 'AmbitoOfertaId', 'UserId', 'FechaModificacion', 'ImpuestoIncluido', 'TipoImputacionId', 'OrdenAplicacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

