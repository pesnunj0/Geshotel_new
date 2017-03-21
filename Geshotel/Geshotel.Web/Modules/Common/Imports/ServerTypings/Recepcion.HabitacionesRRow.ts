
namespace Geshotel.Recepcion {
    export interface HabitacionesRRow {
        HabitacionBloqueoId?: number;
        HabitacionId?: number;
        TipoBloqueoId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Observaciones?: string;
        ReservaId?: number;
        UserId?: number;
        FechaModificacion?: string;
        HabitacionHotelId?: number;
        HabitacionNumeroHabitacion?: string;
        HabitacionTipoHabitacionId?: number;
        HabitacionExtension?: number;
        HabitacionObservaciones?: string;
        HabitacionSituacionId?: number;
        HabitacionFechaInicio?: string;
        HabitacionEstadoTelefono?: number;
        HabitacionEstadoProcesado?: number;
        HabitacionHabitacionIsta?: string;
        HabitacionZonaLimpiezaId?: number;
        HabitacionLat?: number;
        HabitacionLng?: number;
        HabitacionPrimaryImage?: string;
        HabitacionGalleryimages?: string;
        HabitacionPlanta?: number;
        HabitacionUserId?: number;
        HabitacionFechaModificacion?: string;
    }

    export namespace HabitacionesRRow {
        export const idProperty = 'HabitacionBloqueoId';
        export const nameProperty = 'Observaciones';
        export const localTextPrefix = 'Recepcion.HabitacionesR';

        export namespace Fields {
            export declare const HabitacionBloqueoId;
            export declare const HabitacionId;
            export declare const TipoBloqueoId;
            export declare const FechaDesde;
            export declare const FechaHasta;
            export declare const Observaciones;
            export declare const ReservaId;
            export declare const UserId;
            export declare const FechaModificacion;
            export declare const HabitacionHotelId: string;
            export declare const HabitacionNumeroHabitacion: string;
            export declare const HabitacionTipoHabitacionId: string;
            export declare const HabitacionExtension: string;
            export declare const HabitacionObservaciones: string;
            export declare const HabitacionSituacionId: string;
            export declare const HabitacionFechaInicio: string;
            export declare const HabitacionEstadoTelefono: string;
            export declare const HabitacionEstadoProcesado: string;
            export declare const HabitacionHabitacionIsta: string;
            export declare const HabitacionZonaLimpiezaId: string;
            export declare const HabitacionLat: string;
            export declare const HabitacionLng: string;
            export declare const HabitacionPrimaryImage: string;
            export declare const HabitacionGalleryimages: string;
            export declare const HabitacionPlanta: string;
            export declare const HabitacionUserId: string;
            export declare const HabitacionFechaModificacion: string;
        }

        ['HabitacionBloqueoId', 'HabitacionId', 'TipoBloqueoId', 'FechaDesde', 'FechaHasta', 'Observaciones', 'ReservaId', 'UserId', 'FechaModificacion', 'HabitacionHotelId', 'HabitacionNumeroHabitacion', 'HabitacionTipoHabitacionId', 'HabitacionExtension', 'HabitacionObservaciones', 'HabitacionSituacionId', 'HabitacionFechaInicio', 'HabitacionEstadoTelefono', 'HabitacionEstadoProcesado', 'HabitacionHabitacionIsta', 'HabitacionZonaLimpiezaId', 'HabitacionLat', 'HabitacionLng', 'HabitacionPrimaryImage', 'HabitacionGalleryimages', 'HabitacionPlanta', 'HabitacionUserId', 'HabitacionFechaModificacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

