namespace Geshotel.Contratos {
    export interface ReleasesRow {
        ReleaseId?: number;
        ClienteId?: number;
        HotelId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        Observaciones?: string;
        Dias?: number;
        UserId?: number;
        FechaModificacion?: string;
        ClienteRazon?: string;
        HotelName?: string;
        UserName?: string;
    }

    export namespace ReleasesRow {
        export const idProperty = 'ReleaseId';
        export const nameProperty = 'Observaciones';
        export const localTextPrefix = 'Contratos.Releases';

        export namespace Fields {
            export declare const ReleaseId: string;
            export declare const ClienteId: string;
            export declare const HotelId: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
            export declare const Observaciones: string;
            export declare const Dias: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const ClienteRazon: string;
            export declare const HotelName: string;
            export declare const UserName: string;
        }

        ['ReleaseId', 'ClienteId', 'HotelId', 'FechaDesde', 'FechaHasta', 'Observaciones', 'Dias', 'UserId', 'FechaModificacion', 'ClienteRazon', 'HotelName', 'UserName'].forEach(x => (<any>Fields)[x] = x);
    }
}

