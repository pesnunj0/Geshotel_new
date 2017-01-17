namespace Geshotel.Portal {
    export class MonedasForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.Monedas';

    }

    export interface MonedasForm {
        Descripcion: Serenity.StringEditor;
        DescCorta: Serenity.StringEditor;
        Cambio: Serenity.DecimalEditor;
    }

    [['Descripcion', () => Serenity.StringEditor], ['DescCorta', () => Serenity.StringEditor], ['Cambio', () => Serenity.DecimalEditor]].forEach(x => Object.defineProperty(MonedasForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

