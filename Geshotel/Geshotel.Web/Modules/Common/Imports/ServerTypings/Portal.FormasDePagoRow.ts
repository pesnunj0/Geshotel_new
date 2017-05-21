
namespace Geshotel.Portal {
    export interface FormasDePagoRow {
        FormaPagoId?: number;
        FormaPago?: string;
        Credito?: boolean;
        SwEfectivo?: boolean;
        SwTarjeta?: boolean;
        TarjetaLength?: string;
        TarjetaPrefixes?: string;
        TarjetaCheckdigit?: boolean;
        SwDingus?: boolean;
        ProduccionTpv?: boolean;
    }

    export namespace FormasDePagoRow {
        export const idProperty = 'FormaPagoId';
        export const nameProperty = 'FormaPago';
        export const localTextPrefix = 'Portal.FormasDePago';
        export const lookupKey = 'Portal.FromasDePago';

        export function getLookup(): Q.Lookup<FormasDePagoRow> {
            return Q.getLookup<FormasDePagoRow>('Portal.FromasDePago');
        }

        export namespace Fields {
            export declare const FormaPagoId: string;
            export declare const FormaPago: string;
            export declare const Credito: string;
            export declare const SwEfectivo: string;
            export declare const SwTarjeta: string;
            export declare const TarjetaLength: string;
            export declare const TarjetaPrefixes: string;
            export declare const TarjetaCheckdigit: string;
            export declare const SwDingus: string;
            export declare const ProduccionTpv: string;
        }

        ['FormaPagoId', 'FormaPago', 'Credito', 'SwEfectivo', 'SwTarjeta', 'TarjetaLength', 'TarjetaPrefixes', 'TarjetaCheckdigit', 'SwDingus', 'ProduccionTpv'].forEach(x => (<any>Fields)[x] = x);
    }
}

