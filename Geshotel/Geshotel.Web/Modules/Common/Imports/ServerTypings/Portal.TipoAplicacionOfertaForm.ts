namespace Geshotel.Portal {
    export class TipoAplicacionOfertaForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TipoAplicacionOferta';

    }

    export interface TipoAplicacionOfertaForm {
        AplicableSegunFechaDe: Serenity.StringEditor;
    }

    [['AplicableSegunFechaDe', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(TipoAplicacionOfertaForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

