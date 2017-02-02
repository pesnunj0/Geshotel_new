
namespace Geshotel.Contratos {
    export interface ContratosRow {
        ContratoId?: number;
        HotelId?: number;
        ClienteId?: number;
        FechaContrato?: string;
        FechaDesde?: string;
        FechaHasta?: string;
        ContratoIdOriginal?: number;
        ContratoIdSiguiente?: number;
        NumeroContratoCliente?: string;
        UserId?: number;
        FechaModificacion?: string;
        TemporadaId?: number;
        ImpuestoIncluido?: boolean;
        MercadoId?: number;
        ClienteIdPadre?: number;
    }

    export namespace ContratosRow {
        export const idProperty = 'ContratoId';
        export const nameProperty = 'NumeroContratoCliente';
        export const localTextPrefix = 'Contratos.Contratos';

        export namespace Fields {
            export declare const ContratoId;
            export declare const HotelId;
            export declare const ClienteId;
            export declare const FechaContrato;
            export declare const FechaDesde;
            export declare const FechaHasta;
            export declare const ContratoIdOriginal;
            export declare const ContratoIdSiguiente;
            export declare const NumeroContratoCliente;
            export declare const UserId;
            export declare const FechaModificacion;
            export declare const TemporadaId;
            export declare const ImpuestoIncluido;
            export declare const MercadoId;
            export declare const ClienteIdPadre;
        }

        ['ContratoId', 'HotelId', 'ClienteId', 'FechaContrato', 'FechaDesde', 'FechaHasta', 'ContratoIdOriginal', 'ContratoIdSiguiente', 'NumeroContratoCliente', 'UserId', 'FechaModificacion', 'TemporadaId', 'ImpuestoIncluido', 'MercadoId', 'ClienteIdPadre'].forEach(x => (<any>Fields)[x] = x);
    }
}

