
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

        export namespace Fields {
            export declare const EstadoReservaId;
            export declare const Estado;
            export declare const EsErrorFechaini;
            export declare const EsErrorFechafin;
        }

        ['EstadoReservaId', 'Estado', 'EsErrorFechaini', 'EsErrorFechafin'].forEach(x => (<any>Fields)[x] = x);
    }
}

