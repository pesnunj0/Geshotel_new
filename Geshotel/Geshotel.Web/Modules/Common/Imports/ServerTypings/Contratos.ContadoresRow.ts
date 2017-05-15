namespace Geshotel.Contratos {
    export interface ContadoresRow {
        ContadorId?: number;
        EmpresaId?: number;
        SerieId?: number;
        Ano?: number;
        Contador?: number;
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
        }

        ['ContadorId', 'EmpresaId', 'SerieId', 'Ano', 'Contador'].forEach(x => (<any>Fields)[x] = x);
    }
}

