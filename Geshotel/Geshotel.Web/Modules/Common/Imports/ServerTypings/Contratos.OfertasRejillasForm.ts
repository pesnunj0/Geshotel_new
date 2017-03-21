
namespace Geshotel.Contratos {
    export class OfertasRejillasForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.OfertasRejillas';

    }

    export interface OfertasRejillasForm {
        OfertaId: Serenity.IntegerEditor;
        N: Serenity.IntegerEditor;
        TipoCondicionId: Serenity.IntegerEditor;
        TipoAplicacion: Serenity.IntegerEditor;
        M: Serenity.DecimalEditor;
    }

    [['OfertaId', () => Serenity.IntegerEditor], ['N', () => Serenity.IntegerEditor], ['TipoCondicionId', () => Serenity.IntegerEditor], ['TipoAplicacion', () => Serenity.IntegerEditor], ['M', () => Serenity.DecimalEditor]].forEach(x => Object.defineProperty(OfertasRejillasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

