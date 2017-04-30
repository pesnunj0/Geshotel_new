
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
            export declare const LineaFacturaId;
            export declare const HotelId;
            export declare const Fecha;
            export declare const FacturaId;
            export declare const ReservaId;
            export declare const ContratoId;
            export declare const Descripcion;
            export declare const Cantidad;
            export declare const Precio;
            export declare const ImpuestoId;
            export declare const PorcImpuesto;
            export declare const ServicioId;
            export declare const UnidadCalculoId;
            export declare const TipoLineaFactura;
            export declare const PrecioProduccion;
            export declare const PagFactura;
            export declare const Costo;
            export declare const UserId;
            export declare const FechaModificacion;
            export declare const SwAjuste;
        }

        ['LineaFacturaId', 'HotelId', 'Fecha', 'FacturaId', 'ReservaId', 'ContratoId', 'Descripcion', 'Cantidad', 'Precio', 'ImpuestoId', 'PorcImpuesto', 'ServicioId', 'UnidadCalculoId', 'TipoLineaFactura', 'PrecioProduccion', 'PagFactura', 'Costo', 'UserId', 'FechaModificacion', 'SwAjuste'].forEach(x => (<any>Fields)[x] = x);
    }
}

