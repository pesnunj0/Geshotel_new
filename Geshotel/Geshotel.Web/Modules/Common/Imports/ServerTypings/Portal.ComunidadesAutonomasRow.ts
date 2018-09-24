
namespace Geshotel.Portal {
    export interface ComunidadesAutonomasRow {
        ComunidadId?: number;
        NacionId?: number;
        ComunidadAutonoma?: string;
        ComunidadAutonomaIsta?: string;
        Nacion?: string;
        NacionDescCorta?: string;
        NacionMonedaId?: number;
        NacionIdiomaId?: number;
        NacionNumeroIne?: number;
        NacionPaisIsta?: string;
        NacionDefecto?: number;
        NacionNombreReal?: string;
        NacionIdiomaMails?: string;
    }

    export namespace ComunidadesAutonomasRow {
        export const idProperty = 'ComunidadId';
        export const nameProperty = 'ComunidadAutonoma';
        export const localTextPrefix = 'Portal.ComunidadesAutonomas';
        export const lookupKey = 'Portal.ComunidadesAutonomas';

        export function getLookup(): Q.Lookup<ComunidadesAutonomasRow> {
            return Q.getLookup<ComunidadesAutonomasRow>('Portal.ComunidadesAutonomas');
        }

        export namespace Fields {
            export declare const ComunidadId: string;
            export declare const NacionId: string;
            export declare const ComunidadAutonoma: string;
            export declare const ComunidadAutonomaIsta: string;
            export declare const Nacion: string;
            export declare const NacionDescCorta: string;
            export declare const NacionMonedaId: string;
            export declare const NacionIdiomaId: string;
            export declare const NacionNumeroIne: string;
            export declare const NacionPaisIsta: string;
            export declare const NacionDefecto: string;
            export declare const NacionNombreReal: string;
            export declare const NacionIdiomaMails: string;
        }

        [
            'ComunidadId', 
            'NacionId', 
            'ComunidadAutonoma', 
            'ComunidadAutonomaIsta', 
            'Nacion', 
            'NacionDescCorta', 
            'NacionMonedaId', 
            'NacionIdiomaId', 
            'NacionNumeroIne', 
            'NacionPaisIsta', 
            'NacionDefecto', 
            'NacionNombreReal', 
            'NacionIdiomaMails'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

