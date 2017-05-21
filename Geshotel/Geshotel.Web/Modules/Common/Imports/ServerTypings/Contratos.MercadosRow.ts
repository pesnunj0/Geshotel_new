
namespace Geshotel.Contratos {
    export interface MercadosRow {
        MercadoId?: number;
        Mercado?: string;
        EmpresaId?: number;
        HotelId?: number;
        Empresa?: string;
        HotelName?: string;
    }

    export namespace MercadosRow {
        export const idProperty = 'MercadoId';
        export const nameProperty = 'Mercado';
        export const localTextPrefix = 'Contratos.Mercados';
        export const lookupKey = 'Contratos.Mercados';

        export function getLookup(): Q.Lookup<MercadosRow> {
            return Q.getLookup<MercadosRow>('Contratos.Mercados');
        }

        export namespace Fields {
            export declare const MercadoId: string;
            export declare const Mercado: string;
            export declare const EmpresaId: string;
            export declare const HotelId: string;
            export declare const Empresa: string;
            export declare const HotelName: string;
        }

        ['MercadoId', 'Mercado', 'EmpresaId', 'HotelId', 'Empresa', 'HotelName'].forEach(x => (<any>Fields)[x] = x);
    }
}

