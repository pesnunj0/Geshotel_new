
namespace Geshotel.Contratos {
    export interface TiposHabitacionHotelRow {
        TipoHabitacionHotelId?: number;
        HotelId?: number;
        TipoHabitacionId?: number;
        ServicioId?: number;
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
    }

    export namespace TiposHabitacionHotelRow {
        export const idProperty = 'TipoHabitacionHotelId';
        export const localTextPrefix = 'Contratos.TiposHabitacionHotel';

        export namespace Fields {
            export declare const TipoHabitacionHotelId;
            export declare const HotelId;
            export declare const TipoHabitacionId;
            export declare const ServicioId;
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
        }

        ['TipoHabitacionHotelId', 'HotelId', 'TipoHabitacionId', 'ServicioId', 'ServicioNombreServicio', 'ServicioAbreviatura', 'ServicioTipoServicioId', 'ServicioSwProduccion', 'ServicioSwDescuento', 'ServicioSwAjustes', 'ServicioSwGastos', 'ServicioSwPension', 'ServicioSwRectificativa', 'ServicioTipoUnidadCalculoId', 'ServicioConceptoAceleradorReservasId', 'ServicioCosto', 'ServicioSumaServicioId', 'ServicioRestaServicioId', 'ServicioUserId', 'ServicioFechaModificacion', 'ServicioTipoHab', 'ServicioTipoPension'].forEach(x => (<any>Fields)[x] = x);
    }
}

