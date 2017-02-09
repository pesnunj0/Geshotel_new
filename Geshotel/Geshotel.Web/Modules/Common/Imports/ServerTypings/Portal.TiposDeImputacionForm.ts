

namespace Geshotel.Portal {
    export class TiposDeImputacionForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposDeImputacion';
    }

    export interface TiposDeImputacionForm {
        Imputacion: Serenity.StringEditor;
    }

    [['TipoImputacionId', () => Serenity.IntegerEditor], ['Imputacion', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(TiposDeImputacionForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}