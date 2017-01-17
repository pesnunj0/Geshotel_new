
namespace Geshotel.Portal {
    export interface TiposDocumentoRow {
        DocumentoId?: string;
        Documento?: string;
    }

    export namespace TiposDocumentoRow {
        export const idProperty = 'DocumentoId';
        export const nameProperty = 'DocumentoId';
        export const localTextPrefix = 'Portal.TiposDocumento';

        export namespace Fields {
            export declare const DocumentoId;
            export declare const Documento;
        }

        ['DocumentoId', 'Documento'].forEach(x => (<any>Fields)[x] = x);
    }
}

