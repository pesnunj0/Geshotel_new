namespace Geshotel.Portal {
    export class TiposBloqueoForm extends Serenity.PrefixedContext {
        static formKey = 'Portal.TiposBloqueo';

    }

    export interface TiposBloqueoForm {
        Descriptivo: Serenity.StringEditor;
        Editable: Serenity.BooleanEditor;
    }

    [['Descriptivo', () => Serenity.StringEditor], ['Editable', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(TiposBloqueoForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

