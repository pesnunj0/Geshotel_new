

namespace Geshotel.Contratos {
    export class MercadosForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Mercados';
    }

    export interface MercadosForm {
        Mercado: Serenity.StringEditor;
        EmpresaId: Serenity.IntegerEditor;
    }

    [['MercadoId', () => Serenity.IntegerEditor], ['Mercado', () => Serenity.StringEditor], ['EmpresaId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(MercadosForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}