namespace Geshotel.Contratos {
    export interface ContratosRow {
        ContratoId?: number;
        HotelId?: number;
        ClienteId?: number;
        FechaContrato?: string;
        FechaDesde?: string;
        FechaHasta?: string;
        NumeroContratoCliente?: string;
        UserId?: number;
        FechaModificacion?: string;
        TemporadaId?: number;
        ImpuestoIncluido?: boolean;
        MercadoId?: number;
        HotelName?: string;
        ClienteName?: string;
    }

    export namespace ContratosRow {
        export const idProperty = 'ContratoId';
        export const nameProperty = 'NumeroContratoCliente';
        export const localTextPrefix = 'Contratos.Contratos';

        export namespace Fields {
            export declare const ContratoId: string;
            export declare const HotelId: string;
            export declare const ClienteId: string;
            export declare const FechaContrato: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
            export declare const NumeroContratoCliente: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const TemporadaId: string;
            export declare const ImpuestoIncluido: string;
            export declare const MercadoId: string;
            export declare const HotelName: string;
            export declare const ClienteName: string;
        }

        ['ContratoId', 'HotelId', 'ClienteId', 'FechaContrato', 'FechaDesde', 'FechaHasta', 'NumeroContratoCliente', 'UserId', 'FechaModificacion', 'TemporadaId', 'ImpuestoIncluido', 'MercadoId', 'HotelName', 'ClienteName'].forEach(x => (<any>Fields)[x] = x);
    }
}

