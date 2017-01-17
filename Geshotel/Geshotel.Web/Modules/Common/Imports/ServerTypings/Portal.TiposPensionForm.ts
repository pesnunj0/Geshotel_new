

namespace Geshotel.Portal {
    export class TiposPensionForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposPension';
    }

    export interface TiposPensionForm {
        TipoPension: Serenity.StringEditor;
    }

    [['TipoPensionId', () => Serenity.IntegerEditor], ['TipoPension', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(TiposPensionForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}