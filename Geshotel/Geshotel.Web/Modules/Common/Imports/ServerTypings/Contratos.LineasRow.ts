
namespace Geshotel.Contratos {
    export interface LineasRow {
        LineaContratoId?: number;
        ContratoId?: number;
        Oferta?: boolean;
        Desde?: string;
        Hasta?: string;
        ServicioId?: number;
        UnidadCalculoId?: number;
        FrecuenciaId?: number;
        TipoImputacionId?: number;
        Importe?: number;
        TipoServicioId?: number;
        Lunes?: boolean;
        Martes?: boolean;
        Miercoles?: boolean;
        Jueves?: boolean;
        Viernes?: boolean;
        Sabado?: boolean;
        Domingo?: boolean;
        PagFactura?: number;
        UserId?: number;
        FechaModificacion?: string;
        Servicio?: string;
        DescripcionUnidadCalculo?: string;
        Frecuencia?: string;
        Imputacion?: string;
        UserName?: string;
        TipoServicio?: string;
        HotelId?: number;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
    }

    export namespace LineasRow {
        export const idProperty = 'LineaContratoId';
        export const localTextPrefix = 'Contratos.Lineas';

        export namespace Fields {
            export declare const LineaContratoId: string;
            export declare const ContratoId: string;
            export declare const Oferta: string;
            export declare const Desde: string;
            export declare const Hasta: string;
            export declare const ServicioId: string;
            export declare const UnidadCalculoId: string;
            export declare const FrecuenciaId: string;
            export declare const TipoImputacionId: string;
            export declare const Importe: string;
            export declare const TipoServicioId: string;
            export declare const Lunes: string;
            export declare const Martes: string;
            export declare const Miercoles: string;
            export declare const Jueves: string;
            export declare const Viernes: string;
            export declare const Sabado: string;
            export declare const Domingo: string;
            export declare const PagFactura: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const Servicio: string;
            export declare const DescripcionUnidadCalculo: string;
            export declare const Frecuencia: string;
            export declare const Imputacion: string;
            export declare const UserName: string;
            export declare const TipoServicio: string;
            export declare const HotelId: string;
            export declare const HotelName: string;
            export declare const EmpresaId: string;
            export declare const Empresa: string;
        }

        [
            'LineaContratoId', 
            'ContratoId', 
            'Oferta', 
            'Desde', 
            'Hasta', 
            'ServicioId', 
            'UnidadCalculoId', 
            'FrecuenciaId', 
            'TipoImputacionId', 
            'Importe', 
            'TipoServicioId', 
            'Lunes', 
            'Martes', 
            'Miercoles', 
            'Jueves', 
            'Viernes', 
            'Sabado', 
            'Domingo', 
            'PagFactura', 
            'UserId', 
            'FechaModificacion', 
            'Servicio', 
            'DescripcionUnidadCalculo', 
            'Frecuencia', 
            'Imputacion', 
            'UserName', 
            'TipoServicio', 
            'HotelId', 
            'HotelName', 
            'EmpresaId', 
            'Empresa'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

