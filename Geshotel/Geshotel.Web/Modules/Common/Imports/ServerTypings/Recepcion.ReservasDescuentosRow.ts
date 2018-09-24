
namespace Geshotel.Recepcion {
    export interface ReservasDescuentosRow {
        ReservaDescuentoId?: number;
        ReservaId?: number;
        ServicioId?: number;
        TipoDescuentoId?: number;
        Tipo?: string;
        Descuento?: number;
        UserId?: number;
        FechaModificacion?: string;
        ReservaFechaCreacion?: string;
        ReservaHotelId?: number;
        ReservaEstadoReservaId?: number;
        ReservaClienteId?: number;
        ReservaCanalReservaId?: number;
        ReservaClienteIdFactura?: number;
        ReservaFechaReserva?: string;
        ReservaNombreReserva?: string;
        ReservaFechaPrevistaLlegada?: string;
        ReservaFechaPrevistaSalida?: string;
        ReservaHoraPrevistaLlegada?: string;
        ReservaHoraPrevistaSalida?: string;
        ReservaObservacionesLlegada?: string;
        ReservaObservacionesSalida?: string;
        ReservaObservacionesCliente?: string;
        ReservaObservaciones?: string;
        ReservaFechaLlegada?: string;
        ReservaFechaSalida?: string;
        ReservaBonoReferencia?: string;
        ReservaBonoOnline?: string;
        ReservaBloquearTarifa?: number;
        ReservaPermiteDevolucion?: number;
        ReservaTipoTarjetaId?: number;
        ReservaTarjetaCredito?: string;
        ReservaCaducidad?: string;
        ReservaCodSeguridad?: string;
        ReservaContratoTtoo?: string;
        ReservaCodigoOferta?: string;
        ReservaValor?: number;
        ReservaValorValidado?: number;
        ReservaFechaValidacion?: string;
        ReservaUsuarioValidacion?: number;
        ReservaParoventasCheck?: number;
        ReservaCuposCheck?: number;
        ReservaReleaseCheck?: number;
        ReservaReservaDingus?: number[];
        ReservaDingusImpuestosIncluidos?: number;
        ReservaDingusComision?: number;
        ReservaReservaDingusTipo?: number;
        ReservaFechaAnulacion?: string;
        ReservaUserId?: number;
        ReservaFechaModificacion?: string;
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
        TipoDescuentoDescuento?: string;
        TipoDescripcion?: string;
    }

    export namespace ReservasDescuentosRow {
        export const idProperty = 'ReservaDescuentoId';
        export const nameProperty = 'Tipo';
        export const localTextPrefix = 'Recepcion.ReservasDescuentos';

        export namespace Fields {
            export declare const ReservaDescuentoId: string;
            export declare const ReservaId: string;
            export declare const ServicioId: string;
            export declare const TipoDescuentoId: string;
            export declare const Tipo: string;
            export declare const Descuento: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const ReservaFechaCreacion: string;
            export declare const ReservaHotelId: string;
            export declare const ReservaEstadoReservaId: string;
            export declare const ReservaClienteId: string;
            export declare const ReservaCanalReservaId: string;
            export declare const ReservaClienteIdFactura: string;
            export declare const ReservaFechaReserva: string;
            export declare const ReservaNombreReserva: string;
            export declare const ReservaFechaPrevistaLlegada: string;
            export declare const ReservaFechaPrevistaSalida: string;
            export declare const ReservaHoraPrevistaLlegada: string;
            export declare const ReservaHoraPrevistaSalida: string;
            export declare const ReservaObservacionesLlegada: string;
            export declare const ReservaObservacionesSalida: string;
            export declare const ReservaObservacionesCliente: string;
            export declare const ReservaObservaciones: string;
            export declare const ReservaFechaLlegada: string;
            export declare const ReservaFechaSalida: string;
            export declare const ReservaBonoReferencia: string;
            export declare const ReservaBonoOnline: string;
            export declare const ReservaBloquearTarifa: string;
            export declare const ReservaPermiteDevolucion: string;
            export declare const ReservaTipoTarjetaId: string;
            export declare const ReservaTarjetaCredito: string;
            export declare const ReservaCaducidad: string;
            export declare const ReservaCodSeguridad: string;
            export declare const ReservaContratoTtoo: string;
            export declare const ReservaCodigoOferta: string;
            export declare const ReservaValor: string;
            export declare const ReservaValorValidado: string;
            export declare const ReservaFechaValidacion: string;
            export declare const ReservaUsuarioValidacion: string;
            export declare const ReservaParoventasCheck: string;
            export declare const ReservaCuposCheck: string;
            export declare const ReservaReleaseCheck: string;
            export declare const ReservaReservaDingus: string;
            export declare const ReservaDingusImpuestosIncluidos: string;
            export declare const ReservaDingusComision: string;
            export declare const ReservaReservaDingusTipo: string;
            export declare const ReservaFechaAnulacion: string;
            export declare const ReservaUserId: string;
            export declare const ReservaFechaModificacion: string;
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
            export declare const TipoDescuentoDescuento: string;
            export declare const TipoDescripcion: string;
        }

        [
            'ReservaDescuentoId', 
            'ReservaId', 
            'ServicioId', 
            'TipoDescuentoId', 
            'Tipo', 
            'Descuento', 
            'UserId', 
            'FechaModificacion', 
            'ReservaFechaCreacion', 
            'ReservaHotelId', 
            'ReservaEstadoReservaId', 
            'ReservaClienteId', 
            'ReservaCanalReservaId', 
            'ReservaClienteIdFactura', 
            'ReservaFechaReserva', 
            'ReservaNombreReserva', 
            'ReservaFechaPrevistaLlegada', 
            'ReservaFechaPrevistaSalida', 
            'ReservaHoraPrevistaLlegada', 
            'ReservaHoraPrevistaSalida', 
            'ReservaObservacionesLlegada', 
            'ReservaObservacionesSalida', 
            'ReservaObservacionesCliente', 
            'ReservaObservaciones', 
            'ReservaFechaLlegada', 
            'ReservaFechaSalida', 
            'ReservaBonoReferencia', 
            'ReservaBonoOnline', 
            'ReservaBloquearTarifa', 
            'ReservaPermiteDevolucion', 
            'ReservaTipoTarjetaId', 
            'ReservaTarjetaCredito', 
            'ReservaCaducidad', 
            'ReservaCodSeguridad', 
            'ReservaContratoTtoo', 
            'ReservaCodigoOferta', 
            'ReservaValor', 
            'ReservaValorValidado', 
            'ReservaFechaValidacion', 
            'ReservaUsuarioValidacion', 
            'ReservaParoventasCheck', 
            'ReservaCuposCheck', 
            'ReservaReleaseCheck', 
            'ReservaReservaDingus', 
            'ReservaDingusImpuestosIncluidos', 
            'ReservaDingusComision', 
            'ReservaReservaDingusTipo', 
            'ReservaFechaAnulacion', 
            'ReservaUserId', 
            'ReservaFechaModificacion', 
            'ServicioNombreServicio', 
            'ServicioAbreviatura', 
            'ServicioTipoServicioId', 
            'ServicioSwProduccion', 
            'ServicioSwDescuento', 
            'ServicioSwAjustes', 
            'ServicioSwGastos', 
            'ServicioSwPension', 
            'ServicioSwRectificativa', 
            'ServicioTipoUnidadCalculoId', 
            'ServicioConceptoAceleradorReservasId', 
            'ServicioCosto', 
            'ServicioSumaServicioId', 
            'ServicioRestaServicioId', 
            'ServicioUserId', 
            'ServicioFechaModificacion', 
            'ServicioTipoHab', 
            'ServicioTipoPension', 
            'TipoDescuentoDescuento', 
            'TipoDescripcion'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

