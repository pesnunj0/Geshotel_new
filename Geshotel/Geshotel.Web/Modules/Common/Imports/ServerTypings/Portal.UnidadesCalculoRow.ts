namespace Geshotel.Portal {
    export interface UnidadesCalculoRow {
        UnidadCalculoId?: number;
        Uc?: string;
        DescripcionUnidadCalculo?: string;
        TipoUnidadCalculoId?: number;
        Pax?: number;
        ServicioId?: number;
        UserId?: number;
        FechaModificacion?: string;
        TipoUnidadCalculoUc?: string;
        ServicioNombreServicio?: string;
        ServicioAbreviatura?: string;
        ServicioTipoServicioId?: number;
        ServicioSwProduccion?: number;
        ServicioSwDescuento?: number;
        ServicioSwAjustes?: number;
        ServicioSwGastos?: number;
        ServicioSwPension?: number;
        ServicioSwRectificativa?: number;
        ServicioTipoUnidadCalculoId?: number;
        ServicioConceptoAceleradorReservasId?: number;
        ServicioCosto?: number;
        ServicioSumaServicioId?: number;
        ServicioRestaServicioId?: number;
        ServicioUserId?: number;
        ServicioFechaModificacion?: string;
        ServicioTipoHab?: number;
        ServicioTipoPension?: number;
    }

    export namespace UnidadesCalculoRow {
        export const idProperty = 'UnidadCalculoId';
        export const nameProperty = 'Uc';
        export const localTextPrefix = 'Portal.UnidadesCalculo';
        export const lookupKey = 'Portal.UnidadesCalculo';

        export function getLookup(): Q.Lookup<UnidadesCalculoRow> {
            return Q.getLookup<UnidadesCalculoRow>('Portal.UnidadesCalculo');
        }

        export namespace Fields {
            export declare const UnidadCalculoId: string;
            export declare const Uc: string;
            export declare const DescripcionUnidadCalculo: string;
            export declare const TipoUnidadCalculoId: string;
            export declare const Pax: string;
            export declare const ServicioId: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const TipoUnidadCalculoUc: string;
            export declare const ServicioNombreServicio: string;
            export declare const ServicioAbreviatura: string;
            export declare const ServicioTipoServicioId: string;
            export declare const ServicioSwProduccion: string;
            export declare const ServicioSwDescuento: string;
            export declare const ServicioSwAjustes: string;
            export declare const ServicioSwGastos: string;
            export declare const ServicioSwPension: string;
            export declare const ServicioSwRectificativa: string;
            export declare const ServicioTipoUnidadCalculoId: string;
            export declare const ServicioConceptoAceleradorReservasId: string;
            export declare const ServicioCosto: string;
            export declare const ServicioSumaServicioId: string;
            export declare const ServicioRestaServicioId: string;
            export declare const ServicioUserId: string;
            export declare const ServicioFechaModificacion: string;
            export declare const ServicioTipoHab: string;
            export declare const ServicioTipoPension: string;
        }

        ['UnidadCalculoId', 'Uc', 'DescripcionUnidadCalculo', 'TipoUnidadCalculoId', 'Pax', 'ServicioId', 'UserId', 'FechaModificacion', 'TipoUnidadCalculoUc', 'ServicioNombreServicio', 'ServicioAbreviatura', 'ServicioTipoServicioId', 'ServicioSwProduccion', 'ServicioSwDescuento', 'ServicioSwAjustes', 'ServicioSwGastos', 'ServicioSwPension', 'ServicioSwRectificativa', 'ServicioTipoUnidadCalculoId', 'ServicioConceptoAceleradorReservasId', 'ServicioCosto', 'ServicioSumaServicioId', 'ServicioRestaServicioId', 'ServicioUserId', 'ServicioFechaModificacion', 'ServicioTipoHab', 'ServicioTipoPension'].forEach(x => (<any>Fields)[x] = x);
    }
}

