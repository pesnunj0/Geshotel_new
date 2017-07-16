﻿
namespace Geshotel.Recepcion {
    export interface HabitacionesBloqueosRow {
        HabitacionBloqueoId?: number;
        HabitacionId?: number;
        TipoBloqueoId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Observaciones?: string;
        ReservaId?: number;
        UserId?: number;
        FechaModificacion?: string;
        HotelId?: number;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        HabitacionNumeroHabitacion?: string;
        HabitacionTipoHabitacionId?: number;
        TipoBloqueo?: string;
        Editable?: boolean;
        DescCorta?: string;
        UserName?: string;
    }

    export namespace HabitacionesBloqueosRow {
        export const idProperty = 'HabitacionBloqueoId';
        export const nameProperty = 'HabitacionNumeroHabitacion';
        export const localTextPrefix = 'Recepcion.HabitacionesBloqueos';

        export namespace Fields {
            export declare const HabitacionBloqueoId: string;
            export declare const HabitacionId: string;
            export declare const TipoBloqueoId: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
            export declare const Observaciones: string;
            export declare const ReservaId: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const HotelId: string;
            export declare const HotelName: string;
            export declare const EmpresaId: string;
            export declare const Empresa: string;
            export declare const HabitacionNumeroHabitacion: string;
            export declare const HabitacionTipoHabitacionId: string;
            export declare const TipoBloqueo: string;
            export declare const Editable: string;
            export declare const DescCorta: string;
            export declare const UserName: string;
        }

        ['HabitacionBloqueoId', 'HabitacionId', 'TipoBloqueoId', 'FechaDesde', 'FechaHasta', 'Observaciones', 'ReservaId', 'UserId', 'FechaModificacion', 'HotelId', 'HotelName', 'EmpresaId', 'Empresa', 'HabitacionNumeroHabitacion', 'HabitacionTipoHabitacionId', 'TipoBloqueo', 'Editable', 'DescCorta', 'UserName'].forEach(x => (<any>Fields)[x] = x);
    }
}

