
namespace Geshotel.Contratos {
    export interface CanalesReservaRow {
        CanalReservaId?: number;
        EmpresaId?: number;
        NombreCanal?: string;
        Empresa?: string;
    }

    export namespace CanalesReservaRow {
        export const idProperty = 'CanalReservaId';
        export const nameProperty = 'NombreCanal';
        export const localTextPrefix = 'Contratos.CanalesReserva';
        export const lookupKey = 'Contratos.CanalesReserva';

        export function getLookup(): Q.Lookup<CanalesReservaRow> {
            return Q.getLookup<CanalesReservaRow>('Contratos.CanalesReserva');
        }

        export namespace Fields {
            export declare const CanalReservaId: string;
            export declare const EmpresaId: string;
            export declare const NombreCanal: string;
            export declare const Empresa: string;
        }

        ['CanalReservaId', 'EmpresaId', 'NombreCanal', 'Empresa'].forEach(x => (<any>Fields)[x] = x);
    }
}

