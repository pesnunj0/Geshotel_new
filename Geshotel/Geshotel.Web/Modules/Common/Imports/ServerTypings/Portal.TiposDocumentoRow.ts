
namespace Geshotel.Portal {
    export interface TiposDocumentoRow {
        DocumentoId?: string;
        Documento?: string;
    }

    export namespace TiposDocumentoRow {
        export const idProperty = 'DocumentoId';
        export const nameProperty = 'Documento';
        export const localTextPrefix = 'Portal.TiposDocumento';
        export const lookupKey = 'Portal.TiposDocumento';

        export function getLookup(): Q.Lookup<TiposDocumentoRow> {
            return Q.getLookup<TiposDocumentoRow>('Portal.TiposDocumento');
        }

        export namespace Fields {
            export declare const DocumentoId: string;
            export declare const Documento: string;
        }

        [
            'DocumentoId', 
            'Documento'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}

