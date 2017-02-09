

namespace Geshotel.Portal {
    export class AmbitoOfertaForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.AmbitoOferta';
    }

    export interface AmbitoOfertaForm {
        Nombre: Serenity.StringEditor;
    }

    [['AmbitoOfertaId', () => Serenity.IntegerEditor], ['Nombre', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(AmbitoOfertaForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}