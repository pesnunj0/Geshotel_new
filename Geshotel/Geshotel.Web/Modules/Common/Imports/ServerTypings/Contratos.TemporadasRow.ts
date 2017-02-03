namespace Geshotel.Contratos {
    export interface TemporadasRow {
        TemporadaId?: number;
        Temporada?: string;
        EmpresaId?: number;
        Ano?: number;
        FechaDesde?: string;
        FechaHasta?: string;
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

    export namespace TemporadasRow {
        export const idProperty = 'TemporadaId';
        export const nameProperty = 'Temporada';
        export const localTextPrefix = 'Contratos.Temporadas';

        export namespace Fields {
            export declare const TemporadaId: string;
            export declare const Temporada: string;
            export declare const EmpresaId: string;
            export declare const Ano: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
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

        ['TemporadaId', 'Temporada', 'EmpresaId', 'Ano', 'FechaDesde', 'FechaHasta', 'Empresa', 'EmpresaEmpresaContable', 'EmpresaDireccion', 'EmpresaPoblacion', 'EmpresaZip', 'EmpresaProvinciaId', 'EmpresaTelefono', 'EmpresaFax', 'EmpresaCif', 'EmpresaRutaFicheros'].forEach(x => (<any>Fields)[x] = x);
    }
}

