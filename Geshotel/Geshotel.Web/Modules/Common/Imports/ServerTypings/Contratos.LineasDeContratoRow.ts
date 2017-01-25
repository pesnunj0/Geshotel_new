﻿namespace Geshotel.Contratos {
    export interface LineasDeContratoRow {
        LineaContratoId?: number;
        ContratoId?: number;
        Oferta?: number;
        Desde?: string;
        Hasta?: string;
        ServicioId?: number;
        UnidadCalculoId?: number;
        FrecuenciaId?: number;
        TipoImputacionId?: number;
        Importe?: number;
        N?: number;
        TipoOfertaId?: number;
        M?: number;
        AmbitoOfertaId?: number;
        Lunes?: number;
        Martes?: boolean;
        Miercoles?: boolean;
        Jueves?: boolean;
        Viernes?: boolean;
        Sabado?: boolean;
        Domingo?: boolean;
        PagFactura?: number;
        UserId?: number;
        FechaModificacion?: string;
        ContratoHotelId?: number;
        ContratoClienteId?: number;
        ContratoFechaContrato?: string;
        ContratoFechaDesde?: string;
        ContratoFechaHasta?: string;
        ContratoContratoIdOriginal?: number;
        ContratoContratoIdSiguiente?: number;
        ContratoNumeroContratoCliente?: string;
        ContratoUserId?: number;
        ContratoFechaModificacion?: string;
        ContratoTemporadaId?: number;
        ContratoImpuestoIncluido?: number;
        ContratoMercadoId?: number;
        ContratoClienteIdPadre?: number;
        ServicioNombreServicio?: string;
        ServicioAbreviatura?: string;
        ServicioTipoServicioId?: number;
        ServicioSwProduccion?: boolean;
        ServicioSwDescuento?: boolean;
        ServicioSwAjustes?: boolean;
        ServicioSwGastos?: boolean;
        ServicioSwPension?: boolean;
        ServicioSwRectificativa?: boolean;
        ServicioTipoUnidadCalculoId?: number;
        ServicioConceptoAceleradorReservasId?: number;
        ServicioCosto?: number;
        ServicioSumaServicioId?: number;
        ServicioRestaServicioId?: number;
        ServicioUserId?: number;
        ServicioFechaModificacion?: string;
        ServicioTipoHab?: number;
        ServicioTipoPension?: number;
        UnidadCalculoUc?: string;
        UnidadCalculoDescripcionUnidadCalculo?: string;
        UnidadCalculoTipoUnidadCalculoId?: number;
        UnidadCalculoPax?: boolean;
        UnidadCalculoServicioId?: number;
        UnidadCalculoUserId?: number;
        UnidadCalculoFechaModificacion?: string;
        TipoOfertaOferta?: string;
        TipoOfertaPermitirMMayorQueN?: number;
        TipoOfertaRejilla?: number;
        TipoOfertaObservaciones?: string;
        TipoOfertaOrdenAplicacion?: number;
    }

    export namespace LineasDeContratoRow {
        export const idProperty = 'LineaContratoId';
        export const localTextPrefix = 'Contratos.LineasDeContrato';

        export namespace Fields {
            export declare const LineaContratoId: string;
            export declare const ContratoId: string;
            export declare const Oferta: string;
            export declare const Desde: string;
            export declare const Hasta: string;
            export declare const ServicioId: string;
            export declare const UnidadCalculoId: string;
            export declare const FrecuenciaId: string;
            export declare const TipoImputacionId: string;
            export declare const Importe: string;
            export declare const N: string;
            export declare const TipoOfertaId: string;
            export declare const M: string;
            export declare const AmbitoOfertaId: string;
            export declare const Lunes: string;
            export declare const Martes: string;
            export declare const Miercoles: string;
            export declare const Jueves: string;
            export declare const Viernes: string;
            export declare const Sabado: string;
            export declare const Domingo: string;
            export declare const PagFactura: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const ContratoHotelId: string;
            export declare const ContratoClienteId: string;
            export declare const ContratoFechaContrato: string;
            export declare const ContratoFechaDesde: string;
            export declare const ContratoFechaHasta: string;
            export declare const ContratoContratoIdOriginal: string;
            export declare const ContratoContratoIdSiguiente: string;
            export declare const ContratoNumeroContratoCliente: string;
            export declare const ContratoUserId: string;
            export declare const ContratoFechaModificacion: string;
            export declare const ContratoTemporadaId: string;
            export declare const ContratoImpuestoIncluido: string;
            export declare const ContratoMercadoId: string;
            export declare const ContratoClienteIdPadre: string;
            export declare const ServicioNombreServicio: string;
            export declare const ServicioAbreviatura: string;
            export declare const ServicioTipoServicioId: string;
            export declare const ServicioSwProduccion: string;
            export declare const ServicioSwDescuento: string;
            export declare const ServicioSwAjustes: string;
            export declare const ServicioSwGastos: string;
            export declare const ServicioSwPension: string;
            export declare const ServicioSwRectificativa: string;
            export declare const ServicioTipoUnidadCalculoId: string;
            export declare const ServicioConceptoAceleradorReservasId: string;
            export declare const ServicioCosto: string;
            export declare const ServicioSumaServicioId: string;
            export declare const ServicioRestaServicioId: string;
            export declare const ServicioUserId: string;
            export declare const ServicioFechaModificacion: string;
            export declare const ServicioTipoHab: string;
            export declare const ServicioTipoPension: string;
            export declare const UnidadCalculoUc: string;
            export declare const UnidadCalculoDescripcionUnidadCalculo: string;
            export declare const UnidadCalculoTipoUnidadCalculoId: string;
            export declare const UnidadCalculoPax: string;
            export declare const UnidadCalculoServicioId: string;
            export declare const UnidadCalculoUserId: string;
            export declare const UnidadCalculoFechaModificacion: string;
            export declare const TipoOfertaOferta: string;
            export declare const TipoOfertaPermitirMMayorQueN: string;
            export declare const TipoOfertaRejilla: string;
            export declare const TipoOfertaObservaciones: string;
            export declare const TipoOfertaOrdenAplicacion: string;
        }

        ['LineaContratoId', 'ContratoId', 'Oferta', 'Desde', 'Hasta', 'ServicioId', 'UnidadCalculoId', 'FrecuenciaId', 'TipoImputacionId', 'Importe', 'N', 'TipoOfertaId', 'M', 'AmbitoOfertaId', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado', 'Domingo', 'PagFactura', 'UserId', 'FechaModificacion', 'ContratoHotelId', 'ContratoClienteId', 'ContratoFechaContrato', 'ContratoFechaDesde', 'ContratoFechaHasta', 'ContratoContratoIdOriginal', 'ContratoContratoIdSiguiente', 'ContratoNumeroContratoCliente', 'ContratoUserId', 'ContratoFechaModificacion', 'ContratoTemporadaId', 'ContratoImpuestoIncluido', 'ContratoMercadoId', 'ContratoClienteIdPadre', 'ServicioNombreServicio', 'ServicioAbreviatura', 'ServicioTipoServicioId', 'ServicioSwProduccion', 'ServicioSwDescuento', 'ServicioSwAjustes', 'ServicioSwGastos', 'ServicioSwPension', 'ServicioSwRectificativa', 'ServicioTipoUnidadCalculoId', 'ServicioConceptoAceleradorReservasId', 'ServicioCosto', 'ServicioSumaServicioId', 'ServicioRestaServicioId', 'ServicioUserId', 'ServicioFechaModificacion', 'ServicioTipoHab', 'ServicioTipoPension', 'UnidadCalculoUc', 'UnidadCalculoDescripcionUnidadCalculo', 'UnidadCalculoTipoUnidadCalculoId', 'UnidadCalculoPax', 'UnidadCalculoServicioId', 'UnidadCalculoUserId', 'UnidadCalculoFechaModificacion', 'TipoOfertaOferta', 'TipoOfertaPermitirMMayorQueN', 'TipoOfertaRejilla', 'TipoOfertaObservaciones', 'TipoOfertaOrdenAplicacion'].forEach(x => (<any>Fields)[x] = x);
    }
}
