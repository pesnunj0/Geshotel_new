
namespace Geshotel.Portal {
    export interface TiposHabitacionHotelRow {
        TipoHabitacionHotelId?: number;
        HotelId?: number;
        TipoHabitacionId?: number;
        ServicioId?: number;
        HotelName?: string;
        HotelEmpresaId?: number;
        TipoHabitacionName?: string;
        ServicioName?: string;
    }

    export namespace TiposHabitacionHotelRow {
        export const idProperty = 'TipoHabitacionHotelId';
        export const localTextPrefix = 'Portal.TiposHabitacionHotel';
        export const lookupKey = 'Portal.TiposHabitacionHotel';

        export function getLookup(): Q.Lookup<TiposHabitacionHotelRow> {
            return Q.getLookup<TiposHabitacionHotelRow>('Portal.TiposHabitacionHotel');
        }

        export namespace Fields {
            export declare const TipoHabitacionHotelId: string;
            export declare const HotelId: string;
            export declare const TipoHabitacionId: string;
            export declare const ServicioId: string;
            export declare const HotelName: string;
            export declare const HotelEmpresaId: string;
            export declare const TipoHabitacionName: string;
            export declare const ServicioName: string;
        }

        ['TipoHabitacionHotelId', 'HotelId', 'TipoHabitacionId', 'ServicioId', 'HotelName', 'HotelEmpresaId', 'TipoHabitacionName', 'ServicioName'].forEach(x => (<any>Fields)[x] = x);
    }
}

