
namespace Geshotel.Contratos {
    export interface CajasRow {
        CajaId?: number;
        HotelId?: number;
        NombreCaja?: string;
        DescCorta?: string;
        CierreDia?: boolean;
        CtaContable?: string;
        DptoContable?: string;
        UserId?: number;
        FechaModificacion?: string;
        HotelName?: string;
        EmpresaId?: number;
        Empresa?: string;
        UserName?: string;
    }

    export namespace CajasRow {
        export const idProperty = 'CajaId';
        export const nameProperty = 'NombreCaja';
        export const localTextPrefix = 'Contratos.Cajas';
        export const lookupKey = 'Contratos.Cajas';

        export function getLookup(): Q.Lookup<CajasRow> {
            return Q.getLookup<CajasRow>('Contratos.Cajas');
        }

        export namespace Fields {
            export declare const CajaId: string;
            export declare const HotelId: string;
            export declare const NombreCaja: string;
            export declare const DescCorta: string;
            export declare const CierreDia: string;
            export declare const CtaContable: string;
            export declare const DptoContable: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const HotelName: string;
            export declare const EmpresaId: string;
            export declare const Empresa: string;
            export declare const UserName: string;
        }

        [
            'CajaId', 
            'HotelId', 
            'NombreCaja', 
            'DescCorta', 
            'CierreDia', 
            'CtaContable', 
            'DptoContable', 
            'UserId', 
            'FechaModificacion', 
            'HotelName', 
            'EmpresaId', 
            'Empresa', 
            'UserName'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

