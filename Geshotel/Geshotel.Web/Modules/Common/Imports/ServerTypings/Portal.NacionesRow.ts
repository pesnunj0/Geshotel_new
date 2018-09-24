
namespace Geshotel.Portal {
    export interface NacionesRow {
        NacionId?: number;
        Nacion?: string;
        DescCorta?: string;
        MonedaId?: number;
        IdiomaId?: number;
        NumeroIne?: number;
        PaisIsta?: string;
        Defecto?: number;
        NombreReal?: string;
        IdiomaMails?: string;
        MonedaDescripcion?: string;
        MonedaDescCorta?: string;
        MonedaCambio?: number;
        IdiomaLanguageId?: string;
        IdiomaLanguageName?: string;
    }

    export namespace NacionesRow {
        export const idProperty = 'NacionId';
        export const nameProperty = 'Nacion';
        export const localTextPrefix = 'Portal.Naciones';
        export const lookupKey = 'Portal.Naciones';

        export function getLookup(): Q.Lookup<NacionesRow> {
            return Q.getLookup<NacionesRow>('Portal.Naciones');
        }

        export namespace Fields {
            export declare const NacionId: string;
            export declare const Nacion: string;
            export declare const DescCorta: string;
            export declare const MonedaId: string;
            export declare const IdiomaId: string;
            export declare const NumeroIne: string;
            export declare const PaisIsta: string;
            export declare const Defecto: string;
            export declare const NombreReal: string;
            export declare const IdiomaMails: string;
            export declare const MonedaDescripcion: string;
            export declare const MonedaDescCorta: string;
            export declare const MonedaCambio: string;
            export declare const IdiomaLanguageId: string;
            export declare const IdiomaLanguageName: string;
        }

        [
            'NacionId', 
            'Nacion', 
            'DescCorta', 
            'MonedaId', 
            'IdiomaId', 
            'NumeroIne', 
            'PaisIsta', 
            'Defecto', 
            'NombreReal', 
            'IdiomaMails', 
            'MonedaDescripcion', 
            'MonedaDescCorta', 
            'MonedaCambio', 
            'IdiomaLanguageId', 
            'IdiomaLanguageName'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

