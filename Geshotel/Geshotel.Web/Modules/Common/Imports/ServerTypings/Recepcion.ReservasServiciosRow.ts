
namespace Geshotel.Recepcion {
    export interface ReservasServiciosRow {
        ServicioReservaId?: number;
        ReservaId?: number;
        ServicioId?: number;
        UnidadCalculoId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Cantidad?: number;
        UserId?: number;
        FechaModificacion?: string;
        FlagContrato?: number;
        PrecioServicio?: number;
        ServicioExtra?: number;
        ServicioNombreServicio?: string;
        UnidadCalculo?: string;
        Username?: string;
    }

    export namespace ReservasServiciosRow {
        export const idProperty = 'ServicioReservaId';
        export const localTextPrefix = 'Recepcion.ReservasServicios';

        export namespace Fields {
            export declare const ServicioReservaId: string;
            export declare const ReservaId: string;
            export declare const ServicioId: string;
            export declare const UnidadCalculoId: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
            export declare const Cantidad: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const FlagContrato: string;
            export declare const PrecioServicio: string;
            export declare const ServicioExtra: string;
            export declare const ServicioNombreServicio: string;
            export declare const UnidadCalculo: string;
            export declare const Username: string;
        }

        [
            'ServicioReservaId', 
            'ReservaId', 
            'ServicioId', 
            'UnidadCalculoId', 
            'FechaDesde', 
            'FechaHasta', 
            'Cantidad', 
            'UserId', 
            'FechaModificacion', 
            'FlagContrato', 
            'PrecioServicio', 
            'ServicioExtra', 
            'ServicioNombreServicio', 
            'UnidadCalculo', 
            'Username'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

