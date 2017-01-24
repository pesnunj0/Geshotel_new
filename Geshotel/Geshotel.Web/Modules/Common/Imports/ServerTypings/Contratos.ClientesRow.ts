﻿namespace Geshotel.Contratos {
    export interface ClientesRow {
        ClienteId?: number;
        Razon?: string;
        DescCorta?: string;
        EmpresaId?: number;
        AgenciaId?: number;
        ClienteDefecto?: boolean;
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
        Agencia?: string;
        NombreGrupo?: string;
        Documento?: string;
        Nacion?: string;
        Provincia?: string;
        FacturaNacion?: string;
        FacturaProvincia?: string;
    }

    export namespace ClientesRow {
        export const idProperty = 'ClienteId';
        export const nameProperty = 'Razon';
        export const localTextPrefix = 'Contratos.Clientes';
        export const lookupKey = 'Contratos.Clientes';

        export function getLookup(): Q.Lookup<ClientesRow> {
            return Q.getLookup<ClientesRow>('Contratos.Clientes');
        }

        export namespace Fields {
            export declare const ClienteId: string;
            export declare const Razon: string;
            export declare const DescCorta: string;
            export declare const EmpresaId: string;
            export declare const AgenciaId: string;
            export declare const ClienteDefecto: string;
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
            export declare const Agencia: string;
            export declare const NombreGrupo: string;
            export declare const Documento: string;
            export declare const Nacion: string;
            export declare const Provincia: string;
            export declare const FacturaNacion: string;
            export declare const FacturaProvincia: string;
        }

        ['ClienteId', 'Razon', 'DescCorta', 'EmpresaId', 'AgenciaId', 'ClienteDefecto', 'GrupoClienteId', 'TipoDocumentoId', 'Nif', 'FechaDocumento', 'Direccion', 'Poblacion', 'Zip', 'NacionId', 'ProvinciaId', 'CtaContableAnticipo', 'CtaContable', 'DptoContable', 'CtaDepositos', 'Telefono', 'Email', 'Fax', 'Contacto', 'TelefonoContacto', 'FaxContacto', 'EmailContacto', 'CifFra', 'DireccionFra', 'PoblacionFra', 'ZipFra', 'NacionIdFactura', 'ProvinciaIdFactura', 'ClienteFactura', 'ClienteHuesped', 'PermiteCredito', 'LimiteCredito', 'FacturaAnticipada', 'VencimientoFacturasId', 'UserId', 'FechaModificacion', 'ClienteBavel', 'DingusExtras', 'Empresa', 'Agencia', 'NombreGrupo', 'Documento', 'Nacion', 'Provincia', 'FacturaNacion', 'FacturaProvincia'].forEach(x => (<any>Fields)[x] = x);
    }
}

