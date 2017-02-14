
namespace Geshotel.Contratos {
    export interface TemporadasRow {
        TemporadaId?: number;
        Temporada?: string;
        HotelId?: number;
        EmpresaId?: number;
        Ano?: number;
        FechaDesde?: string;
        FechaHasta?: string;
        HotelName?: string;
        Empresa?: string;
    }

    export namespace TemporadasRow {
        export const idProperty = 'TemporadaId';
        export const nameProperty = 'Temporada';
        export const localTextPrefix = 'Contratos.Temporadas';
        export const lookupKey = 'Contratos.Temporadas';

        export function getLookup(): Q.Lookup<TemporadasRow> {
            return Q.getLookup<TemporadasRow>('Contratos.Temporadas');
        }

        export namespace Fields {
            export declare const TemporadaId: string;
            export declare const Temporada: string;
            export declare const HotelId: string;
            export declare const EmpresaId: string;
            export declare const Ano: string;
            export declare const FechaDesde: string;
            export declare const FechaHasta: string;
            export declare const HotelName: string;
            export declare const Empresa: string;
        }

        ['TemporadaId', 'Temporada', 'HotelId', 'EmpresaId', 'Ano', 'FechaDesde', 'FechaHasta', 'HotelName', 'Empresa'].forEach(x => (<any>Fields)[x] = x);
    }
}

