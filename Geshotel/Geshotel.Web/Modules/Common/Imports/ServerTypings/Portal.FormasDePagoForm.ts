namespace Geshotel.Portal {
    export class FormasDePagoForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.FormasDePago';

    }

    export interface FormasDePagoForm {
        FormaPago: Serenity.StringEditor;
        Credito: Serenity.BooleanEditor;
        SwEfectivo: Serenity.BooleanEditor;
        SwTarjeta: Serenity.BooleanEditor;
        TarjetaLength: Serenity.StringEditor;
        TarjetaPrefixes: Serenity.StringEditor;
        TarjetaCheckdigit: Serenity.BooleanEditor;
        SwDingus: Serenity.BooleanEditor;
        ProduccionTpv: Serenity.BooleanEditor;
    }

    [['FormaPago', () => Serenity.StringEditor], ['Credito', () => Serenity.BooleanEditor], ['SwEfectivo', () => Serenity.BooleanEditor], ['SwTarjeta', () => Serenity.BooleanEditor], ['TarjetaLength', () => Serenity.StringEditor], ['TarjetaPrefixes', () => Serenity.StringEditor], ['TarjetaCheckdigit', () => Serenity.BooleanEditor], ['SwDingus', () => Serenity.BooleanEditor], ['ProduccionTpv', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(FormasDePagoForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

