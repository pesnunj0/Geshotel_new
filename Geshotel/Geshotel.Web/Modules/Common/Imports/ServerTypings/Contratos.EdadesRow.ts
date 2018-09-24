
namespace Geshotel.Contratos {
    export interface EdadesRow {
        EdadesId?: number;
        HotelId?: number;
        ClienteId?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        TipoHuespedId?: number;
        EdadMinima?: number;
        EdadMaxima?: number;
        UserId?: number;
        FechaModificacion?: string;
        HotelName?: string;
        Touroperador?: string;
        EmpresaId?: number;
        Empresa?: string;
        UserName?: string;
        TipoHuesped?: string;
    }

    export namespace EdadesRow {
        export const idProperty = 'EdadesId';
        export const nameProperty = 'Touroperador';
        export const localTextPrefix = 'Contratos.ContratosEdades';

        export namespace Fields {
            export declare const EdadesId: string;
            export declare const HotelId: string;
            export declare const ClienteId: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
            export declare const TipoHuespedId: string;
            export declare const EdadMinima: string;
            export declare const EdadMaxima: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const HotelName: string;
            export declare const Touroperador: string;
            export declare const EmpresaId: string;
            export declare const Empresa: string;
            export declare const UserName: string;
            export declare const TipoHuesped: string;
        }

        [
            'EdadesId', 
            'HotelId', 
            'ClienteId', 
            'FechaDesde', 
            'FechaHasta', 
            'TipoHuespedId', 
            'EdadMinima', 
            'EdadMaxima', 
            'UserId', 
            'FechaModificacion', 
            'HotelName', 
            'Touroperador', 
            'EmpresaId', 
            'Empresa', 
            'UserName', 
            'TipoHuesped'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

