namespace Geshotel.Portal {
    export interface TiposHabitacionRow {
        TipoHabitacionId?: number;
        DescCorta?: string;
        Descripcion?: string;
        GrupoHabitacionId?: number;
        NumeroPersonas?: number;
        Desvios?: number;
        NoShow?: number;
        GrupoHabitacion?: string;
    }

    export namespace TiposHabitacionRow {
        export const idProperty = 'TipoHabitacionId';
        export const nameProperty = 'Descripcion';
        export const localTextPrefix = 'Portal.TiposHabitacion';
        export const lookupKey = 'Portal.TiposHabitacion';

        export function getLookup(): Q.Lookup<TiposHabitacionRow> {
            return Q.getLookup<TiposHabitacionRow>('Portal.TiposHabitacion');
        }

        export namespace Fields {
            export declare const TipoHabitacionId: string;
            export declare const DescCorta: string;
            export declare const Descripcion: string;
            export declare const GrupoHabitacionId: string;
            export declare const NumeroPersonas: string;
            export declare const Desvios: string;
            export declare const NoShow: string;
            export declare const GrupoHabitacion: string;
        }

        ['TipoHabitacionId', 'DescCorta', 'Descripcion', 'GrupoHabitacionId', 'NumeroPersonas', 'Desvios', 'NoShow', 'GrupoHabitacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

