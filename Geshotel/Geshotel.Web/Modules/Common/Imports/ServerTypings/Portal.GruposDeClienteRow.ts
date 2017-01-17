namespace Geshotel.Portal {
    export interface GruposDeClienteRow {
        GrupoClienteId?: number;
        NombreGrupo?: string;
        EmpresaId?: number;
        CtaContable?: string;
        UserId?: number;
        FechaModificacion?: string;
        Huesped?: number;
        Contratos?: number;
        Facturar?: number;
        Agencia?: number;
        Perfil?: number;
    }

    export namespace GruposDeClienteRow {
        export const idProperty = 'GrupoClienteId';
        export const nameProperty = 'NombreGrupo';
        export const localTextPrefix = 'Portal.GruposDeCliente';
        export const lookupKey = 'Portal.GruposDeCliente';

        export function getLookup(): Q.Lookup<GruposDeClienteRow> {
            return Q.getLookup<GruposDeClienteRow>('Portal.GruposDeCliente');
        }

        export namespace Fields {
            export declare const GrupoClienteId: string;
            export declare const NombreGrupo: string;
            export declare const EmpresaId: string;
            export declare const CtaContable: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const Huesped: string;
            export declare const Contratos: string;
            export declare const Facturar: string;
            export declare const Agencia: string;
            export declare const Perfil: string;
        }

        ['GrupoClienteId', 'NombreGrupo', 'EmpresaId', 'CtaContable', 'UserId', 'FechaModificacion', 'Huesped', 'Contratos', 'Facturar', 'Agencia', 'Perfil'].forEach(x => (<any>Fields)[x] = x);
    }
}

