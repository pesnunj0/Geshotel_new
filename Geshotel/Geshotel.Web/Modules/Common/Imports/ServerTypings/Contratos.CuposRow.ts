namespace Geshotel.Contratos {
    export interface CuposRow {
        CupoId?: number;
        ClienteId?: number;
        HotelId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        TipoHabitacionId?: number;
        Garantia?: number;
        ReservaAutomatica?: boolean;
        Cupo?: number;
        UserId?: number;
        FechaModificacion?: string;
        ClienteRazon?: string;
        ClienteDescCorta?: string;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        TipoHabitacionDescCorta?: string;
        TipoHabitacionDescripcion?: string;
        UserName?: string;
    }

    export namespace CuposRow {
        export const idProperty = 'CupoId';
        export const localTextPrefix = 'Contratos.Cupos';
        export const lookupKey = 'Contratos.Cupos';

        export function getLookup(): Q.Lookup<CuposRow> {
            return Q.getLookup<CuposRow>('Contratos.Cupos');
        }

        export namespace Fields {
            export declare const CupoId: string;
            export declare const ClienteId: string;
            export declare const HotelId: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
            export declare const TipoHabitacionId: string;
            export declare const Garantia: string;
            export declare const ReservaAutomatica: string;
            export declare const Cupo: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const ClienteRazon: string;
            export declare const ClienteDescCorta: string;
            export declare const HotelName: string;
            export declare const EmpresaId: string;
            export declare const Empresa: string;
            export declare const TipoHabitacionDescCorta: string;
            export declare const TipoHabitacionDescripcion: string;
            export declare const UserName: string;
        }

        ['CupoId', 'ClienteId', 'HotelId', 'FechaDesde', 'FechaHasta', 'TipoHabitacionId', 'Garantia', 'ReservaAutomatica', 'Cupo', 'UserId', 'FechaModificacion', 'ClienteRazon', 'ClienteDescCorta', 'HotelName', 'EmpresaId', 'Empresa', 'TipoHabitacionDescCorta', 'TipoHabitacionDescripcion', 'UserName'].forEach(x => (<any>Fields)[x] = x);
    }
}

