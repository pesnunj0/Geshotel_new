
namespace Geshotel.Portal {
    export interface GruposHabitacionRow {
        HabitacionId?: number;
        Habitacion?: string;
    }

    export namespace GruposHabitacionRow {
        export const idProperty = 'HabitacionId';
        export const nameProperty = 'Habitacion';
        export const localTextPrefix = 'Portal.GruposHabitacion';
        export const lookupKey = 'Portal.GruposHabitacion';

        export function getLookup(): Q.Lookup<GruposHabitacionRow> {
            return Q.getLookup<GruposHabitacionRow>('Portal.GruposHabitacion');
        }

        export namespace Fields {
            export declare const HabitacionId: string;
            export declare const Habitacion: string;
        }

        [
            'HabitacionId', 
            'Habitacion'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

