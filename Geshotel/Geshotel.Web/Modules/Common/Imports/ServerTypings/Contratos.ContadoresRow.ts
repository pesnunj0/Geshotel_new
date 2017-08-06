
namespace Geshotel.Contratos {
    export interface ContadoresRow {
        ContadorId?: number;
        EmpresaId?: number;
        SerieId?: number;
        Ano?: number;
        Contador?: number;
        Empresa?: string;
        Serie?: string;
    }

    export namespace ContadoresRow {
        export const idProperty = 'ContadorId';
        export const localTextPrefix = 'Contratos.Contadores';

        export namespace Fields {
            export declare const ContadorId: string;
            export declare const EmpresaId: string;
            export declare const SerieId: string;
            export declare const Ano: string;
            export declare const Contador: string;
            export declare const Empresa: string;
            export declare const Serie: string;
        }

        ['ContadorId', 'EmpresaId', 'SerieId', 'Ano', 'Contador', 'Empresa', 'Serie'].forEach(x => (<any>Fields)[x] = x);
    }
}

