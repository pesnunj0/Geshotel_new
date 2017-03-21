
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
        export const lookupKey = 'Portal.TiposDeOferta';

        export function getLookup(): Q.Lookup<TiposDeOfertaRow> {
            return Q.getLookup<TiposDeOfertaRow>('Portal.TiposDeOferta');
        }

        export namespace Fields {
            export declare const TipoOfertaId: string;
            export declare const Oferta: string;
            export declare const PermitirMMayorQueN: string;
            export declare const Rejilla: string;
            export declare const Observaciones: string;
            export declare const OrdenAplicacion: string;
        }

        ['TipoOfertaId', 'Oferta', 'PermitirMMayorQueN', 'Rejilla', 'Observaciones', 'OrdenAplicacion'].forEach(x => (<any>Fields)[x] = x);
    }
}

