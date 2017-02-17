
namespace Geshotel.Portal {
    export interface ImpuestosRow {
        ImpuestoId?: number;
        EmpresaId?: number;
        Impuesto?: string;
        Porcentaje?: number;
        CtaContable?: string;
        ActivoGeshotel?: number;
        UserId?: number;
        FechaActualizacion?: string;
        UserName?: string;
        Empresa?: string;
    }

    export namespace ImpuestosRow {
        export const idProperty = 'ImpuestoId';
        export const nameProperty = 'Impuesto';
        export const localTextPrefix = 'Portal.Impuestos';
        export const lookupKey = 'Portal.Impuestos';

        export function getLookup(): Q.Lookup<ImpuestosRow> {
            return Q.getLookup<ImpuestosRow>('Portal.Impuestos');
        }

        export namespace Fields {
            export declare const ImpuestoId: string;
            export declare const EmpresaId: string;
            export declare const Impuesto: string;
            export declare const Porcentaje: string;
            export declare const CtaContable: string;
            export declare const ActivoGeshotel: string;
            export declare const UserId: string;
            export declare const FechaActualizacion: string;
            export declare const UserName: string;
            export declare const Empresa: string;
        }

        ['ImpuestoId', 'EmpresaId', 'Impuesto', 'Porcentaje', 'CtaContable', 'ActivoGeshotel', 'UserId', 'FechaActualizacion', 'UserName', 'Empresa'].forEach(x => (<any>Fields)[x] = x);
    }
}

