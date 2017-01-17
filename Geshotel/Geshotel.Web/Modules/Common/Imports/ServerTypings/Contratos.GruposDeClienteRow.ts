
namespace Geshotel.Contratos {
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
        export const localTextPrefix = 'Contratos.GruposDeCliente';

        export namespace Fields {
            export declare const GrupoClienteId;
            export declare const NombreGrupo;
            export declare const EmpresaId;
            export declare const CtaContable;
            export declare const UserId;
            export declare const FechaModificacion;
            export declare const Huesped;
            export declare const Contratos;
            export declare const Facturar;
            export declare const Agencia;
            export declare const Perfil;
        }

        ['GrupoClienteId', 'NombreGrupo', 'EmpresaId', 'CtaContable', 'UserId', 'FechaModificacion', 'Huesped', 'Contratos', 'Facturar', 'Agencia', 'Perfil'].forEach(x => (<any>Fields)[x] = x);
    }
}

