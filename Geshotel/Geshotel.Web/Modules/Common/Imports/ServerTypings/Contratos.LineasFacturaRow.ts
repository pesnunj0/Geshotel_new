
namespace Geshotel.Contratos {
    export interface LineasFacturaRow {
        LineaFacturaId?: number;
        HotelId?: number;
        Fecha?: string;
        FacturaId?: number;
        ReservaId?: number;
        ContratoId?: number;
        Descripcion?: string;
        Cantidad?: number;
        Precio?: number;
        ImpuestoId?: number;
        PorcImpuesto?: number;
        ServicioId?: number;
        UnidadCalculoId?: number;
        TipoLineaFactura?: string;
        PrecioProduccion?: number;
        PagFactura?: number;
        Costo?: number;
        UserId?: number;
        FechaModificacion?: string;
        SwAjuste?: number;
    }

    export namespace LineasFacturaRow {
        export const idProperty = 'LineaFacturaId';
        export const nameProperty = 'Descripcion';
        export const localTextPrefix = 'Contratos.LineasFactura';

        export namespace Fields {
            export declare const LineaFacturaId: string;
            export declare const HotelId: string;
            export declare const Fecha: string;
            export declare const FacturaId: string;
            export declare const ReservaId: string;
            export declare const ContratoId: string;
            export declare const Descripcion: string;
            export declare const Cantidad: string;
            export declare const Precio: string;
            export declare const ImpuestoId: string;
            export declare const PorcImpuesto: string;
            export declare const ServicioId: string;
            export declare const UnidadCalculoId: string;
            export declare const TipoLineaFactura: string;
            export declare const PrecioProduccion: string;
            export declare const PagFactura: string;
            export declare const Costo: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const SwAjuste: string;
        }

        ['LineaFacturaId', 'HotelId', 'Fecha', 'FacturaId', 'ReservaId', 'ContratoId', 'Descripcion', 'Cantidad', 'Precio', 'ImpuestoId', 'PorcImpuesto', 'ServicioId', 'UnidadCalculoId', 'TipoLineaFactura', 'PrecioProduccion', 'PagFactura', 'Costo', 'UserId', 'FechaModificacion', 'SwAjuste'].forEach(x => (<any>Fields)[x] = x);
    }
}

