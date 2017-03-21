
namespace Geshotel.Contratos {
    export interface HabitacionesRow {
        HabitacionId?: number;
        HotelId?: number;
        NumeroHabitacion?: string;
        TipoHabitacionId?: number;
        Extension?: number;
        Observaciones?: string;
        SituacionId?: number;
        FechaInicio?: string;
        EstadoTelefono?: number;
        EstadoProcesado?: number;
        HabitacionIsta?: string;
        ZonaLimpiezaId?: number;
        Lat?: number;
        Lng?: number;
        PrimaryImage?: string;
        Galleryimages?: string;
        Planta?: number;
        UserId?: number;
        FechaModificacion?: string;
        Hotel?: string;
        EmpresaId?: number;
        TipoHabitacionDescCorta?: string;
        TipoHabitacionDescripcion?: string;
        Situacion?: string;
        ZonaLimpiezaNombreZona?: string;
    }

    export namespace HabitacionesRow {
        export const idProperty = 'HabitacionId';
        export const nameProperty = 'NumeroHabitacion';
        export const localTextPrefix = 'Contratos.Habitaciones';
        export const lookupKey = 'Contratos.Habitaciones';

        export function getLookup(): Q.Lookup<HabitacionesRow> {
            return Q.getLookup<HabitacionesRow>('Contratos.Habitaciones');
        }

        export namespace Fields {
            export declare const HabitacionId: string;
            export declare const HotelId: string;
            export declare const NumeroHabitacion: string;
            export declare const TipoHabitacionId: string;
            export declare const Extension: string;
            export declare const Observaciones: string;
            export declare const SituacionId: string;
            export declare const FechaInicio: string;
            export declare const EstadoTelefono: string;
            export declare const EstadoProcesado: string;
            export declare const HabitacionIsta: string;
            export declare const ZonaLimpiezaId: string;
            export declare const Lat: string;
            export declare const Lng: string;
            export declare const PrimaryImage: string;
            export declare const Galleryimages: string;
            export declare const Planta: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const Hotel: string;
            export declare const EmpresaId: string;
            export declare const TipoHabitacionDescCorta: string;
            export declare const TipoHabitacionDescripcion: string;
            export declare const Situacion: string;
            export declare const ZonaLimpiezaNombreZona: string;
        }

        ['HabitacionId', 'HotelId', 'NumeroHabitacion', 'TipoHabitacionId', 'Extension', 'Observaciones', 'SituacionId', 'FechaInicio', 'EstadoTelefono', 'EstadoProcesado', 'HabitacionIsta', 'ZonaLimpiezaId', 'Lat', 'Lng', 'PrimaryImage', 'Galleryimages', 'Planta', 'UserId', 'FechaModificacion', 'Hotel', 'EmpresaId', 'TipoHabitacionDescCorta', 'TipoHabitacionDescripcion', 'Situacion', 'ZonaLimpiezaNombreZona'].forEach(x => (<any>Fields)[x] = x);
    }
}

