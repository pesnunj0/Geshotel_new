
namespace Geshotel.Portal {
    export interface EstadosFacturasRow {
        EstadoFacturaId?: number;
        Descripcion?: string;
        EsError?: number;
    }

    export namespace EstadosFacturasRow {
        export const idProperty = 'EstadoFacturaId';
        export const nameProperty = 'Descripcion';
        export const localTextPrefix = 'Portal.EstadosFacturas';
        export const lookupKey = 'Portal.EstadosFactura';

        export function getLookup(): Q.Lookup<EstadosFacturasRow> {
            return Q.getLookup<EstadosFacturasRow>('Portal.EstadosFactura');
        }

        export namespace Fields {
            export declare const EstadoFacturaId: string;
            export declare const Descripcion: string;
            export declare const EsError: string;
        }

        [
            'EstadoFacturaId', 
            'Descripcion', 
            'EsError'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

