
namespace Geshotel.Contratos {
    export class ContadoresForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Contadores';

    }

    export interface ContadoresForm {
        EmpresaId: Serenity.IntegerEditor;
        SerieId: Serenity.IntegerEditor;
        Ano: Serenity.IntegerEditor;
        Contador: Serenity.IntegerEditor;
    }

    [['EmpresaId', () => Serenity.IntegerEditor], ['SerieId', () => Serenity.IntegerEditor], ['Ano', () => Serenity.IntegerEditor], ['Contador', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ContadoresForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

