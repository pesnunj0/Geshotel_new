
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

        export namespace Fields {
            export declare const EstadoFacturaId;
            export declare const Descripcion;
            export declare const EsError;
        }

        ['EstadoFacturaId', 'Descripcion', 'EsError'].forEach(x => (<any>Fields)[x] = x);
    }
}

