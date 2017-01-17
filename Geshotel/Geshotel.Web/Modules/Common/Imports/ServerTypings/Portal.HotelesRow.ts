namespace Geshotel.Portal {
    export interface HotelesRow {
        HotelId?: number;
        Hotel?: string;
        EmpresaId?: number;
        TipoHotelId?: number;
        CategoriaId?: number;
        NombreCorto?: string;
        Direccion?: string;
        Poblacion?: string;
        Zip?: string;
        ProvinciaId?: number;
        NacionId?: number;
        Telefono?: string;
        Fax?: string;
        CtaManocorriente?: string;
        DptoContable?: string;
        CtaContableCajas?: string;
        CtaContableBanco?: string;
        FechaInicioPrograma?: string;
        RutaFicheroPolicia?: string;
        ContadorFicheroPolicia?: number;
        IdentificadorFicheroPolicia?: string;
        EmailReservas?: string;
        EmailVentas?: string;
        EmailSmtp?: string;
        TextoCancelacion?: string;
        UsuarioIsta?: string;
        PasswordIsta?: string;
        UrlIsta?: string;
        MunicipioIsta?: string;
        NumeroRegistroIsta?: number;
        RutaBavel?: string;
        DingusUsuario?: string;
        DingusPassword?: string;
        DingusHotelCode?: string;
        DingusTraductor?: string;
        DingusUrl?: string;
        CheckinOnLine?: number;
        MinimoDiasCheckinOnline?: number;
        ZoomMapa?: number;
        Ancho?: number;
        Alto?: number;
        OverbookingLimit?: number;
        Empresa?: string;
        EmpresaEmpresaContable?: string;
        EmpresaDireccion?: string;
        EmpresaPoblacion?: string;
        EmpresaZip?: string;
        EmpresaProvinciaId?: number;
        EmpresaTelefono?: string;
        EmpresaFax?: string;
        EmpresaCif?: string;
        TipoHotel?: string;
        TipoHotelAbreviatura?: string;
        Categoria?: string;
        CategoriaAbreviatura?: string;
        Provincia?: string;
        Nacion?: string;
        ProvinciaComunidadAutonomaId?: number;
        ProvinciaProvinciaIsta?: string;
        ProvinciaDefectoIsta?: number;
    }

    export namespace HotelesRow {
        export const idProperty = 'HotelId';
        export const nameProperty = 'Hotel';
        export const localTextPrefix = 'Portal.Hoteles';
        export const lookupKey = 'Portal.Hoteles';

        export function getLookup(): Q.Lookup<HotelesRow> {
            return Q.getLookup<HotelesRow>('Portal.Hoteles');
        }

        export namespace Fields {
            export declare const HotelId: string;
            export declare const Hotel: string;
            export declare const EmpresaId: string;
            export declare const TipoHotelId: string;
            export declare const CategoriaId: string;
            export declare const NombreCorto: string;
            export declare const Direccion: string;
            export declare const Poblacion: string;
            export declare const Zip: string;
            export declare const ProvinciaId: string;
            export declare const NacionId: string;
            export declare const Telefono: string;
            export declare const Fax: string;
            export declare const CtaManocorriente: string;
            export declare const DptoContable: string;
            export declare const CtaContableCajas: string;
            export declare const CtaContableBanco: string;
            export declare const FechaInicioPrograma: string;
            export declare const RutaFicheroPolicia: string;
            export declare const ContadorFicheroPolicia: string;
            export declare const IdentificadorFicheroPolicia: string;
            export declare const EmailReservas: string;
            export declare const EmailVentas: string;
            export declare const EmailSmtp: string;
            export declare const TextoCancelacion: string;
            export declare const UsuarioIsta: string;
            export declare const PasswordIsta: string;
            export declare const UrlIsta: string;
            export declare const MunicipioIsta: string;
            export declare const NumeroRegistroIsta: string;
            export declare const RutaBavel: string;
            export declare const DingusUsuario: string;
            export declare const DingusPassword: string;
            export declare const DingusHotelCode: string;
            export declare const DingusTraductor: string;
            export declare const DingusUrl: string;
            export declare const CheckinOnLine: string;
            export declare const MinimoDiasCheckinOnline: string;
            export declare const ZoomMapa: string;
            export declare const Ancho: string;
            export declare const Alto: string;
            export declare const OverbookingLimit: string;
            export declare const Empresa: string;
            export declare const EmpresaEmpresaContable: string;
            export declare const EmpresaDireccion: string;
            export declare const EmpresaPoblacion: string;
            export declare const EmpresaZip: string;
            export declare const EmpresaProvinciaId: string;
            export declare const EmpresaTelefono: string;
            export declare const EmpresaFax: string;
            export declare const EmpresaCif: string;
            export declare const TipoHotel: string;
            export declare const TipoHotelAbreviatura: string;
            export declare const Categoria: string;
            export declare const CategoriaAbreviatura: string;
            export declare const Provincia: string;
            export declare const Nacion: string;
            export declare const ProvinciaComunidadAutonomaId: string;
            export declare const ProvinciaProvinciaIsta: string;
            export declare const ProvinciaDefectoIsta: string;
        }

        ['HotelId', 'Hotel', 'EmpresaId', 'TipoHotelId', 'CategoriaId', 'NombreCorto', 'Direccion', 'Poblacion', 'Zip', 'ProvinciaId', 'NacionId', 'Telefono', 'Fax', 'CtaManocorriente', 'DptoContable', 'CtaContableCajas', 'CtaContableBanco', 'FechaInicioPrograma', 'RutaFicheroPolicia', 'ContadorFicheroPolicia', 'IdentificadorFicheroPolicia', 'EmailReservas', 'EmailVentas', 'EmailSmtp', 'TextoCancelacion', 'UsuarioIsta', 'PasswordIsta', 'UrlIsta', 'MunicipioIsta', 'NumeroRegistroIsta', 'RutaBavel', 'DingusUsuario', 'DingusPassword', 'DingusHotelCode', 'DingusTraductor', 'DingusUrl', 'CheckinOnLine', 'MinimoDiasCheckinOnline', 'ZoomMapa', 'Ancho', 'Alto', 'OverbookingLimit', 'Empresa', 'EmpresaEmpresaContable', 'EmpresaDireccion', 'EmpresaPoblacion', 'EmpresaZip', 'EmpresaProvinciaId', 'EmpresaTelefono', 'EmpresaFax', 'EmpresaCif', 'TipoHotel', 'TipoHotelAbreviatura', 'Categoria', 'CategoriaAbreviatura', 'Provincia', 'Nacion', 'ProvinciaComunidadAutonomaId', 'ProvinciaProvinciaIsta', 'ProvinciaDefectoIsta'].forEach(x => (<any>Fields)[x] = x);
    }
}

