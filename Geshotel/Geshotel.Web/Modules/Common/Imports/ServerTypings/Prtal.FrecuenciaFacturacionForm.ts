

namespace Geshotel.Prtal {
    export class FrecuenciaFacturacionForm extends Serenity.PrefixedContext {
        static formKey = 'Prtal.FrecuenciaFacturacion';
    }

    export interface FrecuenciaFacturacionForm {
        DescripcionCorta: Serenity.StringEditor;
        Descripcion: Serenity.StringEditor;
    }

    [['FrecuenciaId', () => Serenity.IntegerEditor], ['DescripcionCorta', () => Serenity.StringEditor], ['Descripcion', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(FrecuenciaFacturacionForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}