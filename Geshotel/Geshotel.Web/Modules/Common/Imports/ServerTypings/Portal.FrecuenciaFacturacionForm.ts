
namespace Geshotel.Portal {
    export class FrecuenciaFacturacionForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.FrecuenciaFacturacion';

    }

    export interface FrecuenciaFacturacionForm {
        DescripcionCorta: Serenity.StringEditor;
        Descripcion: Serenity.StringEditor;
    }

    [['DescripcionCorta', () => Serenity.StringEditor], ['Descripcion', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(FrecuenciaFacturacionForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

