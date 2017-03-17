namespace Geshotel.Recepcion {
    export interface ReservasHuespedesRow {
        ReservasHuespedesId?: number;
        ReservaId?: number;
        ClienteId?: number;
        FechaLlegada?: string;
        FechaSalida?: string;
        HabitacionId?: number;
        TipoHuespedId?: number;
        Edad?: number;
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
    }

    export namespace ReservasHuespedesRow {
        export const idProperty = 'ReservasHuespedesId';
        export const localTextPrefix = 'Recepcion.ReservasHuespedes';

        export namespace Fields {
            export declare const ReservasHuespedesId: string;
            export declare const ReservaId: string;
            export declare const ClienteId: string;
            export declare const FechaLlegada: string;
            export declare const FechaSalida: string;
            export declare const HabitacionId: string;
            export declare const TipoHuespedId: string;
            export declare const Edad: string;
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
        }

        ['ReservasHuespedesId', 'ReservaId', 'ClienteId', 'FechaLlegada', 'FechaSalida', 'HabitacionId', 'TipoHuespedId', 'Edad', 'ReservaFechaCreacion', 'ReservaHotelId', 'ReservaEstadoReservaId', 'ReservaClienteId', 'ReservaCanalReservaId', 'ReservaClienteIdFactura', 'ReservaFechaReserva', 'ReservaNombreReserva', 'ReservaFechaPrevistaLlegada', 'ReservaFechaPrevistaSalida', 'ReservaHoraPrevistaLlegada', 'ReservaHoraPrevistaSalida', 'ReservaObservacionesLlegada', 'ReservaObservacionesSalida', 'ReservaObservacionesCliente', 'ReservaObservaciones', 'ReservaFechaLlegada', 'ReservaFechaSalida', 'ReservaBonoReferencia', 'ReservaBonoOnline', 'ReservaBloquearTarifa', 'ReservaPermiteDevolucion', 'ReservaTipoTarjetaId', 'ReservaTarjetaCredito', 'ReservaCaducidad', 'ReservaCodSeguridad', 'ReservaContratoTtoo', 'ReservaCodigoOferta', 'ReservaValor', 'ReservaValorValidado', 'ReservaFechaValidacion', 'ReservaUsuarioValidacion', 'ReservaParoventasCheck', 'ReservaCuposCheck', 'ReservaReleaseCheck', 'ReservaReservaDingus', 'ReservaDingusImpuestosIncluidos', 'ReservaDingusComision', 'ReservaReservaDingusTipo', 'ReservaFechaAnulacion', 'ReservaUserId', 'ReservaFechaModificacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

