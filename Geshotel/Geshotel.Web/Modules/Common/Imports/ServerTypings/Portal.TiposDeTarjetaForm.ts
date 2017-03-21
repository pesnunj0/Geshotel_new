
namespace Geshotel.Portal {
    export class TiposDeTarjetaForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposDeTarjeta';

    }

    export interface TiposDeTarjetaForm {
        TipoTarjeta: Serenity.StringEditor;
        TarjetaLength: Serenity.StringEditor;
        TarjetaPrefixes: Serenity.StringEditor;
        TarjetaCheckdigit: Serenity.BooleanEditor;
    }

    [['TipoTarjeta', () => Serenity.StringEditor], ['TarjetaLength', () => Serenity.StringEditor], ['TarjetaPrefixes', () => Serenity.StringEditor], ['TarjetaCheckdigit', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(TiposDeTarjetaForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

