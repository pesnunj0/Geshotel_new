
namespace Geshotel.Contratos {
    export interface MercadosRow {
        MercadoId?: number;
        Mercado?: string;
        EmpresaId?: number;
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
    }

    export namespace MercadosRow {
        export const idProperty = 'MercadoId';
        export const nameProperty = 'Mercado';
        export const localTextPrefix = 'Contratos.Mercados';

        export namespace Fields {
            export declare const MercadoId;
            export declare const Mercado;
            export declare const EmpresaId;
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
        }

        ['MercadoId', 'Mercado', 'EmpresaId', 'Empresa', 'EmpresaEmpresaContable', 'EmpresaDireccion', 'EmpresaPoblacion', 'EmpresaZip', 'EmpresaProvinciaId', 'EmpresaTelefono', 'EmpresaFax', 'EmpresaCif', 'EmpresaRutaFicheros'].forEach(x => (<any>Fields)[x] = x);
    }
}

