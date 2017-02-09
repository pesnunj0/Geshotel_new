
namespace Geshotel.Portal {
    export interface TiposDeOfertaRow {
        TipoOfertaId?: number;
        Oferta?: string;
        PermitirMMayorQueN?: number;
        Rejilla?: number;
        Observaciones?: string;
        OrdenAplicacion?: number;
    }

    export namespace TiposDeOfertaRow {
        export const idProperty = 'TipoOfertaId';
        export const nameProperty = 'Oferta';
        export const localTextPrefix = 'Portal.TiposDeOferta';

        export namespace Fields {
            export declare const TipoOfertaId;
            export declare const Oferta;
            export declare const PermitirMMayorQueN;
            export declare const Rejilla;
            export declare const Observaciones;
            export declare const OrdenAplicacion;
        }

        ['TipoOfertaId', 'Oferta', 'PermitirMMayorQueN', 'Rejilla', 'Observaciones', 'OrdenAplicacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

