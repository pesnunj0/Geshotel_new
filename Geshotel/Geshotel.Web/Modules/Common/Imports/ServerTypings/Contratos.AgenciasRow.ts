
namespace Geshotel.Contratos {
    export interface AgenciasRow {
        ClienteId?: number;
        Razon?: string;
        DescCorta?: string;
        EmpresaId?: number;
        GrupoClienteId?: number;
        TipoDocumentoId?: string;
        Nif?: string;
        FechaDocumento?: string;
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
        UserId?: number;
        FechaModificacion?: string;
        ClienteBavel?: string;
        DingusExtras?: boolean;
        Empresa?: string;
        TipoDocumento?: string;
        Nacion?: string;
        Provincia?: string;
        FacturaNacion?: string;
        FacturaProvincia?: string;
        UserName?: string;
    }

    export namespace AgenciasRow {
        export const idProperty = 'ClienteId';
        export const nameProperty = 'Razon';
        export const localTextPrefix = 'Contratos.Agencias';
        export const lookupKey = 'Contratos.Agencias';

        export function getLookup(): Q.Lookup<AgenciasRow> {
            return Q.getLookup<AgenciasRow>('Contratos.Agencias');
        }

        export namespace Fields {
            export declare const ClienteId: string;
            export declare const Razon: string;
            export declare const DescCorta: string;
            export declare const EmpresaId: string;
            export declare const GrupoClienteId: string;
            export declare const TipoDocumentoId: string;
            export declare const Nif: string;
            export declare const FechaDocumento: string;
            export declare const Direccion: string;
            export declare const Poblacion: string;
            export declare const Zip: string;
            export declare const NacionId: string;
            export declare const ProvinciaId: string;
            export declare const CtaContableAnticipo: string;
            export declare const CtaContable: string;
            export declare const DptoContable: string;
            export declare const CtaDepositos: string;
            export declare const Telefono: string;
            export declare const Email: string;
            export declare const Fax: string;
            export declare const Contacto: string;
            export declare const TelefonoContacto: string;
            export declare const FaxContacto: string;
            export declare const EmailContacto: string;
            export declare const CifFra: string;
            export declare const DireccionFra: string;
            export declare const PoblacionFra: string;
            export declare const ZipFra: string;
            export declare const NacionIdFactura: string;
            export declare const ProvinciaIdFactura: string;
            export declare const ClienteFactura: string;
            export declare const ClienteHuesped: string;
            export declare const PermiteCredito: string;
            export declare const LimiteCredito: string;
            export declare const FacturaAnticipada: string;
            export declare const VencimientoFacturasId: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const ClienteBavel: string;
            export declare const DingusExtras: string;
            export declare const Empresa: string;
            export declare const TipoDocumento: string;
            export declare const Nacion: string;
            export declare const Provincia: string;
            export declare const FacturaNacion: string;
            export declare const FacturaProvincia: string;
            export declare const UserName: string;
        }

        ['ClienteId', 'Razon', 'DescCorta', 'EmpresaId', 'GrupoClienteId', 'TipoDocumentoId', 'Nif', 'FechaDocumento', 'Direccion', 'Poblacion', 'Zip', 'NacionId', 'ProvinciaId', 'CtaContableAnticipo', 'CtaContable', 'DptoContable', 'CtaDepositos', 'Telefono', 'Email', 'Fax', 'Contacto', 'TelefonoContacto', 'FaxContacto', 'EmailContacto', 'CifFra', 'DireccionFra', 'PoblacionFra', 'ZipFra', 'NacionIdFactura', 'ProvinciaIdFactura', 'ClienteFactura', 'ClienteHuesped', 'PermiteCredito', 'LimiteCredito', 'FacturaAnticipada', 'VencimientoFacturasId', 'UserId', 'FechaModificacion', 'ClienteBavel', 'DingusExtras', 'Empresa', 'TipoDocumento', 'Nacion', 'Provincia', 'FacturaNacion', 'FacturaProvincia', 'UserName'].forEach(x => (<any>Fields)[x] = x);
    }
}

