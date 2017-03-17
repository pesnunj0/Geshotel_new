namespace Geshotel.Portal {
    export interface GruposDeServiciosRow {
        GrupoServicioId?: number;
        NombreGrupo?: string;
        CtaContable?: string;
    }

    export namespace GruposDeServiciosRow {
        export const idProperty = 'GrupoServicioId';
        export const nameProperty = 'NombreGrupo';
        export const localTextPrefix = 'Portal.GruposDeServicios';
        export const lookupKey = 'Portal.GruposDeServicio';

        export function getLookup(): Q.Lookup<GruposDeServiciosRow> {
            return Q.getLookup<GruposDeServiciosRow>('Portal.GruposDeServicio');
        }

        export namespace Fields {
            export declare const GrupoServicioId: string;
            export declare const NombreGrupo: string;
            export declare const CtaContable: string;
        }

        ['GrupoServicioId', 'NombreGrupo', 'CtaContable'].forEach(x => (<any>Fields)[x] = x);
    }
}

