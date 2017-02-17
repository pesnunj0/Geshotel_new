
namespace Geshotel.Contratos {
    export interface TiposHabitacionHotelRow {
        TipoHabitacionHotelId?: number;
        HotelId?: number;
        TipoHabitacionId?: number;
        ServicioId?: number;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        TipoHabitacionName?: string;
        ServicioName?: string;
    }

    export namespace TiposHabitacionHotelRow {
        export const idProperty = 'TipoHabitacionHotelId';
        export const localTextPrefix = 'Contratos.TiposHabitacionHotel';

        export namespace Fields {
            export declare const TipoHabitacionHotelId: string;
            export declare const HotelId: string;
            export declare const TipoHabitacionId: string;
            export declare const ServicioId: string;
            export declare const HotelName: string;
            export declare const EmpresaId: string;
            export declare const Empresa: string;
            export declare const TipoHabitacionName: string;
            export declare const ServicioName: string;
        }

        ['TipoHabitacionHotelId', 'HotelId', 'TipoHabitacionId', 'ServicioId', 'HotelName', 'EmpresaId', 'Empresa', 'TipoHabitacionName', 'ServicioName'].forEach(x => (<any>Fields)[x] = x);
    }
}

