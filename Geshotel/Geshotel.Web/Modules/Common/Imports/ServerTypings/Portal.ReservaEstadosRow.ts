
namespace Geshotel.Portal {
    export interface ReservaEstadosRow {
        EstadoReservaId?: number;
        Estado?: string;
        EsErrorFechaini?: number;
        EsErrorFechafin?: number;
    }

    export namespace ReservaEstadosRow {
        export const idProperty = 'EstadoReservaId';
        export const nameProperty = 'Estado';
        export const localTextPrefix = 'Portal.ReservaEstados';
        export const lookupKey = 'Portal.ReservasEstados';

        export function getLookup(): Q.Lookup<ReservaEstadosRow> {
            return Q.getLookup<ReservaEstadosRow>('Portal.ReservasEstados');
        }

        export namespace Fields {
            export declare const EstadoReservaId: string;
            export declare const Estado: string;
            export declare const EsErrorFechaini: string;
            export declare const EsErrorFechafin: string;
        }

        ['EstadoReservaId', 'Estado', 'EsErrorFechaini', 'EsErrorFechafin'].forEach(x => (<any>Fields)[x] = x);
    }
}

