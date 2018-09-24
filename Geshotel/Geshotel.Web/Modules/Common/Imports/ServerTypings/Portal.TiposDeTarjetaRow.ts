
namespace Geshotel.Portal {
    export interface TiposDeTarjetaRow {
        TipoTarjetaId?: number;
        TipoTarjeta?: string;
        TarjetaLength?: string;
        TarjetaPrefixes?: string;
        TarjetaCheckdigit?: boolean;
    }

    export namespace TiposDeTarjetaRow {
        export const idProperty = 'TipoTarjetaId';
        export const nameProperty = 'TipoTarjeta';
        export const localTextPrefix = 'Portal.TiposDeTarjeta';
        export const lookupKey = 'Portal.TiposDeTarjeta';

        export function getLookup(): Q.Lookup<TiposDeTarjetaRow> {
            return Q.getLookup<TiposDeTarjetaRow>('Portal.TiposDeTarjeta');
        }

        export namespace Fields {
            export declare const TipoTarjetaId: string;
            export declare const TipoTarjeta: string;
            export declare const TarjetaLength: string;
            export declare const TarjetaPrefixes: string;
            export declare const TarjetaCheckdigit: string;
        }

        [
            'TipoTarjetaId', 
            'TipoTarjeta', 
            'TarjetaLength', 
            'TarjetaPrefixes', 
            'TarjetaCheckdigit'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

