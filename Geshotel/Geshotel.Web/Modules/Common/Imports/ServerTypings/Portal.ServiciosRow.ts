namespace Geshotel.Portal {
    export interface ServiciosRow {
        ServicioId?: number;
        NombreServicio?: string;
        Abreviatura?: string;
        TipoServicioId?: number;
        SwProduccion?: boolean;
        SwDescuento?: boolean;
        SwAjustes?: boolean;
        SwGastos?: boolean;
        SwPension?: boolean;
        SwRectificativa?: boolean;
        TipoUnidadCalculoId?: number;
        ConceptoAceleradorReservasId?: number;
        Costo?: number;
        SumaServicioId?: number;
        RestaServicioId?: number;
        UserId?: number;
        FechaModificacion?: string;
        TipoHab?: number;
        TipoPension?: number;
        TipoServicioNombreTipoServicio?: string;
        Tipo_UC?: string;
        Concepto?: string;
        Suma?: string;
        Resta?: string;
        NombreTipoHab?: string;
        NombreTipoPension?: string;
    }

    export namespace ServiciosRow {
        export const idProperty = 'ServicioId';
        export const nameProperty = 'NombreServicio';
        export const localTextPrefix = 'Portal.Servicios';
        export const lookupKey = 'Portal.Servicios';

        export function getLookup(): Q.Lookup<ServiciosRow> {
            return Q.getLookup<ServiciosRow>('Portal.Servicios');
        }

        export namespace Fields {
            export declare const ServicioId: string;
            export declare const NombreServicio: string;
            export declare const Abreviatura: string;
            export declare const TipoServicioId: string;
            export declare const SwProduccion: string;
            export declare const SwDescuento: string;
            export declare const SwAjustes: string;
            export declare const SwGastos: string;
            export declare const SwPension: string;
            export declare const SwRectificativa: string;
            export declare const TipoUnidadCalculoId: string;
            export declare const ConceptoAceleradorReservasId: string;
            export declare const Costo: string;
            export declare const SumaServicioId: string;
            export declare const RestaServicioId: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const TipoHab: string;
            export declare const TipoPension: string;
            export declare const TipoServicioNombreTipoServicio: string;
            export declare const Tipo_UC: string;
            export declare const Concepto: string;
            export declare const Suma: string;
            export declare const Resta: string;
            export declare const NombreTipoHab: string;
            export declare const NombreTipoPension: string;
        }

        ['ServicioId', 'NombreServicio', 'Abreviatura', 'TipoServicioId', 'SwProduccion', 'SwDescuento', 'SwAjustes', 'SwGastos', 'SwPension', 'SwRectificativa', 'TipoUnidadCalculoId', 'ConceptoAceleradorReservasId', 'Costo', 'SumaServicioId', 'RestaServicioId', 'UserId', 'FechaModificacion', 'TipoHab', 'TipoPension', 'TipoServicioNombreTipoServicio', 'Tipo_UC', 'Concepto', 'Suma', 'Resta', 'NombreTipoHab', 'NombreTipoPension'].forEach(x => (<any>Fields)[x] = x);
    }
}

