
namespace Geshotel.Portal {
    export interface TiposHotelRow {
        TipoHotelId?: number;
        TipoHotel?: string;
        Abreviatura?: string;
    }

    export namespace TiposHotelRow {
        export const idProperty = 'TipoHotelId';
        export const nameProperty = 'TipoHotel';
        export const localTextPrefix = 'Portal.TiposHotel';
        export const lookupKey = 'Portal.TiposHotel';

        export function getLookup(): Q.Lookup<TiposHotelRow> {
            return Q.getLookup<TiposHotelRow>('Portal.TiposHotel');
        }

        export namespace Fields {
            export declare const TipoHotelId: string;
            export declare const TipoHotel: string;
            export declare const Abreviatura: string;
        }

        ['TipoHotelId', 'TipoHotel', 'Abreviatura'].forEach(x => (<any>Fields)[x] = x);
    }
}

