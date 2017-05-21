
namespace Geshotel.Portal {
    export interface ProvinciasRow {
        ProvinciaId?: number;
        Provincia?: string;
        ComunidadAutonomaId?: number;
        NacionId?: number;
        ProvinciaIsta?: string;
        DefectoIsta?: number;
        ComunidadAutonomaNacionId?: number;
        ComunidadAutonoma?: string;
        ComunidadAutonomaComunidadAutonomaIsta?: string;
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

    export namespace ProvinciasRow {
        export const idProperty = 'ProvinciaId';
        export const nameProperty = 'Provincia';
        export const localTextPrefix = 'Portal.Provincias';
        export const lookupKey = 'Portal.Provincias';

        export function getLookup(): Q.Lookup<ProvinciasRow> {
            return Q.getLookup<ProvinciasRow>('Portal.Provincias');
        }

        export namespace Fields {
            export declare const ProvinciaId: string;
            export declare const Provincia: string;
            export declare const ComunidadAutonomaId: string;
            export declare const NacionId: string;
            export declare const ProvinciaIsta: string;
            export declare const DefectoIsta: string;
            export declare const ComunidadAutonomaNacionId: string;
            export declare const ComunidadAutonoma: string;
            export declare const ComunidadAutonomaComunidadAutonomaIsta: string;
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

        ['ProvinciaId', 'Provincia', 'ComunidadAutonomaId', 'NacionId', 'ProvinciaIsta', 'DefectoIsta', 'ComunidadAutonomaNacionId', 'ComunidadAutonoma', 'ComunidadAutonomaComunidadAutonomaIsta', 'Nacion', 'NacionDescCorta', 'NacionMonedaId', 'NacionIdiomaId', 'NacionNumeroIne', 'NacionPaisIsta', 'NacionDefecto', 'NacionNombreReal', 'NacionIdiomaMails'].forEach(x => (<any>Fields)[x] = x);
    }
}

