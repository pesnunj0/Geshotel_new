namespace Geshotel.Portal {
    export interface EmpresasRow {
        EmpresaId?: number;
        Empresa?: string;
        EmpresaContable?: string;
        Direccion?: string;
        Poblacion?: string;
        Zip?: string;
        ProvinciaId?: number;
        Telefono?: string;
        Fax?: string;
        Cif?: string;
        RutaFicheros?: string;
        Provincia?: string;
        ProvinciaComunidadAutonomaId?: number;
        ProvinciaNacionId?: number;
        ProvinciaProvinciaIsta?: string;
        ProvinciaDefectoIsta?: number;
    }

    export namespace EmpresasRow {
        export const idProperty = 'EmpresaId';
        export const nameProperty = 'Empresa';
        export const localTextPrefix = 'Portal.Empresas';
        export const lookupKey = 'Portal.Empresas';

        export function getLookup(): Q.Lookup<EmpresasRow> {
            return Q.getLookup<EmpresasRow>('Portal.Empresas');
        }

        export namespace Fields {
            export declare const EmpresaId: string;
            export declare const Empresa: string;
            export declare const EmpresaContable: string;
            export declare const Direccion: string;
            export declare const Poblacion: string;
            export declare const Zip: string;
            export declare const ProvinciaId: string;
            export declare const Telefono: string;
            export declare const Fax: string;
            export declare const Cif: string;
            export declare const RutaFicheros: string;
            export declare const Provincia: string;
            export declare const ProvinciaComunidadAutonomaId: string;
            export declare const ProvinciaNacionId: string;
            export declare const ProvinciaProvinciaIsta: string;
            export declare const ProvinciaDefectoIsta: string;
        }

        ['EmpresaId', 'Empresa', 'EmpresaContable', 'Direccion', 'Poblacion', 'Zip', 'ProvinciaId', 'Telefono', 'Fax', 'Cif', 'RutaFicheros', 'Provincia', 'ProvinciaComunidadAutonomaId', 'ProvinciaNacionId', 'ProvinciaProvinciaIsta', 'ProvinciaDefectoIsta'].forEach(x => (<any>Fields)[x] = x);
    }
}

