
namespace Geshotel.Recepcion {
    export interface HuespedesRow {
        HuespedId?: number;
        EmpresaId?: number;
        Nombre?: string;
        Apellidos?: string;
        NombreCompleto?: string;
        TipoDocumentoId?: string;
        Nif?: string;
        FechaDocumento?: string;
        FechaNacimiento?: string;
        SexoId?: string;
        Direccion?: string;
        Poblacion?: string;
        Zip?: string;
        NacionId?: number;
        ProvinciaId?: number;
        Telefono?: string;
        Email?: string;
        Foto1?: string;
        Foto2?: string;
        TarjetaFidelizacion?: string;
        Empresa?: string;
        TipoDocumento?: string;
        Nacion?: string;
        NacionDescCorta?: string;
        Provincia?: string;
        ReservaId?: number;
    }

    export namespace HuespedesRow {
        export const idProperty = 'HuespedId';
        export const nameProperty = 'Nombre';
        export const localTextPrefix = 'Recepcion.Huespedes';

        export namespace Fields {
            export declare const HuespedId: string;
            export declare const EmpresaId: string;
            export declare const Nombre: string;
            export declare const Apellidos: string;
            export declare const NombreCompleto: string;
            export declare const TipoDocumentoId: string;
            export declare const Nif: string;
            export declare const FechaDocumento: string;
            export declare const FechaNacimiento: string;
            export declare const SexoId: string;
            export declare const Direccion: string;
            export declare const Poblacion: string;
            export declare const Zip: string;
            export declare const NacionId: string;
            export declare const ProvinciaId: string;
            export declare const Telefono: string;
            export declare const Email: string;
            export declare const Foto1: string;
            export declare const Foto2: string;
            export declare const TarjetaFidelizacion: string;
            export declare const Empresa: string;
            export declare const TipoDocumento: string;
            export declare const Nacion: string;
            export declare const NacionDescCorta: string;
            export declare const Provincia: string;
            export declare const ReservaId: string;
        }

        [
            'HuespedId', 
            'EmpresaId', 
            'Nombre', 
            'Apellidos', 
            'NombreCompleto', 
            'TipoDocumentoId', 
            'Nif', 
            'FechaDocumento', 
            'FechaNacimiento', 
            'SexoId', 
            'Direccion', 
            'Poblacion', 
            'Zip', 
            'NacionId', 
            'ProvinciaId', 
            'Telefono', 
            'Email', 
            'Foto1', 
            'Foto2', 
            'TarjetaFidelizacion', 
            'Empresa', 
            'TipoDocumento', 
            'Nacion', 
            'NacionDescCorta', 
            'Provincia', 
            'ReservaId'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

