namespace Geshotel.Portal {
    export interface TiposHabitacionRow {
        TipoHabitacionId?: number;
        DescCorta?: string;
        Descripcion?: string;
        GrupoHabitacionId?: number;
        NumeroPersonas?: number;
        Desvios?: number;
        NoShow?: number;
    }

    export namespace TiposHabitacionRow {
        export const idProperty = 'TipoHabitacionId';
        export const nameProperty = 'DescCorta';
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
        }

        ['TipoHabitacionId', 'DescCorta', 'Descripcion', 'GrupoHabitacionId', 'NumeroPersonas', 'Desvios', 'NoShow'].forEach(x => (<any>Fields)[x] = x);
    }
}

