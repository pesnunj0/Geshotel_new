
namespace Geshotel.Portal {
    export interface TiposPensionRow {
        TipoPensionId?: number;
        TipoPension?: string;
    }

    export namespace TiposPensionRow {
        export const idProperty = 'TipoPensionId';
        export const nameProperty = 'TipoPension';
        export const localTextPrefix = 'Portal.TiposPension';

        export namespace Fields {
            export declare const TipoPensionId;
            export declare const TipoPension;
        }

        ['TipoPensionId', 'TipoPension'].forEach(x => (<any>Fields)[x] = x);
    }
}

