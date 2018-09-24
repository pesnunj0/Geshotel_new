﻿
namespace Geshotel.Contratos {
    export interface SeriesRow {
        SerieId?: number;
        EmpresaId?: number;
        Serie?: string;
        Abreviatura?: string;
        Manocorriente?: boolean;
        Visible?: boolean;
        Factura?: boolean;
        Deposito?: boolean;
        ServicioId?: number;
        ImpuestoId?: number;
        Voxel?: number;
        UserId?: number;
        FechaModificacion?: string;
        Empresa?: string;
        UserName?: string;
    }

    export namespace SeriesRow {
        export const idProperty = 'SerieId';
        export const nameProperty = 'Serie';
        export const localTextPrefix = 'Contratos.Series';
        export const lookupKey = 'Contratos.Series';

        export function getLookup(): Q.Lookup<SeriesRow> {
            return Q.getLookup<SeriesRow>('Contratos.Series');
        }

        export namespace Fields {
            export declare const SerieId: string;
            export declare const EmpresaId: string;
            export declare const Serie: string;
            export declare const Abreviatura: string;
            export declare const Manocorriente: string;
            export declare const Visible: string;
            export declare const Factura: string;
            export declare const Deposito: string;
            export declare const ServicioId: string;
            export declare const ImpuestoId: string;
            export declare const Voxel: string;
            export declare const UserId: string;
            export declare const FechaModificacion: string;
            export declare const Empresa: string;
            export declare const UserName: string;
        }

        [
            'SerieId', 
            'EmpresaId', 
            'Serie', 
            'Abreviatura', 
            'Manocorriente', 
            'Visible', 
            'Factura', 
            'Deposito', 
            'ServicioId', 
            'ImpuestoId', 
            'Voxel', 
            'UserId', 
            'FechaModificacion', 
            'Empresa', 
            'UserName'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

