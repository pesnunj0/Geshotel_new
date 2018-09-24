
namespace Geshotel.Recepcion {
    export interface ReservasRow {
        ReservaId?: number;
        FechaCreacion?: string;
        HotelId?: number;
        EstadoReservaId?: number;
        ClienteId?: number;
        CanalReservaId?: number;
        ClienteIdFactura?: number;
        FechaReserva?: string;
        NombreReserva?: string;
        TipoHabitacionId?: number;
        PensionId?: number;
        Adultos?: number;
        Child50?: number;
        ChildFree?: number;
        Bebes?: number;
        Pax?: number;
        Vip?: boolean;
        FechaPrevistaLlegada?: string;
        FechaPrevistaSalida?: string;
        ObservacionesLlegada?: string;
        ObservacionesSalida?: string;
        ObservacionesCliente?: string;
        Observaciones?: string;
        FechaLlegada?: string;
        FechaSalida?: string;
        BonoReferencia?: string;
        BonoOnline?: string;
        BloquearTarifa?: boolean;
        PermiteDevolucion?: boolean;
        TipoTarjetaId?: number;
        TarjetaCredito?: string;
        Caducidad?: string;
        CodSeguridad?: string;
        ContratoTtoo?: string;
        CodigoOferta?: string;
        Valor?: number;
        ValorValidado?: number;
        FechaValidacion?: string;
        UsuarioValidacion?: number;
        ParoventasCheck?: boolean;
        CuposCheck?: boolean;
        ReleaseCheck?: boolean;
        ReservaDingus?: number[];
        DingusImpuestosIncluidos?: boolean;
        DingusComision?: number;
        ReservaDingusTipo?: number;
        FechaAnulacion?: string;
        UserId?: number;
        FechaModificacion?: string;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        EstadoReserva?: string;
        TipoTarjeta?: string;
        ClienteRazon?: string;
        CanalReserva?: string;
        ClienteIdFacturaRazon?: string;
        TipoHabitacion?: string;
        Pension?: string;
        Username?: string;
        ValidationUsername?: string;
        ReservaName?: string;
        Noches?: number;
        Ficheros?: string;
    }

    export namespace ReservasRow {
        export const idProperty = 'ReservaId';
        export const nameProperty = 'ReservaName';
        export const localTextPrefix = 'Recepcion.Reservas';

        export namespace Fields {
            export declare const ReservaId: string;
            export declare const FechaCreacion: string;
            export declare const HotelId: string;
            export declare const EstadoReservaId: string;
            export declare const ClienteId: string;
            export declare const CanalReservaId: string;
            export declare const ClienteIdFactura: string;
            export declare const FechaReserva: string;
            export declare const NombreReserva: string;
            export declare const TipoHabitacionId: string;
            export declare const PensionId: string;
            export declare const Adultos: string;
            export declare const Child50: string;
            export declare const ChildFree: string;
            export declare const Bebes: string;
            export declare const Pax: string;
            export declare const Vip: string;
            export declare const FechaPrevistaLlegada: string;
            export declare const FechaPrevistaSalida: string;
            export declare const ObservacionesLlegada: string;
            export declare const ObservacionesSalida: string;
            export declare const ObservacionesCliente: string;
            export declare const Observaciones: string;
            export declare const FechaLlegada: string;
            export declare const FechaSalida: string;
            export declare const BonoReferencia: string;
            export declare const BonoOnline: string;
            export declare const BloquearTarifa: string;
            export declare const PermiteDevolucion: string;
            export declare const TipoTarjetaId: string;
            export declare const TarjetaCredito: string;
            export declare const Caducidad: string;
            export declare const CodSeguridad: string;
            export declare const ContratoTtoo: string;
            export declare const CodigoOferta: string;
            export declare const Valor: string;
            export declare const ValorValidado: string;
            export declare const FechaValidacion: string;
            export declare const UsuarioValidacion: string;
            export declare const ParoventasCheck: string;
            export declare const CuposCheck: string;
            export declare const ReleaseCheck: string;
            export declare const ReservaDingus: string;
            export declare const DingusImpuestosIncluidos: string;
            export declare const DingusComision: string;
            export declare const ReservaDingusTipo: string;
            export declare const FechaAnulacion: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const HotelName: string;
            export declare const EmpresaId: string;
            export declare const Empresa: string;
            export declare const EstadoReserva: string;
            export declare const TipoTarjeta: string;
            export declare const ClienteRazon: string;
            export declare const CanalReserva: string;
            export declare const ClienteIdFacturaRazon: string;
            export declare const TipoHabitacion: string;
            export declare const Pension: string;
            export declare const Username: string;
            export declare const ValidationUsername: string;
            export declare const ReservaName: string;
            export declare const Noches: string;
            export declare const Ficheros: string;
        }

        [
            'ReservaId', 
            'FechaCreacion', 
            'HotelId', 
            'EstadoReservaId', 
            'ClienteId', 
            'CanalReservaId', 
            'ClienteIdFactura', 
            'FechaReserva', 
            'NombreReserva', 
            'TipoHabitacionId', 
            'PensionId', 
            'Adultos', 
            'Child50', 
            'ChildFree', 
            'Bebes', 
            'Pax', 
            'Vip', 
            'FechaPrevistaLlegada', 
            'FechaPrevistaSalida', 
            'ObservacionesLlegada', 
            'ObservacionesSalida', 
            'ObservacionesCliente', 
            'Observaciones', 
            'FechaLlegada', 
            'FechaSalida', 
            'BonoReferencia', 
            'BonoOnline', 
            'BloquearTarifa', 
            'PermiteDevolucion', 
            'TipoTarjetaId', 
            'TarjetaCredito', 
            'Caducidad', 
            'CodSeguridad', 
            'ContratoTtoo', 
            'CodigoOferta', 
            'Valor', 
            'ValorValidado', 
            'FechaValidacion', 
            'UsuarioValidacion', 
            'ParoventasCheck', 
            'CuposCheck', 
            'ReleaseCheck', 
            'ReservaDingus', 
            'DingusImpuestosIncluidos', 
            'DingusComision', 
            'ReservaDingusTipo', 
            'FechaAnulacion', 
            'UserId', 
            'FechaModificacion', 
            'HotelName', 
            'EmpresaId', 
            'Empresa', 
            'EstadoReserva', 
            'TipoTarjeta', 
            'ClienteRazon', 
            'CanalReserva', 
            'ClienteIdFacturaRazon', 
            'TipoHabitacion', 
            'Pension', 
            'Username', 
            'ValidationUsername', 
            'ReservaName', 
            'Noches', 
            'Ficheros'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

