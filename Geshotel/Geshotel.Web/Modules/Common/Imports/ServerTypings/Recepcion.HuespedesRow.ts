
namespace Geshotel.Recepcion {
    export interface HuespedesRow {
        HuespedId?: number;
        EmpresaId?: number;
        Nombre?: string;
        Apellidos?: string;
        TipoDocumentoId?: string;
        Nif?: string;
        FechaDocumento?: string;
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
        EmpresaEmpresaContable?: string;
        EmpresaDireccion?: string;
        EmpresaPoblacion?: string;
        EmpresaZip?: string;
        EmpresaProvinciaId?: number;
        EmpresaTelefono?: string;
        EmpresaFax?: string;
        EmpresaCif?: string;
        EmpresaRutaFicheros?: string;
        TipoDocumentoDocumento?: string;
        Nacion?: string;
        NacionDescCorta?: string;
        NacionMonedaId?: number;
        NacionIdiomaId?: number;
        NacionNumeroIne?: number;
        NacionPaisIsta?: string;
        NacionDefecto?: number;
        NacionNombreReal?: string;
        NacionIdiomaMails?: string;
        Provincia?: string;
        ProvinciaComunidadAutonomaId?: number;
        ProvinciaNacionId?: number;
        ProvinciaProvinciaIsta?: string;
        ProvinciaDefectoIsta?: number;
    }

    export namespace HuespedesRow {
        export const idProperty = 'HuespedId';
        export const nameProperty = 'Nombre';
        export const localTextPrefix = 'Recepcion.Huespedes';

        export namespace Fields {
            export declare const HuespedId;
            export declare const EmpresaId;
            export declare const Nombre;
            export declare const Apellidos;
            export declare const TipoDocumentoId;
            export declare const Nif;
            export declare const FechaDocumento;
            export declare const SexoId;
            export declare const Direccion;
            export declare const Poblacion;
            export declare const Zip;
            export declare const NacionId;
            export declare const ProvinciaId;
            export declare const Telefono;
            export declare const Email;
            export declare const Foto1;
            export declare const Foto2;
            export declare const TarjetaFidelizacion;
            export declare const Empresa: string;
            export declare const EmpresaEmpresaContable: string;
            export declare const EmpresaDireccion: string;
            export declare const EmpresaPoblacion: string;
            export declare const EmpresaZip: string;
            export declare const EmpresaProvinciaId: string;
            export declare const EmpresaTelefono: string;
            export declare const EmpresaFax: string;
            export declare const EmpresaCif: string;
            export declare const EmpresaRutaFicheros: string;
            export declare const TipoDocumentoDocumento: string;
            export declare const Nacion: string;
            export declare const NacionDescCorta: string;
            export declare const NacionMonedaId: string;
            export declare const NacionIdiomaId: string;
            export declare const NacionNumeroIne: string;
            export declare const NacionPaisIsta: string;
            export declare const NacionDefecto: string;
            export declare const NacionNombreReal: string;
            export declare const NacionIdiomaMails: string;
            export declare const Provincia: string;
            export declare const ProvinciaComunidadAutonomaId: string;
            export declare const ProvinciaNacionId: string;
            export declare const ProvinciaProvinciaIsta: string;
            export declare const ProvinciaDefectoIsta: string;
        }

        ['HuespedId', 'EmpresaId', 'Nombre', 'Apellidos', 'TipoDocumentoId', 'Nif', 'FechaDocumento', 'SexoId', 'Direccion', 'Poblacion', 'Zip', 'NacionId', 'ProvinciaId', 'Telefono', 'Email', 'Foto1', 'Foto2', 'TarjetaFidelizacion', 'Empresa', 'EmpresaEmpresaContable', 'EmpresaDireccion', 'EmpresaPoblacion', 'EmpresaZip', 'EmpresaProvinciaId', 'EmpresaTelefono', 'EmpresaFax', 'EmpresaCif', 'EmpresaRutaFicheros', 'TipoDocumentoDocumento', 'Nacion', 'NacionDescCorta', 'NacionMonedaId', 'NacionIdiomaId', 'NacionNumeroIne', 'NacionPaisIsta', 'NacionDefecto', 'NacionNombreReal', 'NacionIdiomaMails', 'Provincia', 'ProvinciaComunidadAutonomaId', 'ProvinciaNacionId', 'ProvinciaProvinciaIsta', 'ProvinciaDefectoIsta'].forEach(x => (<any>Fields)[x] = x);
    }
}

