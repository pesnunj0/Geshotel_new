
namespace Geshotel.Contratos {
    export interface AgenciasRow {
        ClienteId?: number;
        Razon?: string;
        DescCorta?: string;
        Nombre?: string;
        Apellidos?: string;
        EmpresaId?: number;
        AgenciaId?: number;
        MercadoId?: number;
        ClienteDefecto?: boolean;
        GrupoClienteId?: number;
        TipoDocumentoId?: string;
        Nif?: string;
        FechaDocumento?: string;
        SexoId?: string;
        Direccion?: string;
        Poblacion?: string;
        Zip?: string;
        NacionId?: number;
        ProvinciaId?: number;
        CtaContableAnticipo?: string;
        CtaContable?: string;
        DptoContable?: string;
        CtaDepositos?: string;
        Telefono?: string;
        Email?: string;
        Fax?: string;
        Contacto?: string;
        TelefonoContacto?: string;
        FaxContacto?: string;
        EmailContacto?: string;
        AceptaLopd?: string;
        CifFra?: string;
        DireccionFra?: string;
        PoblacionFra?: string;
        ZipFra?: string;
        NacionIdFactura?: number;
        ProvinciaIdFactura?: number;
        ClienteFactura?: boolean;
        ClienteHuesped?: boolean;
        PermiteCredito?: boolean;
        LimiteCredito?: number;
        FacturaAnticipada?: boolean;
        VencimientoFacturasId?: number;
        FechaNacimiento?: string;
        UserId?: number;
        FechaModificacion?: string;
        ClienteBavel?: string;
        Foto1?: string;
        Foto2?: string;
        DingusExtras?: boolean;
        IdClubhd?: string;
    }

    export namespace AgenciasRow {
        export const idProperty = 'ClienteId';
        export const nameProperty = 'Razon';
        export const localTextPrefix = 'Contratos.Agencias';

        export namespace Fields {
            export declare const ClienteId;
            export declare const Razon;
            export declare const DescCorta;
            export declare const Nombre;
            export declare const Apellidos;
            export declare const EmpresaId;
            export declare const AgenciaId;
            export declare const MercadoId;
            export declare const ClienteDefecto;
            export declare const GrupoClienteId;
            export declare const TipoDocumentoId;
            export declare const Nif;
            export declare const FechaDocumento;
            export declare const SexoId;
            export declare const Direccion;
            export declare const Poblacion;
            export declare const Zip;
            export declare const NacionId;
            export declare const ProvinciaId;
            export declare const CtaContableAnticipo;
            export declare const CtaContable;
            export declare const DptoContable;
            export declare const CtaDepositos;
            export declare const Telefono;
            export declare const Email;
            export declare const Fax;
            export declare const Contacto;
            export declare const TelefonoContacto;
            export declare const FaxContacto;
            export declare const EmailContacto;
            export declare const AceptaLopd;
            export declare const CifFra;
            export declare const DireccionFra;
            export declare const PoblacionFra;
            export declare const ZipFra;
            export declare const NacionIdFactura;
            export declare const ProvinciaIdFactura;
            export declare const ClienteFactura;
            export declare const ClienteHuesped;
            export declare const PermiteCredito;
            export declare const LimiteCredito;
            export declare const FacturaAnticipada;
            export declare const VencimientoFacturasId;
            export declare const FechaNacimiento;
            export declare const UserId;
            export declare const FechaModificacion;
            export declare const ClienteBavel;
            export declare const Foto1;
            export declare const Foto2;
            export declare const DingusExtras;
            export declare const IdClubhd;
        }

        ['ClienteId', 'Razon', 'DescCorta', 'Nombre', 'Apellidos', 'EmpresaId', 'AgenciaId', 'MercadoId', 'ClienteDefecto', 'GrupoClienteId', 'TipoDocumentoId', 'Nif', 'FechaDocumento', 'SexoId', 'Direccion', 'Poblacion', 'Zip', 'NacionId', 'ProvinciaId', 'CtaContableAnticipo', 'CtaContable', 'DptoContable', 'CtaDepositos', 'Telefono', 'Email', 'Fax', 'Contacto', 'TelefonoContacto', 'FaxContacto', 'EmailContacto', 'AceptaLopd', 'CifFra', 'DireccionFra', 'PoblacionFra', 'ZipFra', 'NacionIdFactura', 'ProvinciaIdFactura', 'ClienteFactura', 'ClienteHuesped', 'PermiteCredito', 'LimiteCredito', 'FacturaAnticipada', 'VencimientoFacturasId', 'FechaNacimiento', 'UserId', 'FechaModificacion', 'ClienteBavel', 'Foto1', 'Foto2', 'DingusExtras', 'IdClubhd'].forEach(x => (<any>Fields)[x] = x);
    }
}

