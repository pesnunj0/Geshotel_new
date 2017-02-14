
namespace Geshotel.Portal {
    export class TiposUnidadCalculoForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposUnidadCalculo';

    }

    export interface TiposUnidadCalculoForm {
        Uc: Serenity.StringEditor;
    }

    [['Uc', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(TiposUnidadCalculoForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

