

namespace Geshotel.Contratos {
    export class TipoAplicacionOfertaForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.TipoAplicacionOferta';
    }

    export interface TipoAplicacionOfertaForm {
        AplicableSegunFechaDe: Serenity.StringEditor;
    }

    [['TipoAplicacionOfertaId', () => Serenity.StringEditor], ['AplicableSegunFechaDe', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(TipoAplicacionOfertaForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}