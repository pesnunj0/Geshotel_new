

namespace Geshotel.Contratos {
    export class AmbitoOfertaForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.AmbitoOferta';
    }

    export interface AmbitoOfertaForm {
        NombreAmbito: Serenity.StringEditor;
    }

    [['AmbitoOfertaId', () => Serenity.IntegerEditor], ['NombreAmbito', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(AmbitoOfertaForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}