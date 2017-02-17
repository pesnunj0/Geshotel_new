
namespace Geshotel.Contratos {
    export interface ServiciosHotelRow {
        ServicioHotelId?: number;
        ServicioId?: number;
        HotelId?: number;
        ImpuestoId?: number;
        Costo?: number;
        CtaContable?: string;
        DptoContable?: string;
        PermiteCredito?: number;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        NombreServicio?: string;
        ServicioTipoServicioId?: number;
        Impuesto?: string;
    }

    export namespace ServiciosHotelRow {
        export const idProperty = 'ServicioHotelId';
        export const nameProperty = 'CtaContable';
        export const localTextPrefix = 'Contratos.ServiciosHotel';

        export namespace Fields {
            export declare const ServicioHotelId: string;
            export declare const ServicioId: string;
            export declare const HotelId: string;
            export declare const ImpuestoId: string;
            export declare const Costo: string;
            export declare const CtaContable: string;
            export declare const DptoContable: string;
            export declare const PermiteCredito: string;
            export declare const HotelName: string;
            export declare const EmpresaId: string;
            export declare const Empresa: string;
            export declare const NombreServicio: string;
            export declare const ServicioTipoServicioId: string;
            export declare const Impuesto: string;
        }

        ['ServicioHotelId', 'ServicioId', 'HotelId', 'ImpuestoId', 'Costo', 'CtaContable', 'DptoContable', 'PermiteCredito', 'HotelName', 'EmpresaId', 'Empresa', 'NombreServicio', 'ServicioTipoServicioId', 'Impuesto'].forEach(x => (<any>Fields)[x] = x);
    }
}

