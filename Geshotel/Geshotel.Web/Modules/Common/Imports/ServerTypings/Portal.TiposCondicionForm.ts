
namespace Geshotel.Portal {
    export class TiposCondicionForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposCondicion';

    }

    export interface TiposCondicionForm {
        Condicion: Serenity.StringEditor;
        Literal: Serenity.StringEditor;
    }

    [['Condicion', () => Serenity.StringEditor], ['Literal', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(TiposCondicionForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

