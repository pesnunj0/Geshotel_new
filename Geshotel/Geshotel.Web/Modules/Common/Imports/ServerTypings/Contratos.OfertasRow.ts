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
        AmbitoOfertaName?: string;
        TipoOfertaName?: string;
        TipoServicioName?: string;
        ServicioName?: string;
        ServicioLigadoName?: string;
        UnidadCalculoName?: string;
        UserName?: string;
        TipoAplicacionOfertaName?: string;
        TipoImputacionName?: string;
    }

    export namespace OfertasRow {
        export const idProperty = 'OfertaId';
        export const nameProperty = 'Texto';
        export const localTextPrefix = 'Contratos.Ofertas';

        export namespace Fields {
            export declare const OfertaId: string;
            export declare const Texto: string;
            export declare const ContratoId: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
            export declare const TipoAplicacionOfertaId: string;
            export declare const AplicableAuto: string;
            export declare const FechaReservaDesde: string;
            export declare const FechaReservaHasta: string;
            export declare const EstanciaMinimaDias: string;
            export declare const EstanciaMaximaDias: string;
            export declare const DiasDeAntelacion: string;
            export declare const TipoServicioId: string;
            export declare const ServicioId: string;
            export declare const UnidadCalculoId: string;
            export declare const ServicioLigadoId: string;
            export declare const CupoOferta: string;
            export declare const Precio: string;
            export declare const N: string;
            export declare const TipoOfertaId: string;
            export declare const M: string;
            export declare const AmbitoOfertaId: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const ImpuestoIncluido: string;
            export declare const TipoImputacionId: string;
            export declare const OrdenAplicacion: string;
            export declare const AmbitoOfertaName: string;
            export declare const TipoOfertaName: string;
            export declare const TipoServicioName: string;
            export declare const ServicioName: string;
            export declare const ServicioLigadoName: string;
            export declare const UnidadCalculoName: string;
            export declare const UserName: string;
            export declare const TipoAplicacionOfertaName: string;
            export declare const TipoImputacionName: string;
        }

        ['OfertaId', 'Texto', 'ContratoId', 'FechaDesde', 'FechaHasta', 'TipoAplicacionOfertaId', 'AplicableAuto', 'FechaReservaDesde', 'FechaReservaHasta', 'EstanciaMinimaDias', 'EstanciaMaximaDias', 'DiasDeAntelacion', 'TipoServicioId', 'ServicioId', 'UnidadCalculoId', 'ServicioLigadoId', 'CupoOferta', 'Precio', 'N', 'TipoOfertaId', 'M', 'AmbitoOfertaId', 'UserId', 'FechaModificacion', 'ImpuestoIncluido', 'TipoImputacionId', 'OrdenAplicacion', 'AmbitoOfertaName', 'TipoOfertaName', 'TipoServicioName', 'ServicioName', 'ServicioLigadoName', 'UnidadCalculoName', 'UserName', 'TipoAplicacionOfertaName', 'TipoImputacionName'].forEach(x => (<any>Fields)[x] = x);
    }
}

