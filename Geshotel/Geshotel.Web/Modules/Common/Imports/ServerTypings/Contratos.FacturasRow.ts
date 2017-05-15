namespace Geshotel.Contratos {
    export interface FacturasRow {
        FacturaId?: number;
        NumeroFactura?: number;
        SerieId?: number;
        FechaFactura?: string;
        HotelId?: number;
        ClienteId?: number;
        FormaPagoId?: number;
        DireccionFactura?: string;
        PoblacionFactura?: string;
        Zip?: string;
        ProvinciaId?: number;
        FechaVencimiento?: string;
        EstadoFacturaId?: number;
        RefFra1?: string;
        RefFra2?: string;
        IdFacturaRectificada?: number;
        MotivoRectificacion?: string;
        UserId?: number;
        FechaModificacion?: string;
    }

    export namespace FacturasRow {
        export const idProperty = 'FacturaId';
        export const nameProperty = 'DireccionFactura';
        export const localTextPrefix = 'Contratos.Facturas';

        export namespace Fields {
            export declare const FacturaId: string;
            export declare const NumeroFactura: string;
            export declare const SerieId: string;
            export declare const FechaFactura: string;
            export declare const HotelId: string;
            export declare const ClienteId: string;
            export declare const FormaPagoId: string;
            export declare const DireccionFactura: string;
            export declare const PoblacionFactura: string;
            export declare const Zip: string;
            export declare const ProvinciaId: string;
            export declare const FechaVencimiento: string;
            export declare const EstadoFacturaId: string;
            export declare const RefFra1: string;
            export declare const RefFra2: string;
            export declare const IdFacturaRectificada: string;
            export declare const MotivoRectificacion: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
        }

        ['FacturaId', 'NumeroFactura', 'SerieId', 'FechaFactura', 'HotelId', 'ClienteId', 'FormaPagoId', 'DireccionFactura', 'PoblacionFactura', 'Zip', 'ProvinciaId', 'FechaVencimiento', 'EstadoFacturaId', 'RefFra1', 'RefFra2', 'IdFacturaRectificada', 'MotivoRectificacion', 'UserId', 'FechaModificacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

