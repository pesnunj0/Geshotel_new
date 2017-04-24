﻿
namespace Geshotel.Recepcion {
    export interface ReservasHuespedesRow {
        ReservasHuespedesId?: number;
        ReservaId?: number;
        HuespedId?: number;
        FechaLlegada?: string;
        FechaSalida?: string;
        HabitacionId?: number;
        Edad?: number;
        ReservaHotelId?: number;
        ReservaEstadoReservaId?: number;
        ReservaFechaPrevistaLlegada?: string;
        ReservaFechaPrevistaSalida?: string;
        Nombre?: string;
        Apellidos?: string;
        NombreCompleto?: string;
        TipoDocumentoId?: string;
        TipoDocumento?: string;
        FechaDocumento?: string;
        Nif?: string;
        FechaNacimiento?: string;
        Direccion?: string;
        Poblacion?: string;
        ProvinciaId?: number;
        Provincia?: string;
        NacionId?: number;
        Nacion?: string;
        Telefono?: string;
        Zip?: string;
        Email?: string;
        TarjetaFidelizacion?: string;
        NumeroHabitacion?: string;
        SexoId?: string;
        Sexo?: string;
        HotelId?: number;
        EmpresaId?: number;
    }

    export namespace ReservasHuespedesRow {
        export const idProperty = 'ReservasHuespedesId';
        export const localTextPrefix = 'Recepcion.ReservasHuespedes';

        export namespace Fields {
            export declare const ReservasHuespedesId: string;
            export declare const ReservaId: string;
            export declare const HuespedId: string;
            export declare const FechaLlegada: string;
            export declare const FechaSalida: string;
            export declare const HabitacionId: string;
            export declare const Edad: string;
            export declare const ReservaHotelId: string;
            export declare const ReservaEstadoReservaId: string;
            export declare const ReservaFechaPrevistaLlegada: string;
            export declare const ReservaFechaPrevistaSalida: string;
            export declare const Nombre: string;
            export declare const Apellidos: string;
            export declare const NombreCompleto: string;
            export declare const TipoDocumentoId: string;
            export declare const TipoDocumento: string;
            export declare const FechaDocumento: string;
            export declare const Nif: string;
            export declare const FechaNacimiento: string;
            export declare const Direccion: string;
            export declare const Poblacion: string;
            export declare const ProvinciaId: string;
            export declare const Provincia: string;
            export declare const NacionId: string;
            export declare const Nacion: string;
            export declare const Telefono: string;
            export declare const Zip: string;
            export declare const Email: string;
            export declare const TarjetaFidelizacion: string;
            export declare const NumeroHabitacion: string;
            export declare const SexoId: string;
            export declare const Sexo: string;
            export declare const HotelId: string;
            export declare const EmpresaId: string;
        }

        ['ReservasHuespedesId', 'ReservaId', 'HuespedId', 'FechaLlegada', 'FechaSalida', 'HabitacionId', 'Edad', 'ReservaHotelId', 'ReservaEstadoReservaId', 'ReservaFechaPrevistaLlegada', 'ReservaFechaPrevistaSalida', 'Nombre', 'Apellidos', 'NombreCompleto', 'TipoDocumentoId', 'TipoDocumento', 'FechaDocumento', 'Nif', 'FechaNacimiento', 'Direccion', 'Poblacion', 'ProvinciaId', 'Provincia', 'NacionId', 'Nacion', 'Telefono', 'Zip', 'Email', 'TarjetaFidelizacion', 'NumeroHabitacion', 'SexoId', 'Sexo', 'HotelId', 'EmpresaId'].forEach(x => (<any>Fields)[x] = x);
    }
}

