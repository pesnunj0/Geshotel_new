
namespace Geshotel.Contratos {
    export class SeriesForm extends Serenity.PrefixedContext {
        static formKey = 'Contratos.Series';

    }

    export interface SeriesForm {
        Descripcion: Serenity.StringEditor;
        Abreviatura: Serenity.StringEditor;
        Empresa: Serenity.StringEditor;
        Manocorriente: Serenity.BooleanEditor;
        Visible: Serenity.BooleanEditor;
        Factura: Serenity.BooleanEditor;
        Deposito: Serenity.BooleanEditor;
    }

    [['Descripcion', () => Serenity.StringEditor], ['Abreviatura', () => Serenity.StringEditor], ['Empresa', () => Serenity.StringEditor], ['Manocorriente', () => Serenity.BooleanEditor], ['Visible', () => Serenity.BooleanEditor], ['Factura', () => Serenity.BooleanEditor], ['Deposito', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(SeriesForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

