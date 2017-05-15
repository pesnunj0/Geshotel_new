namespace Geshotel.Portal {
    export interface HabitacionesSituacionRow {
        SituacionId?: number;
        Situacion?: string;
    }

    export namespace HabitacionesSituacionRow {
        export const idProperty = 'SituacionId';
        export const nameProperty = 'Situacion';
        export const localTextPrefix = 'Portal.HabitacionesSituacion';
        export const lookupKey = 'Portal.HabitacionesSituacion';

        export function getLookup(): Q.Lookup<HabitacionesSituacionRow> {
            return Q.getLookup<HabitacionesSituacionRow>('Portal.HabitacionesSituacion');
        }

        export namespace Fields {
            export declare const SituacionId: string;
            export declare const Situacion: string;
        }

        ['SituacionId', 'Situacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

