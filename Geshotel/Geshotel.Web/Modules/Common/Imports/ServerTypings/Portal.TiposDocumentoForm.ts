

namespace Geshotel.Portal {
    export class TiposDocumentoForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposDocumento';
    }

    export interface TiposDocumentoForm {
        Documento: Serenity.StringEditor;
    }

    [['DocumentoId', () => Serenity.StringEditor], ['Documento', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(TiposDocumentoForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}