
namespace Geshotel.Contratos {
    export interface ServiciosHotelRow {
        ServicioHotelId?: number;
        ServicioId?: number;
        HotelId?: number;
        ImpuestoId?: number;
        Costo?: number;
        CtaContable?: string;
        DptoContable?: string;
        PermiteCredito?: boolean;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        NombreServicio?: string;
        ServicioTipoServicioId?: number;
        ConceptoAceleradorReservasId?: number;
        SwPension?: boolean;
        Impuesto?: string;
    }

    export namespace ServiciosHotelRow {
        export const idProperty = 'ServicioHotelId';
        export const nameProperty = 'NombreServicio';
        export const localTextPrefix = 'Contratos.ServiciosHotel';
        export const lookupKey = 'Contratos.ServiciosHotel';

        export function getLookup(): Q.Lookup<ServiciosHotelRow> {
            return Q.getLookup<ServiciosHotelRow>('Contratos.ServiciosHotel');
        }

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
            export declare const ConceptoAceleradorReservasId: string;
            export declare const SwPension: string;
            export declare const Impuesto: string;
        }

        ['ServicioHotelId', 'ServicioId', 'HotelId', 'ImpuestoId', 'Costo', 'CtaContable', 'DptoContable', 'PermiteCredito', 'HotelName', 'EmpresaId', 'Empresa', 'NombreServicio', 'ServicioTipoServicioId', 'ConceptoAceleradorReservasId', 'SwPension', 'Impuesto'].forEach(x => (<any>Fields)[x] = x);
    }
}

